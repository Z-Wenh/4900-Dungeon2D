using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TextSelfDestruct : MonoBehaviour {
    public float destructTime;
    private float _timer;
    // Start is called before the first frame update

    void Start() {
        _timer = destructTime; 
    }

    // Update is called once per frame
    void Update() {
        _timer -= Time.deltaTime;
        if(_timer <= 0) {
            Destroy(gameObject);
        }
    }
}
