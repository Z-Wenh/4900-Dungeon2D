using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public string itemName;
    public Sprite sprite;
    [TextArea] public string itemDescription;
    public bool itemCanBeAdded;

    private InventoryManager _inventoryManager;
    public ItemType itemType;

    void Start() {
        _inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        itemCanBeAdded = true;
        sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            itemCanBeAdded = _inventoryManager.AddItem(itemName, sprite, itemDescription, itemType);
            if(itemCanBeAdded) {
                Destroy(gameObject);
            }
            else return; 
        }
    }
}
