using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInvincibility : MonoBehaviour {
    [SerializeField] private float _invincibilityDuration;
    InvincibilityController _invincibilityController;

    void Awake() {
        _invincibilityController = GetComponent<InvincibilityController>();
    }

    public void startInvincibility() {
        _invincibilityController.StarInvincibility(_invincibilityDuration);

    }
}
