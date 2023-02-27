using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : Enemy
{
    public Animator dialogAnimator;
    public Ending ending;
    private Rigidbody2D rb;
    private bool canDie = false;
    private bool dialogMenuOpen = false;
    public RectTransform finalBossHealthBar;
    public Animator finalBossHealthBarAni;

    public AudioClip stage2AttackAudio;
    private AudioSource audioSource;

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(dialogMenuOpen)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                dialogAnimator.SetTrigger("hide");
                ending.vampireEnding();
                dialogMenuOpen = false;
            } else if(Input.GetKeyDown(KeyCode.Backspace)){
                stage2Start();
                dialogMenuOpen = false;
            }
        }
    }

    protected override void ReceiveDamage(Damage dmg)
    {
        if(Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitpoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            if(hitpoint <= 0 && canDie)
            {
                death();
            } else if(hitpoint <= 0) {
                hitpoint = maxHitpoint;
                showDialog();
            }
            animator.SetTrigger("hit");
        }
        HealthBarChange();
    }

    private void showDialog()
    {
        finalBossHealthBarAni.SetTrigger("hide");
        dialogAnimator.SetTrigger("show");
        GameManager.instance.menuOpen = true;
        gameObject.GetComponent<EnemyHitBox>().canHit = false;
        dialogMenuOpen = true;
        alive = false;
    }

    private void stage2Start()
    {
        dialogAnimator.SetTrigger("hide");
        finalBossHealthBarAni.SetTrigger("show");
        animator.SetTrigger("stage2");
        GameManager.instance.menuOpen = false;
        gameObject.GetComponent<EnemyHitBox>().canHit = true;
        dialogMenuOpen = false;
        alive = true;
        canDie = true;
        hitpoint = maxHitpoint;
        HealthBarChange();
        audioSource.clip = stage2AttackAudio;
        GameManager.instance.mp.audioSource.clip = GameManager.instance.mp.music[7];
        GameManager.instance.mp.audioSource.Play();
    }

    protected override void death()
    {
        animator.SetTrigger("dead");
        alive = false;
        gameObject.GetComponent<EnemyHitBox>().canHit = false;
        ending.nonVampireEnding();
    }

    private void HealthBarChange()
    {
        float ratio = (float)hitpoint / (float)maxHitpoint;
        finalBossHealthBar.localScale = new Vector3(ratio, 1, 1);
    }

    public void stage2AnimationHelper()
    {
        Vector3 pos = new Vector3(65f,-0.3f,0);
        transform.position = pos;
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        alive = false;
    }

    public void stage2AnimationEnd()
    {
        alive = true;
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void destroy()
    {
        Destroy(gameObject);
    }
}
