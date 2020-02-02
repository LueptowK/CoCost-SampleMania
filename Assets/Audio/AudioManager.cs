using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] paClips = new AudioClip[56];
    private AudioSource audioManager;
    private int N;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GetComponent<AudioSource>();
        InvokeRepeating("PlaySound", 2.0f, 4.0f);
    }

    void PlaySound()
    {
        N = Random.Range(0, paClips.Length);
        if (!audioManager.isPlaying)
        {
            audioManager.PlayOneShot(paClips[N], 1.0f);
        }
    }

}
