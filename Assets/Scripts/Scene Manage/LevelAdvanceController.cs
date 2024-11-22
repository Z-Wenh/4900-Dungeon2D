using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelAdvanceController : MonoBehaviour {
    [SerializeField] private Canvas _nextLevelCanvas;

    void Awake() {
        if(_nextLevelCanvas == null) {
            _nextLevelCanvas = gameObject.GetComponent<Canvas>();
        }

        _nextLevelCanvas.enabled = false;
    }

    void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            _nextLevelCanvas.enabled = true;
            if(Input.GetKeyDown(KeyCode.F)) {
                Debug.Log("Button F was pressed");
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            _nextLevelCanvas.enabled = false;
        }
    }
}
