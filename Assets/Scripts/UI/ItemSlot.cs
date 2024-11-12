using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerClickHandler {
    /* Data of each Item*/
    //change back to private after changes are made
    public string _itemName;
    private Sprite _itemSprite;
    private string _itemDescription;
    public bool hasItem;

    /* Data of each Item Slot*/
    [SerializeField] private Image _itemImage;
    public GameObject selectedShader;
    public GameObject selectionPanel;
    public bool currentItemSelected;
    public Sprite emptySprite;
    private InventoryManager _inventoryManager;

    /* Description of each Item Slot*/
    public TMP_Text ItemDescriptionNameText;
    public TMP_Text ItemDescriptionText;
    public Image itemDescriptionImage;

    void Awake() {
        _inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        selectedShader.SetActive(false);
        selectionPanel.SetActive(false);
    }

    public void AddItem(string itemName, Sprite itemSprite, string itemDescription) {
        _itemName = itemName;
        _itemSprite = itemSprite;
        _itemDescription = itemDescription;
        hasItem = true;
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
        if(hasItem) {
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
    }
    
    public void OnRightClick() {
        if(hasItem) {
            _inventoryManager.DeselectAllSlots();
            selectedShader.SetActive(true);
            selectionPanel.SetActive(true);
            currentItemSelected = true;
        }
    }

    public void UseButtonClicked() {
        _inventoryManager.UseItem(_itemName);
        Debug.Log(_itemName + " IS USED");
        EmptySlot();
    }

    public void DiscardButtonClicked() {
        return;
    }

    public void EmptySlot() {
        _itemName = "";
        _itemImage.sprite = emptySprite;
        ItemDescriptionNameText.text = "";
        ItemDescriptionText.text = "";
        itemDescriptionImage.sprite = emptySprite;
        hasItem = false;
        selectionPanel.SetActive(false);
    }
}
