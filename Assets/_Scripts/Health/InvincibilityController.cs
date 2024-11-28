using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityController : MonoBehaviour {
    private EntityStatus _entityStatus;

    private void Awake() {
        _entityStatus = GetComponent<EntityStatus>();
    }

    public void StartInvincibility(float invincibilityDuration) {
        StartCoroutine(InvincibilityCoroutine(invincibilityDuration));
    }

    private IEnumerator InvincibilityCoroutine(float invincibilityDuration) {
        _entityStatus.IsInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        _entityStatus.IsInvincible = false;
    }
}
