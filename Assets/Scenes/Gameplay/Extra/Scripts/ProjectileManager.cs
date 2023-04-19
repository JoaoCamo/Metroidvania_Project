using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProjectileManager : MonoBehaviour
{
    public GameObject[] bulletPrefab;
    private List<GameObject> bullets = new List<GameObject>();

    public void show(int type, float speed, Vector3 position, float rotation)
    {
        GameObject bullet = getBullet(type);

        bullet.transform.position = position;
        bullet.transform.rotation = Quaternion.Euler(transform.rotation.x,transform.rotation.y, rotation);
        bullet.GetComponent<Projectile>().type = type;
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
}
