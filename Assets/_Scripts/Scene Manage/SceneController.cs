using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private SpawnPlayer _spawnPlayer;
    
    void Awake() {
        if(_playerMovement == null) {
            _playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        }
        if(_spawnPlayer == null) {
            _spawnPlayer = GameObject.FindWithTag("Player").GetComponent<SpawnPlayer>();
        }
    }

    void Start() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void NextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void LoadSceneAsync(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadEndScreen() {
        SceneManager.LoadScene("EndScreen");
    }

    public void WinningScreen() {
        SceneManager.LoadScene("WinScreen");
        
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if(scene.buildIndex == 0) {
            return;
        }
        if(scene.buildIndex == 10 || scene.buildIndex == 11) {
            GameObject _playerObject = GameObject.FindWithTag("Player");
            GameObject _playerUI = GameObject.Find("PlayerUI");
            GameObject _playerInventory = GameObject.Find("InventoryCanvas");
            _playerObject.SetActive(false);
            _playerUI.SetActive(false);
            _playerInventory.SetActive(false);
            return;
        }
        
        _spawnPlayer.SpawnPlayerPosition();
        _playerMovement.ResetMovePoint();
    }


}
