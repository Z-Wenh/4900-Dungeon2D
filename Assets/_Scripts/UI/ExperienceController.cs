using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class ExperienceController : MonoBehaviour {
    public int _level;
    private float _expMultiplier;
    [SerializeField] private int _currentMaxExp;
    [SerializeField] private int _currentExp;
    [SerializeField] private TMP_Text _expText;
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private Slider slider;
    public UnityEvent OnLevelUp;
    
    public void SetPlayerInitialMaxExp(int maxExp) {
        _level = 1;
        slider.maxValue = maxExp;
        _currentExp = 0;
        _currentMaxExp = maxExp;
        _expMultiplier = 0.05f * maxExp; 
        slider.value = 0f;
        UpdateExpText();
        UpdateLevelText();
    }

    public void IncreaseExp(int amountExp) {
        _currentExp += amountExp;
        slider.value += amountExp;
        UpdateExpText();
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
        _currentMaxExp = (int)slider.maxValue;
        slider.value = _currentExp;
        _level ++;
        UpdateExpText();
        UpdateLevelText();
    }

    private void UpdateExpText() {
        _expText.text = "EXP: "+ _currentExp + "/" + slider.maxValue;
    }

    private void UpdateLevelText() {
        _levelText.text = "LVL: " + _level;
    }
}
