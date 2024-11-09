using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour { 
    public GameObject InventoryMenu;
    public GameObject PlayerHUD;
    private bool menuActivated;
    public ItemSlot[] itemSlot;
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
        PlayerHUD.SetActive(false);
        menuActivated = true;
    }

    public void CloseInventory() {
        InventoryMenu.SetActive(false);
        PlayerHUD.SetActive(true);
        menuActivated = false;
    }

    public void UseItem(string itemName) {
        for(int i = 0 ; i < gameItems.Length ; i++) {
            if(gameItems[i].itemName == itemName) {
                gameItems[i].UseItem();
            }
        }
    }

    public void AddItem(string itemName, Sprite itemSprite, string itemDescription) {
        for(int i = itemSlot.Length - 1 ; i >= 0 ; i--) {
            if(itemSlot[i].hasItem == false) {
                itemSlot[i].AddItem(itemName, itemSprite, itemDescription);
                return;
            }
        }
    }

    public void DeselectAllSlots() {
        for(int i = 0 ; i < itemSlot.Length; i++) {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].selectionPanel.SetActive(false);
            itemSlot[i].currentItemSelected = false;
        }
    }
}
