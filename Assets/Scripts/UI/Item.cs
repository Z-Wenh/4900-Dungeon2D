using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    [SerializeField] private string _itemName;
    [SerializeField] private Sprite _sprite;
    [TextArea][SerializeField] private string _itemDescription;
    public bool itemCanBeAdded;

    private InventoryManager _inventoryManager;

    void Start() {
        _inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        itemCanBeAdded = true;
        _sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            itemCanBeAdded = _inventoryManager.AddItem(_itemName, _sprite, _itemDescription);
            if(itemCanBeAdded) {
                Destroy(gameObject);
            }
            else return; 
        }
    }
}
