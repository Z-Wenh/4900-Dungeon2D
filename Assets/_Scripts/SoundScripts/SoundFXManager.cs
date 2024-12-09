using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour {
    public static SoundFXManager instance;
    
    [SerializeField] private AudioSource _soundFXPrefab;
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioClip _musicClip;

    void Awake() {
        if(instance == null) {
            instance = this;
        }
    }

    void Start() {
        _musicSource.clip = _musicClip;
        _musicSource.Play();
    }

    public void PlaySoundFXClip(AudioClip audioClip, Transform targetTransform, float volume) {
        AudioSource audioSource = Instantiate(_soundFXPrefab, targetTransform.position, Quaternion.identity);

        audioSource.volume = volume;

        audioSource.Play();

        float clipLength = audioSource.clip.length;

        Destroy(audioSource.gameObject, clipLength);
    }
}
