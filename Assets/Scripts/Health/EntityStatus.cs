using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EntityStatus : MonoBehaviour {
    [SerializeField] private int _level;
    [SerializeField] private float _containExperience;
    [SerializeField] private float _currentHealth;
    public float _maximumHealth;
    [SerializeField] private float _defense;

    public float RemainingHealthPercentage {
        get {
            return _currentHealth / _maximumHealth;
        }
    }

    public UnityEvent OnDamaged;
    public UnityEvent OnDied;

    public bool IsInvincible{ get; set; }

    public void TakeDamage(float damageAmount) {
        if (IsInvincible) {
            return;
        }

        _currentHealth -= damageAmount;

        if(_currentHealth < 0) {
            _currentHealth = 0;
        }

        if(_currentHealth == 0) {
            OnDied.Invoke();
        }
        else {
            OnDamaged.Invoke();
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

    public float GetHealth() {
        return _currentHealth;
    }
}
