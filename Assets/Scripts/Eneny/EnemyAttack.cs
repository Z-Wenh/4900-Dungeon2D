using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    [SerializeField] float _attackDamage;
    [SerializeField] float _levelScale;
    private EntityStatus playerStatus;
    private bool _isColliding;
    
    void Awake() {
        _attackDamage = 10 * _levelScale;
    }

    void Update() {
        if (_isColliding && (playerStatus != null)) {
            playerStatus.TakeDamage(_attackDamage);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            _isColliding = true;
            playerStatus = other.gameObject.GetComponent<EntityStatus>();
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            _isColliding = false;
        }
    }
}
