using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public float startAngle;
    public float endAngle;
    public ProjectileManager pm;

    public bool teste;

    private void Start()
    {
        InvokeRepeating("Fire", 0f, 2f);
    }

    private void Fire()
    {
        float angle;
        
        if (teste)
        {
            angle = 90f;
            for (int i = 0; i < 36 + 1; i++)
            {
                float bulletDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
                float bulletDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

                Vector3 bulletMoveVector = new Vector3(bulletDirX, bulletDirY, 0f);
                Vector2 bulletDirection = (bulletMoveVector - transform.position).normalized;

                pm.show(0, bulletDirection, 1f, transform.position, transform.rotation);

                angle += 10;
            }
        } else {
            angle = 90f;
            for (int i = 0; i < 8 + 1; i++)
            {
                float bulletDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
                float bulletDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

                Vector3 bulletMoveVector = new Vector3(bulletDirX, bulletDirY, 0f);
                Vector2 bulletDirection = (bulletMoveVector - transform.position).normalized;

                pm.show(0, bulletDirection, 1f, transform.position, transform.rotation);

                angle += 45;
            }  
        }
    }
}
