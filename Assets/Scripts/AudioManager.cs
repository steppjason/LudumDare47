using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{


    private AudioSource audioSource;

    private void Awake() {
        audioSource = this.gameObject.AddComponent<AudioSource>();
    }

    public void PlaySFX(AudioClip clip){
        audioSource.PlayOneShot(clip);
    }
}
