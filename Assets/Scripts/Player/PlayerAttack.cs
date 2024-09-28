using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    [SerializeField] float _attackDamage;
    private EntityStatus _enemyStatus;
    private bool _isColliding;

    void Awake() {
        _attackDamage = 20;
    }
    void Update() {
        if(_isColliding && (_enemyStatus != null)) {
            _enemyStatus.TakeDamage(_attackDamage);
        }
    }

    void IncreaseAttackDamage(float dmgAmount) {
        _attackDamage += dmgAmount;
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Enemy")) {
            _isColliding = true;
            if(_enemyStatus == null) {
                _enemyStatus = other.gameObject.GetComponent<EntityStatus>();
            }
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("Enemy")) {
            _isColliding = false;
            _enemyStatus = null;
        }
    }
}
