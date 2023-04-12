using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danmaku : MonoBehaviour
{
    private float angle;

    public ProjectileManager pm;

    public void shot1()
    {
        angle = 0f;
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

    public void shot2()
    {
        float bulletDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
        float bulletDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

        Vector3 bulletMoveVector = new Vector3(bulletDirX, bulletDirY, 0f);
        Vector2 bulletDirection = (bulletMoveVector - transform.position).normalized;

        pm.show(1, bulletDirection, 1f, transform.position, transform.rotation);

        angle += 30f;
    }

    public void shot3()
    {
        angle = 0f;
        for (int i = 0; i < 8 + 1; i++)
        {
            float bulletDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulletDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulletMoveVector = new Vector3(bulletDirX, bulletDirY, 0f);
            Vector2 bulletDirection = (bulletMoveVector - transform.position).normalized;

            pm.show(1, bulletDirection, 1f, transform.position, transform.rotation);

            angle += 45;
        }
    }

    public void shot4()
    {
        for (int i = 0; i < 3 + 1; i++)
        {
            float bulletDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulletDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulletMoveVector = new Vector3(bulletDirX, bulletDirY, 0f);
            Vector2 bulletDirection = (bulletMoveVector - transform.position).normalized;

            pm.show(2, bulletDirection, 1f, transform.position, transform.rotation);

            angle += 20;
            if(i == 1)
            {
                angle += 140;
            }
        }
    }
}
