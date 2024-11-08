using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerClickHandler {
    /* Data of each Item*/
    private string _itemName;
    private Sprite _itemSprite;
    private string _itemDescription;
    public bool isFull;

    /* Data of each Item Slot*/
    [SerializeField] private Image _itemImage;
    public GameObject selectedShader;
    public bool currentItemSelected;
    public Sprite emptySprite;
    private InventoryManager _inventoryManager;

    /* Description of each Item Slot*/
    public Image itemDescriptionImage;
    public TMP_Text ItemDescriptionNameText;
    public TMP_Text ItemDescriptionText;

    void Start() {
        _inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    public void AddItem(string itemName, Sprite itemSprite, string itemDescription) {
        _itemName = itemName;
        _itemSprite = itemSprite;
        _itemDescription = itemDescription;
        isFull = true;
        _itemImage.sprite = itemSprite;
    }

    public void OnPointerClick(PointerEventData eventData) {
        if(eventData.button == PointerEventData.InputButton.Left) {
            OnLeftClick();
        }
        if(eventData.button == PointerEventData.InputButton.Right) {
            OnRightClick();
        }
    }

    public void OnLeftClick() {
        _inventoryManager.DeselectAllSlots(); 
        selectedShader.SetActive(true);
        currentItemSelected = true;
        ItemDescriptionNameText.text = _itemName;
        ItemDescriptionText.text = _itemDescription;
        itemDescriptionImage.sprite = _itemSprite;
        if(itemDescriptionImage.sprite == null) {
            itemDescriptionImage.sprite = emptySprite;
        }
    }
    
    public void OnRightClick() {
        return;
    }
}
