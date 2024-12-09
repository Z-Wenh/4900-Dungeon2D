using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour {
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _healthText;

    public void SetMaxHealth(float health) {
        _slider.maxValue = health;
        _slider.value = health;
        UpdateHealthText();
    }

    public void SetHealth(float health) {
        _slider.value = health;
        UpdateHealthText();
    }

    private void UpdateHealthText() {
        _healthText.text = "HP: " + _slider.value + "/" + _slider.maxValue;
    }
}
