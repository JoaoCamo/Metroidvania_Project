using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesManager : MonoBehaviour
{
    public GameObject[] particlePrefab;
    private List<Particles> particles = new List<Particles>();

    private void Update()
    {
        foreach(Particles par in particles)
        {
            par.UpdateParticles();
        }
    }
    
    public void show(Vector3 position, int type, float duration, Transform parent = null)
    {
        Particles par = getParticle(type);
        
        par.go.transform.position = position;
        par.go.transform.SetParent(parent);
        par.duration = duration;
        par.type = type;

        par.Show();
    }

    private Particles getParticle(int type)
    {
        Particles par = particles.Find(t => !t.active && t.type == type);

        if(par == null)
        {
            par = new Particles();
            par.go = Instantiate(particlePrefab[type]);

            particles.Add(par);
        }

        return par;
    }

    public void clearParticles()
    {
        particles.Clear();
        foreach (ParticleSystem par in FindObjectsOfType<ParticleSystem>())
        {
            Destroy(par.gameObject);
        }
    }
}
