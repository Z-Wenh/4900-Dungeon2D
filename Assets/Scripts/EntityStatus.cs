using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EntityStatus : MonoBehaviour {
    [SerializeField] private int _level;
    [SerializeField] private float _containExperience;
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _maximumHealth;
    [SerializeField] private float _defense;

    public float RemainingHealthPercentage {
        get {
            return _currentHealth / _maximumHealth;
        }
    }

    public UnityEvent OnDied;

    public void takeDamage(float damageAmount) {
        if(_currentHealth == 0) {
            OnDied.Invoke();
        }

        _currentHealth -= damageAmount;

        if(_currentHealth < 0) {
            _currentHealth = 0;
        }
    }

    public void addHealth(float healAmount) {
        if(_currentHealth == _maximumHealth) {
            return ;
        }

        _currentHealth += healAmount;

        if(_currentHealth > _maximumHealth) {
            _currentHealth = _maximumHealth;
        }
    }
}
