using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour {
    private string _itemName;
    private Sprite _itemSprite;
    private bool _isFull;

    [SerializeField] private Image _itemImage;

    public void AddItem(string itemName, Sprite itemSprite) {
        _itemName = itemName;
        _itemSprite = itemSprite;
        _isFull = true;
        _itemImage.sprite = itemSprite;
    }
}
