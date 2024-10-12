using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class EntityStatus : MonoBehaviour {
    [SerializeField] private int _entityLevel;
    [SerializeField] private float _containExperience;
    [SerializeField] private float _currentHealth;
    public float _maximumHealth;
    [SerializeField] private float _defense;
    [SerializeField] private GameObject _popupDamagePrefab;
    [SerializeField] private TMP_Text popupText;
    public bool IsInvincible{ get; set; }
    public HealthBar healthBar;

    public UnityEvent OnDamaged;
    public UnityEvent OnDied;

    void Awake() {
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
            Debug.Log(gameObject + "has" + transform.position);
            GameObject popUpDamage = Instantiate(_popupDamagePrefab, transform.position, Quaternion.identity);
            popUpDamage.GetComponent<RectTransform>().anchoredPosition = new Vector2(transform.position.x, transform.position.y + 1.5f);
        }
    }

    public void AddHealth(float healAmount) {
        if (_currentHealth == _maximumHealth) {
            return ;
        }

        _currentHealth += healAmount;

        if (_currentHealth > _maximumHealth) {
            _currentHealth = _maximumHealth;
        }
    }
}
