using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour {
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Text healthText;

    public void SetMaxHealth(float health) {
        slider.maxValue = health;
        slider.value = health;
        healthText.text = "HP: " + slider.value + "/" + slider.maxValue;
    }

    public void SetHealth(float health) {
        slider.value = health;
        healthText.text = "HP: " + slider.value + "/" + slider.maxValue;
    }
}
