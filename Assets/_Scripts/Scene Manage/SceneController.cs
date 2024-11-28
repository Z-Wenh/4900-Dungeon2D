using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private SpawnPlayer _spawnPlayer;
    
    void Awake() {
        if(_playerMovement == null) {
            _playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        }
        if(_spawnPlayer == null) {
            _spawnPlayer = GameObject.Find("Player").GetComponent<SpawnPlayer>();
        }
    }

    void Start() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void NextLevel() {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void LoadSceneAsync(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        _spawnPlayer.SpawnPlayerPosition();
        _playerMovement.ResetMovePoint();
    }
}
