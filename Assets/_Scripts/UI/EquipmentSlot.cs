using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class EquipmentSlot : MonoBehaviour, IPointerClickHandler {
    /*Data pertaining to each equipment slot*/
    [SerializeField] private Image _slotImage;
    [SerializeField] private TMP_Text _slotName;
    [SerializeField] private ItemType _itemType = new ItemType();

    /*Data pertaining to each item in an equipment slot*/
    private Sprite _itemSprite;
    private string _itemName;
    private string _itemDescription;
    [SerializeField] private bool _slotInUse;

    public GameObject _selectedShader;
    public bool _thisItemSelected;
    [SerializeField] private Sprite _emptySprite;
    [SerializeField] private InventoryManager _inventoryManager;
    [SerializeField] private TMP_Text _ItemDescriptionNameText;
    [SerializeField] private TMP_Text _ItemDescriptionText;
    [SerializeField] private Image _ItemDescriptionImage;
    
    void Start() {
        _inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        _slotInUse = false;
        _thisItemSelected = false;
        _ItemDescriptionImage = GameObject.Find("ItemDescriptionImage").GetComponent<Image>();
        _ItemDescriptionNameText = GameObject.Find("ItemDescriptionNameText").GetComponent<TMP_Text>();
        _ItemDescriptionText = GameObject.Find("ItemDescriptionText").GetComponent<TMP_Text>();
    }

    public void EquipGear(string itemName, Sprite itemSprite, string itemDescription) {
        if(_slotInUse) {
            UnequipGear();
        }
        
        _inventoryManager.EquipGear(itemName);
        _itemSprite = itemSprite;
        _slotImage.sprite = itemSprite;
        _slotName.enabled = false;

        _itemName = itemName;
        _itemDescription = itemDescription;
        _slotInUse = true;
    }

    public void OnPointerClick(PointerEventData eventData) {
        if(eventData.button == PointerEventData.InputButton.Left) {
            OnLeftClick();
        }
        if(eventData.button == PointerEventData.InputButton.Right) {
            OnRightClick();
        }
    }

    void OnLeftClick() {
        if(_thisItemSelected && _slotInUse) {
            UnequipGear();
        }
        else if(_slotInUse) {
            _inventoryManager.DeselectAllSlots();
            _selectedShader.SetActive(true);
            _thisItemSelected = true;
            _ItemDescriptionImage.sprite = _itemSprite;
            _ItemDescriptionNameText.text = _itemName;
            _ItemDescriptionText.text = _itemDescription;
        }
    }

    void OnRightClick() {
        if(_slotInUse)
            UnequipGear();
    }

    public void UnequipGear() {
        _inventoryManager.UnEquipGear(_itemName);
        _inventoryManager.DeselectAllSlots();
        _inventoryManager.AddItem(_itemName, _itemSprite, _itemDescription, _itemType);
        
        _itemSprite = _emptySprite;
        _slotImage.sprite = this._emptySprite;
        _slotName.enabled = true;
        _slotInUse = false;
    }
}
