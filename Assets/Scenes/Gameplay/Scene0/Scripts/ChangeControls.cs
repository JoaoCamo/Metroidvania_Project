using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeControls : MonoBehaviour
{
    public InputField[] inputFields;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("Controls"))
        {
            string controls = "";

            controls += "X|";
            controls += "Z|";
            controls += "I|";
            controls += "E|";
            controls += "C|";
            controls += "V|";

            PlayerPrefs.SetString("Controls", controls);
        }
        fillText();
    }

    public void fillText()
    {
        string[] controlsData = PlayerPrefs.GetString("Controls").Split("|");
        for(int i=0;i<controlsData.Length-1;i++)
        {
            inputFields[i].text = controlsData[i].ToUpper();
        }
    }

    public void submitChange()
    {
        string controls = "";
        
        controls += inputFields[0].text.ToUpper() + "|";
        controls += inputFields[1].text.ToUpper() + "|";
        controls += inputFields[2].text.ToUpper() + "|";
        controls += inputFields[3].text.ToUpper() + "|";
        controls += inputFields[4].text.ToUpper() + "|";
        controls += inputFields[5].text.ToUpper() + "|";

        PlayerPrefs.SetString("Controls",controls);
        GameManager.instance.loadKeys();
    }
}
