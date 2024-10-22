using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExp : MonoBehaviour {
    [SerializeField] private const float _initialMaxExperience = 30;

    public ExperienceController _expController;
    public EntityStatus _playerStatus;

    void Awake() {
        _playerStatus = gameObject.GetComponent<EntityStatus>();
        _expController.SetInitialMaxExp(_initialMaxExperience);
    }

    void Update() {
        
    }
}
