using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitlePanelController : MonoBehaviour {
    [SerializeField] GameObject ButtonPanel;
    [SerializeField] GameObject InstructionPanel;
    
    void Awake() {
        InstructionPanel.SetActive(false);
    }
    
    public void Play() {
        SceneManager.LoadScene("SampleScene");
    }
    
    public void Instruction() {
        InstructionPanel.SetActive(true);
    }

    public void Setting() {

    }

    public void ExitInstruction() {
        InstructionPanel.SetActive(false);
    }
}
