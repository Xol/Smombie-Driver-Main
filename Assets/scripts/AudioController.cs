using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
    [SerializeField] private string gender;
    private static AudioSource[] maleAudio = Resources.LoadAll("Assets/Resources/Sound/Scream/Male") as AudioSource[];
    private static AudioSource[] femaleAudio = Resources.LoadAll("Assets/Resources/Sound/Scream/Female") as AudioSource[];

    public void ChooseSound()
    {
        if (this.gender == "male")
        {
            Debug.Log("Play male sound");
            PlaySound(maleAudio[0]);
        }

        if (this.gender == "female")
        {
            Debug.Log("Play female sound");
            PlaySound(femaleAudio[0]);
        }
    }

    public void PlaySound(AudioSource sound)
    {
        if(sound != null) {
            AudioSource audio = sound;
            audio.Play();
        }
    }
}
