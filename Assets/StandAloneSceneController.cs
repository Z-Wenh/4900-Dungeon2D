using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StandAloneSceneController : MonoBehaviour {
    public void LoadTitleScene() {
        SceneManager.LoadScene("TitleScene");
    }
}
