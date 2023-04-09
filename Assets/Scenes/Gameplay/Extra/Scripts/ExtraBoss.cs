using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraBoss : Fighter
{
    protected BoxCollider2D BoxCollider;
    protected Animator animator;
    private ExtraBossHUD HUD;
    private int count = 0;

    private bool stage1 = true;
    private bool stage2 = false;
    private bool stage3 = false;

    public ExtraEnding extraEnd;

    private void Start()
    {
        BoxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        HUD = GetComponent<ExtraBossHUD>();
        StartCoroutine(Fire());
    }

    private IEnumerator Fire()
    {
        if(stage1)
        {
            yield return new WaitForSeconds(2f);
            gameObject.GetComponent<Danmaku>().shot1();
        } else if(stage2){
            yield return new WaitForSeconds(0.2f);
            gameObject.GetComponent<Danmaku>().shot2();
        } else if(stage3) {
            yield return new WaitForSeconds(3f);
            while(count < 10)
            {
                yield return new WaitForSeconds(0.1f);
                gameObject.GetComponent<Danmaku>().shot3();
                count++;
            }
            count = 0;
        } else {
            yield return new WaitForSeconds(0.3f);
            gameObject.GetComponent<Danmaku>().shot4();
        }
        StartCoroutine(Fire());
    }

    protected override void ReceiveDamage(Damage dmg)
    {
        if(Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitpoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * 0f;

            GameManager.instance.showText(dmg.damageAmount.ToString(), 35, Color.red, transform.position, Vector3.up * 75, 0.5f);
            GameManager.instance.showParticle(transform.position, bloodType, 5f);

            if(hitpoint <= 0)
            {
                if(stage1)
                {
                    hitpoint = maxHitpoint;
                    animator.SetTrigger("attack");
                    stage1 = false;
                    stage2 = true;
                } else if(stage2) {
                    hitpoint = maxHitpoint;
                    animator.SetTrigger("attack");
                    stage2 = false;
                    stage3 = true;
                } else if(stage3) {
                    hitpoint = maxHitpoint;
                    animator.SetTrigger("attack");
                    stage3 = false;
                } else {
                    hitpoint = 0;
                    death();
                }
            }
        animator.SetTrigger("hit");
        HUD.HealthBarChange(hitpoint, maxHitpoint);
        }
    }

    protected override void death()
    {
        animator.SetTrigger("dead");
        gameObject.GetComponent<EnemyHitBox>().canHit = false;
        extraEnd.extraEnding();
    }

    public void destroy()
    {
        Destroy(gameObject);
    }
}
