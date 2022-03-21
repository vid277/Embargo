using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public float volume;
    public AudioMixer mixer;

    [SerializeField]
    private string volumeName;

    void Awake()
    {
        if (PlayerPrefs.HasKey("volume"))
        {
            volume = PlayerPrefs.GetFloat("volume");
        }
        
        if (mixer != null){
            mixer.SetFloat(volumeName, Mathf.Log(volume)*20f);
        }

        if (volume == 0.0){
            mixer.SetFloat(volumeName, Mathf.Log(volume) * 0f);
        }
    }
}
