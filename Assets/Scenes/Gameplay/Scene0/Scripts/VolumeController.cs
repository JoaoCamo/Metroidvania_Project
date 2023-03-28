using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeControl;

    private void Start()
    {
        if(!PlayerPrefs.HasKey("Volume"))
        {
            volumeControl.value = 1;
            saveVolume();
        } else {
            loadVolume();
        }
    }

    public void changeVolume()
    {
        AudioListener.volume = volumeControl.value;
        saveVolume();
    }

    private void loadVolume()
    {
        volumeControl.value = PlayerPrefs.GetFloat("Volume");
    }

    private void saveVolume()
    {
        PlayerPrefs.SetFloat("Volume", volumeControl.value);
    }
}
