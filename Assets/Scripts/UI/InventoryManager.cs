using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour { 
    public GameObject InventoryMenu;
    public GameObject OpenInventoryButton;
    private bool menuActivated;

    public ItemSlot[] itemSlot;
    public EquipmentSlot HeadArmorSlot, BodyArmorSlot, LegArmorSlot, WeaponSlot;
    public GameItem[] gameItems;
    
    void Start() {
        InventoryMenu.SetActive(false);
        menuActivated = false;
    }

    void Update() {
        if(Input.GetButtonDown("Inventory") && menuActivated) {
            CloseInventory();
        }
        else if(Input.GetButtonDown("Inventory") && !menuActivated) {
            OpenInventory();
        }
    }

    public void OpenInventory() {
        InventoryMenu.SetActive(true);
        OpenInventoryButton.SetActive(false);
        menuActivated = true;
    }

    public void CloseInventory() {
        InventoryMenu.SetActive(false);
        OpenInventoryButton.SetActive(true);
        menuActivated = false;
    }

    public void UseItem(string itemName) {
        for(int i = 0 ; i < gameItems.Length ; i++) {
            if(gameItems[i].itemName == itemName) {
                gameItems[i].UseItem();
            }
        }
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
}

public enum ItemType {
    consumable,
    headArmor,
    bodyArmor,
    legArmor,
    weapon,
    none
};
