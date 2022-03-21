using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[RequireComponent(typeof (Slider))]
public class Music : MonoBehaviour
{
    Slider slider{
        get{
            return GetComponent<Slider>();
        }
    }

    public AudioMixer mixer;

    [SerializeField]
    private string volumeName;

    [SerializeField]
    private Text volumeLabel;
    private void Start() {
        updateval(slider.value);

        slider.onValueChanged.AddListener(delegate{
            updateval(slider.value);
            SetGameVolume(slider.value);
        }
);
    }
    public void updateval(float value){
        if (mixer != null){
            mixer.SetFloat(volumeName, Mathf.Log(value)*20f);
        }
        if (volumeLabel != null && value != 0.0){
            volumeLabel.text = Mathf.Round(value * 100.0f).ToString()+ "%";
        }
        if (value == 100.0){
            mixer.SetFloat(volumeName, Mathf.Log(value) * 100f);
            volumeLabel.text = Mathf.Round(value * 100.0f).ToString()+ "%";
        }
        if (value == 0.0){
            mixer.SetFloat(volumeName, Mathf.Log(value) * 0f);
            volumeLabel.text = Mathf.Round(value * 100.0f).ToString()+ "%";
        }
    }

    public void SetGameVolume(float volume) {
        AudioListener.volume = volume;
 
        PlayerPrefs.SetFloat("volume", volume);
        PlayerPrefs.Save();
    }
}
