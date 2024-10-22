using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceController : MonoBehaviour {
    private int _level;
    private float _expMultiplier;
    private float _currentMaxExp;
    public Slider slider;
    
    public void SetInitialMaxExp(float maxExp) {
        _level = 1;
        slider.maxValue = maxExp;
        _currentMaxExp = maxExp;
        _expMultiplier = 0.4f * maxExp; 
        slider.value = 0f;
    }

    public void IncreaseExp(float amountExp) {
        slider.value += amountExp;
    }

    public void LevelUp() {
        slider.maxValue = _currentMaxExp * _expMultiplier + _level;
        _currentMaxExp = slider.maxValue;
        slider.value = 0f;
        _level ++;  
    }
}
