using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    [SerializeField] private string _itemName;
    [SerializeField] private Sprite _sprite;
    [TextArea][SerializeField] private string _itemDescription;

    private InventoryManager _inventoryManager;

    void Start() {
        _inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            _inventoryManager.AddItem(_itemName, _sprite, _itemDescription);
            Destroy(gameObject);
        }
    }
}
