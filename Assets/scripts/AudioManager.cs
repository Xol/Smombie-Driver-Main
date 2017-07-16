using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AudioManager : MonoBehaviour {

    private AudioSource audio;

    private AudioClip[] MaleAudio;
    private AudioClip[] FemaleAudio;
    private AudioClip[] DeerAudio;
    private AudioClip[] CatAudio;
    private AudioClip[] DogAudio;
    private AudioClip[] SquirrelAudio;
    
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

        // Deer sound
        Object[] deerAudio = Resources.LoadAll("Sound/Pet/Deer");
        DeerAudio = new AudioClip[deerAudio.Length];
        for (int i = 0; i < deerAudio.Length; i++)
        {
            DeerAudio[i] = (AudioClip)deerAudio[i];
        }

        // Cat sound
        Object[] catAudio = Resources.LoadAll("Sound/Pet/Cat");
        CatAudio = new AudioClip[catAudio.Length];
        for (int i = 0; i < catAudio.Length; i++)
        {
            CatAudio[i] = (AudioClip)catAudio[i];
        }

        // Dog sound
        Object[] dogAudio = Resources.LoadAll("Sound/Pet/Dog");
        DogAudio = new AudioClip[dogAudio.Length];
        for (int i = 0; i < dogAudio.Length; i++)
        {
            DogAudio[i] = (AudioClip)dogAudio[i];
        }

        // Squirrel sound
        Object[] squirrelAudio = Resources.LoadAll("Sound/Pet/Squirrel");
        SquirrelAudio = new AudioClip[squirrelAudio.Length];
        for (int i = 0; i < squirrelAudio.Length; i++)
        {
            SquirrelAudio[i] = (AudioClip)squirrelAudio[i];
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

    public void PlayDeerAudio()
    {
        audio.clip = DeerAudio[0];
        audio.Play();
    }

    public void PlayDogAudio()
    {
        audio.clip = DogAudio[0];
        audio.Play();
    }

    public void PlayCatAudio()
    {
        audio.clip = CatAudio[0];
        audio.Play();
    }

    public void PlaySquirrelAudio()
    {
        audio.clip = SquirrelAudio[0];
        audio.Play();
    }
}
