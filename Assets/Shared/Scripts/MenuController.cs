using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public RectTransform healthBar;
    public Animator deathScreen;
    public Animator stageComplete;
    public Animator loadingScreen;
    public Image progressBar;

    public bool initialDialog = false;
    public bool ending1 = false;
    public bool ending2 = false;
    public bool extra = false;
}
