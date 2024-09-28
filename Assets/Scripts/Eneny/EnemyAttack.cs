using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    [SerializeField] float _attackDamage;
    private EntityStatus playerStatus;
    private bool _isColliding;
    private bool _levelScale;

    void Awake() {
        
    }
}
