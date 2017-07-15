using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AudioManager : MonoBehaviour {

    private AudioSource audio;
    private AudioClip[] MaleAudio;
    private AudioClip[] FemaleAudio;
    private Object[] femaleAudio;

    // Use this for initialization
    void Start () {
        Object[] maleAudio = Resources.LoadAll("Sound/Scream/Male");
        MaleAudio = new AudioClip[maleAudio.Length];
        for (int i = 0; i < maleAudio.Length; i++)
        {
            MaleAudio[i] = (AudioClip)maleAudio[i];
        }

        Object[] femaleAudio = Resources.LoadAll("Sound/Scream/Female");
        FemaleAudio = new AudioClip[femaleAudio.Length];
        for (int i = 0; i < femaleAudio.Length; i++)
        {
            FemaleAudio[i] = (AudioClip)femaleAudio[i];
        }

        audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayMaleAudio()
    {
        audio.clip = MaleAudio[Random.Range(0, MaleAudio.Length)];
        audio.Play();
    }

    public void PlayFemaleAudio()
    {
        audio.clip = FemaleAudio[Random.Range(0, FemaleAudio.Length)];
        audio.Play();
    }
}
