using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerManager : MonoBehaviour {
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private Slider _musicSlider;
    
    void Awake() {
        if(_volumeSlider == null) {
            _volumeSlider = GameObject.FindWithTag("SoundFX").GetComponent<Slider>();
        }
        if(_musicSlider == null) {
            _musicSlider = GameObject.FindWithTag("Music").GetComponent<Slider>();
        }
    }

    void Start() {
        PlayerPrefs.SetFloat("SoundFX", 1);
        PlayerPrefs.SetFloat("Music", 1);
    }

    public void SetSoundFXVolume(float volumeLevel) {
        _audioMixer.SetFloat("SoundFX", Mathf.Log10(volumeLevel) * 20);
        PlayerPrefs.SetFloat("SoundFX", Mathf.Log10(volumeLevel) * 20);
        PlayerPrefs.Save();
    }

    public void SetMusicVolume(float volumeLevel) {
        _audioMixer.SetFloat("Music", Mathf.Log10(volumeLevel) * 20);
        PlayerPrefs.SetFloat("Music", Mathf.Log10(volumeLevel) * 20);
        PlayerPrefs.Save();
    }

    public void LoadSound() {
        _volumeSlider.value = PlayerPrefs.GetFloat("SoundFX");
    }

    public void LoadMusic() {
        _musicSlider.value = PlayerPrefs.GetFloat("Music");
    }
}
