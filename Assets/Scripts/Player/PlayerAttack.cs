using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    [SerializeField] private int _attackDamage;
    [SerializeField] private const int _initialMaxExperience = 30;
    private EntityStatus _enemyStatus;
    [SerializeField] private ExperienceController experienceController; 
    private int _experienceAmt;
    private bool _isColliding;

    void Awake() {
        _attackDamage = 20;
        experienceController.SetPlayerInitialMaxExp(_initialMaxExperience);
    }
    void Update() {
        if(_isColliding && (_enemyStatus != null)) {
            _enemyStatus.TakeDamage(Mathf.Max(0, _attackDamage - _enemyStatus.GetDefense()));
        }
    }

    public void IncreaseAttackDamage(int dmgAmount) {
        _attackDamage += dmgAmount;
    }

    public int GetAttackDamage() {
        return _attackDamage;
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Enemy")) {
            _isColliding = true;
            if(_enemyStatus == null) {
                _enemyStatus = other.gameObject.GetComponent<EntityStatus>();
                _experienceAmt = _enemyStatus._containExperience;
            }
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("Enemy")) {
            experienceController.IncreaseExp(_experienceAmt);
            _isColliding = false;
            _enemyStatus = null;
        }
    }
}
