using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles
{
    public bool active;
    public GameObject go;
    public float duration;
    public float lastShown;

    public int type;

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
    
    public void UpdateParticles()
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
