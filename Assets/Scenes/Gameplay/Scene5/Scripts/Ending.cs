using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    private Animator animator;
    public Text endingText;

    private void Start()
    {
        animator =  GetComponent<Animator>();
    }

    public void vampireEnding()
    {
        animator.SetTrigger("show");
        endingText.text = "Você escolheu se juntar aos vampiros, trazendo uma nova era de sombras";
    }

    public void nonVampireEnding()
    {
        animator.SetTrigger("show");
        endingText.text = "Você rejeitou a oferta do vampiro, e apos o derrotar os vampiros restantes fogem. Trazendo um fim a essa loucura, por enquanto...";
    }

    public void endingReturnToMainMenu()
    {
        GameManager.instance.returnToMainMenu();
    }
}
