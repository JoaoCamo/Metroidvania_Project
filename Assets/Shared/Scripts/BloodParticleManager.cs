using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodParticleManager : MonoBehaviour
{
    public GameObject bloodPrefab;
    private List<BloodParticle> bloodParticles = new List<BloodParticle>();
    
    private void Update()
    {
        foreach(BloodParticle bp in bloodParticles)
        {
            bp.UpdateBloodParticles();
        }
    }
    
    public void show(Vector3 position, float duration)
    {
        BloodParticle bp = getBloodParticle();
        
        bp.go.transform.position = position;
        bp.duration = duration;

        bp.Show();
    }
    
    private BloodParticle getBloodParticle()
    {
        BloodParticle bp = bloodParticles.Find(t => !t.active);

        if(bp == null)
        {
            bp = new BloodParticle();
            bp.go = Instantiate(bloodPrefab);

            bloodParticles.Add(bp);
        }

        return bp;
    }

    public void clearBloodParticles()
    {
        bloodParticles.Clear();
    }
}
