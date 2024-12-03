using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public string itemName;
    public SpriteRenderer spriteRender;
    [TextArea] public string itemDescription;
    public bool itemCanBeAdded;

    private InventoryManager _inventoryManager;
    public GameItem gameItem;
    public ItemType itemType;

    private void OnValidate(){
        if(gameItem == null) {
            return;
        }
        this.name = gameItem.itemName;
        itemName = gameItem.itemName;
        itemDescription = gameItem.itemDescription;
        spriteRender.sprite = gameItem.itemSprite;
        itemType = gameItem.itemType;
    }

    void Start() {
        if(_inventoryManager == null) {
            _inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        }
        itemCanBeAdded = true;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            itemCanBeAdded = _inventoryManager.AddItem(itemName, spriteRender.sprite, itemDescription, itemType, gameItem);
            if(itemCanBeAdded) {
                Destroy(gameObject);
            }
            else return; 
        }
    }

    public void ValidateItem() {
        this.name = gameItem.itemName;
        itemName = gameItem.itemName;
        itemDescription = gameItem.itemDescription;
        itemType = gameItem.itemType;   
    }
}
