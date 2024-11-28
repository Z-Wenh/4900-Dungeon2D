using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {
    public static GameObject[] persistingObjects = new GameObject[4];
    [SerializeField] private int _objectIndex;
    void Awake() {
        if(persistingObjects[_objectIndex] == null) {
            persistingObjects[_objectIndex] = gameObject; 
            DontDestroyOnLoad(gameObject);
        }
        else if(persistingObjects[_objectIndex] != gameObject) {
            Destroy(gameObject);
        }
    }
}
