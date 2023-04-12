using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraBossTrigger : MonoBehaviour
{
    private bool isPlaying = false;
    public Animator extraBossHealthBarAni;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.name == "Player" && !isPlaying)
        {
            GameManager.instance.mp.audioSource.clip = GameManager.instance.mp.music[8];
            GameManager.instance.mp.audioSource.Play();
            extraBossHealthBarAni.SetTrigger("show");
            isPlaying = true;
        }
    }
}
