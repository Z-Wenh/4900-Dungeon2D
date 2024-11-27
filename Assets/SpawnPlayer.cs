using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPlayer : MonoBehaviour {
    [SerializeField] private Transform _spawnPoint;
    // Start is called before the first frame update
    void Awake() {
        _spawnPoint = GameObject.Find("SpawnPoint").GetComponent<Transform>();
        gameObject.transform.SetPositionAndRotation(_spawnPoint.position, Quaternion.identity);
    }

    public void SpawnPlayerPosition() {
        _spawnPoint = GameObject.Find("SpawnPoint").GetComponent<Transform>();
        gameObject.transform.position = _spawnPoint.transform.position;
        Debug.Log("Position is set");
    }
}
