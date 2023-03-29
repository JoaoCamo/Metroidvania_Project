using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodParticle
{
    public bool active;
    public GameObject go;
    public float duration;
    public float lastShown;
    
    public void Show()
    {
        active = true;
        lastShown = Time.time;
        go.SetActive(active);
    }

    public void Hide()
    {
        active = false;
        go.SetActive(active);
    }
    
    public void UpdateBloodParticles()
    {
        if(!active)
        {
            return;
        }

        if(Time.time - lastShown > duration)
        {
            Hide();
        }
    }
}
