using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class EntityStatus : MonoBehaviour {
    [SerializeField] private GameObject _popupDamagePrefab;
    [SerializeField] private TMP_Text popupText;
    [SerializeField] private int _entityLevel;
    [SerializeField] private float _currentHealth;
    public int _containExperience;
    public float _maximumHealth;
    [SerializeField] private int _defense;
    public bool IsInvincible{ get; set; }
    public HealthBar healthBar;
    public UnityEvent OnDamaged;
    public UnityEvent OnDied;

    void Awake() {
        _currentHealth = _maximumHealth;
        healthBar.SetMaxHealth(_maximumHealth);
    }

    public void TakeDamage(float damageAmount) {
        if (IsInvincible) {
            return;
        }

        _currentHealth -= damageAmount;
        healthBar.SetHealth(_currentHealth);

        if(_currentHealth < 0) {
            _currentHealth = 0;
        }

        if(_currentHealth == 0) {
            OnDied.Invoke();
        }
        else {
            OnDamaged.Invoke();
            popupText.text = damageAmount.ToString();
            GameObject popUpDamage = Instantiate(_popupDamagePrefab, transform.position, Quaternion.identity);
            popUpDamage.GetComponent<RectTransform>().anchoredPosition = new Vector2(transform.position.x, transform.position.y + 1.5f);
        }
    }

    public void AddHealth(float healAmount) {
        if(healAmount < 0) {
            _currentHealth += healAmount;
            healthBar.SetHealth(_currentHealth);
            return;
        }

        if (_currentHealth == _maximumHealth) {
            return ;
        }

        _currentHealth += healAmount;
        healthBar.SetHealth(_currentHealth);
        if (_currentHealth > _maximumHealth) {
            _currentHealth = _maximumHealth;
        }
    }

    public void AddMaxHealth(float maxHealthAmount) {
        _maximumHealth += maxHealthAmount;
        healthBar.SetMaxHealth(_maximumHealth);
        AddHealth(maxHealthAmount);
    }
    
    public void AddExperience(int expAmount) {
        GameObject PlayerExperienceController = GameObject.Find("PlayerExperienceBarHUD");
        PlayerExperienceController.GetComponent<ExperienceController>().IncreaseExp(expAmount);
    }

    public void AddLevel() {
        _entityLevel++;
    }

    public void IncreaseDefense(int defenseAmount) {
        _defense += defenseAmount;
    }

    public int GetDefense() {
        return _defense;
    }
}
