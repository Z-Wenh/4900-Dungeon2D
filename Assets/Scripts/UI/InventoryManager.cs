using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour { 
    public GameObject InventoryMenu;
    public GameObject PlayerHUD;
    private bool menuActivated;

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

    public void AddItem(string itemName, Sprite itemSprite) {
        return;
    }
}
