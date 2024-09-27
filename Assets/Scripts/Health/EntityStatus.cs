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
    [SerializeField] private float _attackDamage;

    public float RemainingHealthPercentage {
        get {
            return _currentHealth / _maximumHealth;
        }
    }
    public UnityEvent onDamaged;

    public bool isInvincible{ get; set; }

    public void takeDamage(float damageAmount) {
        if (_currentHealth == 0) {
            Debug.Log("Enemy Died");
            Die();
        }
        else {
            onDamaged.Invoke();
        }

        if (isInvincible) {
            return;
        }

        _currentHealth -= damageAmount;

        if (_currentHealth < 0) {
            _currentHealth = 0;
        }
    }

    public void addHealth(float healAmount) {
        if (_currentHealth == _maximumHealth) {
            return ;
        }

        _currentHealth += healAmount;

        if (_currentHealth > _maximumHealth) {
            _currentHealth = _maximumHealth;
        }
    }

    public float getAttack() {
        return _attackDamage;
    }

    void Die() {
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

    public float getHealth() {
        return _currentHealth;
    }
}
