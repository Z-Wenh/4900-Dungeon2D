using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ExperienceController : MonoBehaviour {
    public int _level;
    private float _expMultiplier;
    [SerializeField] private float _currentMaxExp;
    [SerializeField] private float _currentExp;
    public Slider slider;
    public UnityEvent OnLevelUp;
    
    public void SetPlayerInitialMaxExp(float maxExp) {
        _level = 1;
        slider.maxValue = maxExp;
        _currentExp = 0f;
        _currentMaxExp = maxExp;
        _expMultiplier = 0.05f * maxExp; 
        slider.value = 0f;
    }

    public void IncreaseExp(float amountExp) {
        _currentExp += amountExp;
        slider.value += amountExp;
        if(slider.value == _currentMaxExp) {
            LevelUp();
            OnLevelUp.Invoke();
        }
    }

    public float GetCurrentMaxExp() {
        return _currentMaxExp;
    }

    public void LevelUp() {
        _currentExp = _currentExp % _currentMaxExp;
        slider.maxValue = Mathf.Floor(_currentMaxExp * _expMultiplier + _level);
        _currentMaxExp = slider.maxValue;
        slider.value = _currentExp;
        _level ++;  
    }
}
