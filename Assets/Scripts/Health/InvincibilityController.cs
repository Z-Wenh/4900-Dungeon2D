using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityController : MonoBehaviour {
    private EntityStatus entityStatus;

    private void Awake() {
        entityStatus = GetComponent<EntityStatus>();
    }

    public void StarInvincibility(float invincibilityDuration) {
        StartCoroutine(InvincibilityCoroutine(invincibilityDuration));
    }

    private IEnumerator InvincibilityCoroutine(float invincibilityDuration) {
        entityStatus.isInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        entityStatus.isInvincible = false;
    }
}
