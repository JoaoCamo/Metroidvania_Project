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
        for (int i = 0; i < 7 + 1; i++)
        {
            pm.show(0, 1f, transform.position, -angle);

            angle += 45;
        }
    }

    public void shot2()
    {
        pm.show(2, 1f, transform.position, -angle);

        angle += 30f;
    }

    public void shot3()
    {
        angle = 0f;
        for (int i = 0; i < 8 + 1; i++)
        {
            pm.show(3, 1f, transform.position, -angle);

            angle += 45;
        }
    }

    public void shot4()
    {
        for (int i = 0; i < 2 + 1; i++)
        {
            pm.show(1, -1f, transform.position, angle);

            if (i == 2)
            {
                angle += 20;
            } else
            {
                angle += 120;
            }
        }
    }
}
