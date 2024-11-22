using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour { 
    public GameObject InventoryMenu;
    public GameObject OpenInventoryButton;
    public GameObject StatMenuButton;
    public GameObject StatMenuPanel;
    private bool menuActivated;
    private bool _statPanelActive;
    [SerializeField] private TMP_Text _attackText;
    [SerializeField] private TMP_Text _defenseText;
    [SerializeField] private GameObject _playerObject;
    private int _attackTextAmount;
    private int _defenseTextAmount;

    public ItemSlot[] itemSlot;
    public EquipmentSlot HeadArmorSlot, BodyArmorSlot, LegArmorSlot, WeaponSlot;
    public GameItem[] consumableItems;
    public GameItem[] equipItems;
    
    void Awake() {
        if(_attackText == null) {
            _attackText = GameObject.Find("AttackStatText").GetComponent<TMP_Text>();
        }
        if(_defenseText == null) {
            _defenseText = GameObject.Find("DefenseStatText").GetComponent<TMP_Text>();
        }
        if(_playerObject == null) {
            _playerObject = GameObject.Find("Player");
        }

        InventoryMenu.SetActive(false);
        StatMenuPanel.SetActive(false);
        menuActivated = false;
        _statPanelActive = false;
    }
    void Start() {
        UpdateStatText();
    }

    void Update() {
        if(Input.GetButtonDown("Inventory") && menuActivated) {
            CloseInventory();
        }
        else if(Input.GetButtonDown("Inventory") && !menuActivated) {
            OpenInventory();
        }

        UpdateStatText();
    }

    public void OpenInventory() {
        InventoryMenu.SetActive(true);
        OpenInventoryButton.SetActive(false);
        StatMenuButton.SetActive(false);
        StatMenuPanel.SetActive(true);
        menuActivated = true;
        StatMenuPanel.GetComponent<RectTransform>().SetLocalPositionAndRotation(new Vector2(122, -1), Quaternion.identity);
    }

    public void CloseInventory() {
        InventoryMenu.SetActive(false);
        OpenInventoryButton.SetActive(true);
        StatMenuButton.SetActive(true);
        menuActivated = false;
        if(!_statPanelActive) {
            StatMenuPanel.SetActive(false);
        }
        StatMenuPanel.GetComponent<RectTransform>().SetLocalPositionAndRotation(new Vector2(347.5f, -1), Quaternion.identity);
    }

    public void OpenStatMenu() {
        if(StatMenuPanel.activeSelf) {
            StatMenuPanel.SetActive(false);
            _statPanelActive = false;
        }
        else {
            StatMenuPanel.SetActive(true);
            _statPanelActive = true;
        }
    }

    public void UseItem(string itemName) {
        for(int i = 0 ; i < consumableItems.Length ; i++) {
            if(consumableItems[i].itemName == itemName) {
                consumableItems[i].UseItem();
            }
        }
    }

    public void EquipGear(string itemName) {
        for(int i = 0 ; i < equipItems.Length ; i++) {
            if(equipItems[i].itemName == itemName) {
                equipItems[i].EquipCurrentGear();
            }
        }
        UpdateStatText();
    }

    public void UnEquipGear(string itemName) {
        for(int i = 0 ; i < equipItems.Length ; i++) {
            if(equipItems[i].itemName == itemName) {
                equipItems[i].UnEquipCurrentGear();
            }
        }
        UpdateStatText();
    }

    public bool AddItem(string itemName, Sprite itemSprite, string itemDescription, ItemType itemType) {
        for(int i = itemSlot.Length - 1 ; i >= 0 ; i--) {
            if(itemSlot[i].hasItem == false) {
                itemSlot[i].AddItem(itemName, itemSprite, itemDescription, itemType);
                return true;
            }
        }
        return false;
    }

    public void DeselectAllSlots() {
        for(int i = 0 ; i < itemSlot.Length; i++) {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].selectionPanel.SetActive(false);
            itemSlot[i].currentItemSelected = false;

            HeadArmorSlot._selectedShader.SetActive(false);
            HeadArmorSlot._thisItemSelected = false;
            BodyArmorSlot._selectedShader.SetActive(false);
            BodyArmorSlot._thisItemSelected = false;
            LegArmorSlot._selectedShader.SetActive(false);
            LegArmorSlot._thisItemSelected = false;
            WeaponSlot._selectedShader.SetActive(false);
            WeaponSlot._thisItemSelected = false;
        }
    }

    public void UpdateStatText() {
        _attackTextAmount = _playerObject.GetComponent<PlayerAttack>().GetAttackDamage();
        _defenseTextAmount = _playerObject.GetComponent<EntityStatus>().GetDefense();
        //_attackTextAmount = GameObject.Find("Player").GetComponent<PlayerAttack>().GetAttackDamage();
        //_defenseTextAmount = GameObject.Find("Player").GetComponent<EntityStatus>().GetDefense();
        _attackText.text = "Attack: " + _attackTextAmount;
        _defenseText.text = "Defense: " + _defenseTextAmount;
    }
}

public enum ItemType {
    consumable,
    headArmor,
    bodyArmor,
    legArmor,
    weapon,
    none
};
