using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
    [SerializeField] private string gender;

    private GameObject audioManager;

    void Start()
    {
        audioManager = GameObject.Find("AudioManager");
            
    }

    public void PlaySound()
    {
        if (this.gender.Equals("m"))
        {
            audioManager.GetComponent<AudioManager>().PlayMaleAudio();
        }
        if (this.gender.Equals("w"))
        {
            audioManager.GetComponent<AudioManager>().PlayFemaleAudio();
        }

    }
}
