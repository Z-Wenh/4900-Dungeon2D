using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class LevelAdvanceController : MonoBehaviour {
    private bool _playerInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    [SerializeField] private Canvas _nextLevelCanvas;

    void Awake() {
        if(_nextLevelCanvas == null) {
            _nextLevelCanvas = gameObject.GetComponent<Canvas>();
        }
        

        _nextLevelCanvas.enabled = false;
    }

    void Update() {
        if(_playerInRange) {
            if(Input.GetKeyDown(interactKey)) {
                interactAction.Invoke();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            _playerInRange = true;
            _nextLevelCanvas.enabled = _playerInRange;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            _playerInRange = false;
            _nextLevelCanvas.enabled = _playerInRange;
        }
    }
}
