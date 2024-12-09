using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeEnemyHealthBar : MonoBehaviour {
    [SerializeField] private Camera _camera;  
    void Awake() {
        if(_camera == null) {
            _camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        }
    }

    void Update() {
        transform.rotation = _camera.transform.rotation;
    }
}
