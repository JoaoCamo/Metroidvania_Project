using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public GameObject[] bulletPrefab;
    private List<GameObject> bullets = new List<GameObject>();

    public void show(int type, Vector2 dir, float speed, Vector3 position, Quaternion rotation)
    {
        GameObject bullet = getBullet(type);

        bullet.transform.position = position;
        bullet.transform.rotation = rotation;
        bullet.GetComponent<Projectile>().type = type;
        bullet.GetComponent<Projectile>().direction = dir;
        bullet.GetComponent<Projectile>().speed = speed;

        bullet.GetComponent<Projectile>().Show();
    }

    public GameObject getBullet(int type)
    {
        GameObject bullet = bullets.Find(t => !t.GetComponent<Projectile>().active && t.GetComponent<Projectile>().type == type);

        if(bullet == null)
        {
            bullet = Instantiate(bulletPrefab[type]);

            bullets.Add(bullet);
        }

        return bullet;
    }

    public void clearBullets()
    {
        bullets.Clear();
    }
}
