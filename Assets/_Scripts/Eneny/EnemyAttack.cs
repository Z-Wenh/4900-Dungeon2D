using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    [SerializeField] float _attackDamage;
    [SerializeField] float _levelScale;
    [SerializeField] Transform target;
    private EntityStatus playerStatus;
    private bool _isColliding;
    
    void Awake() {
        target = GameObject.FindWithTag("Player").transform;
        _attackDamage = 3 * _levelScale;
    }

    void Update() {
        if (_isColliding && (playerStatus != null)) {
            playerStatus.TakeDamage(Mathf.Max(0, _attackDamage - playerStatus.GetDefense()));
        }
        if(target.position.x <= transform.position.x) {
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        else {
            transform.rotation = new Quaternion(0, 0, 0, 0);
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
