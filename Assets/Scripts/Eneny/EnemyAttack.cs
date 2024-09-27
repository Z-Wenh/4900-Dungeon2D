using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    [SerializeField] private float _attackDamage;
    [SerializeField] private bool _myTurnToAttack;
    EntityStatus myStatus;

    private void OnCollisionEnter2D(Collision2D collision) {
        _myTurnToAttack = false;
        if(collision.gameObject.GetComponent<PlayerInput>()) {
            initiateCombat(collision);
            Debug.Log("Initiate Combat With Player");
        }
    }
    private void OnCollisionExit2D(Collision2D collision) {
        if(collision.gameObject.GetComponent<PlayerInput>()) {
            _myTurnToAttack = true;
        }
    }
    void initiateCombat(Collision2D collision) {
        var entityStatus = collision.gameObject.GetComponent<EntityStatus>();
        if(_myTurnToAttack) {   
            entityStatus.takeDamage(_attackDamage);
        }
    }
}
