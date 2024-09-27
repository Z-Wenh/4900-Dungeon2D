using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvincibility : MonoBehaviour {
    [SerializeField] private float _invincibilityDuration;
    private InvincibilityController _invincibilityController;

    void Awake() {
        _invincibilityController = GetComponent<InvincibilityController>();
    }
    public void startInvincibility() {
        _invincibilityController.StarInvincibility(_invincibilityDuration);
    }
}
