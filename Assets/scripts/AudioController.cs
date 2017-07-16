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
        if (this.gender.Equals("cat"))
        {
            audioManager.GetComponent<AudioManager>().PlayCatAudio();
        }
        if (this.gender.Equals("dog"))
        {
            audioManager.GetComponent<AudioManager>().PlayDogAudio();
        }
        if (this.gender.Equals("deer"))
        {
            audioManager.GetComponent<AudioManager>().PlayDeerAudio();
        }
        if (this.gender.Equals("squirrel"))
        {
            audioManager.GetComponent<AudioManager>().PlaySquirrelAudio();
        }

    }
}
