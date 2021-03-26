using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FootStepsAudio : MonoBehaviour
{
    public AudioClip stepSound;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 1;
    }

    private void Step()
    {
        audioSource.PlayOneShot(stepSound);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
