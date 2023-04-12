using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraBossHUD : MonoBehaviour
{
    public RectTransform finalBossHealthBar;
    public Animator finalBossHealthBarAni;

    public void HealthBarChange(float hitpoint, float maxHitpoint)
    {
        float ratio = (float)hitpoint / (float)maxHitpoint;
        finalBossHealthBar.localScale = new Vector3(ratio, 1, 1);
    }
}
