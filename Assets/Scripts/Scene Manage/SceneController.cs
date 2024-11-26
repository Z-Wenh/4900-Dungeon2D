using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public void NextLevel() {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void LoadSceneAsync(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
