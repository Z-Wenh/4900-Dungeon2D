using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitlePanelController : MonoBehaviour {
    [SerializeField] GameObject InstructionPanel;
    [SerializeField] GameObject SettingsPanel;

    void Awake() {
        InstructionPanel.SetActive(false);
        SettingsPanel.SetActive(false);
    }
    
    public void Play() {
        SceneManager.LoadScene("Stage1Level1");
    }
    
    public void OpenInstruction() {
        InstructionPanel.SetActive(true);
    }

    public void OpenSetting() {
        SettingsPanel.SetActive(true);
    }

    public void ExitInstruction() {
        InstructionPanel.SetActive(false);
    }

    public void ExitSettings() {
        SettingsPanel.SetActive(false);
    }
}
