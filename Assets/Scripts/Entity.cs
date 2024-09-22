using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Entity : MonoBehaviour {
    [SerializeField] protected float _containExperience;
    [SerializeField] protected float _currentHealth;
    [SerializeField] protected float _maximumHealth;
    [SerializeField] protected float _attackDamage;

    // Start is called before the first frame update
    void Awake() {
        _maximumHealth = 100;
    }

    public float RemainingHealthPercentage {
        get {
            return _currentHealth / _maximumHealth;
        }
    }

    public void TakeDamage(float damageAmount) {
        _currentHealth -= damageAmount;
    } 
}
