using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossTrigger : MonoBehaviour
{
    private bool isPlaying = false;
    public Animator finalBossHealthBarAni;

    private void OntriggerEnter2D(Collider2D coll)
    {
        if(coll.name == "Player" && !isPlaying)
        {
            GameManager.instance.mp.audioSource.clip = GameManager.instance.mp.music[6];
            GameManager.instance.mp.audioSource.Play();
            finalBossHealthBarAni.SetTrigger("show");
            isPlaying = true;
        }
    }
}
