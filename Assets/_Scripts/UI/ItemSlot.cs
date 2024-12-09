using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerClickHandler {
    /* Data of each Item*/
    //change back to private after changes are made
    [SerializeField] private string itemName;
    [SerializeField] private Sprite _itemSprite;
    [SerializeField] private string _itemDescription;
    [SerializeField] private ItemType _itemType;
    [SerializeField] private GameItem _gameItem;
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
    public Image ItemDescriptionImage;

    void Awake() {
        if(_inventoryManager == null)
            _inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();

        if(ItemDescriptionNameText == null) {
            ItemDescriptionNameText = GameObject.Find("ItemDescriptionNameText").GetComponent<TMP_Text>();
        }
        if(ItemDescriptionText == null) {
            ItemDescriptionText = GameObject.Find("ItemDescriptionText").GetComponent<TMP_Text>();
        }
        if(ItemDescriptionImage == null) {
            ItemDescriptionImage = GameObject.Find("ItemDescriptionImage").GetComponent<Image>();
        }
        
        selectedShader.SetActive(false);
        selectionPanel.SetActive(false);
    }

    public void AddItem(string itemName, Sprite itemSprite, string itemDescription, ItemType itemType, GameItem gameItem) {
        this.itemName = itemName;
        _itemSprite = itemSprite;
        _itemDescription = itemDescription;
        _itemImage.sprite = itemSprite;
        _gameItem = gameItem;
        hasItem = true;
        _itemType = itemType;
    }

    public void EquipGear() {
        if(_itemType == ItemType.headArmor) {
            _inventoryManager.HeadArmorSlot.EquipGear(itemName, _itemSprite, _itemDescription, _gameItem);
        }
        if(_itemType == ItemType.bodyArmor) {
            _inventoryManager.BodyArmorSlot.EquipGear(itemName, _itemSprite, _itemDescription, _gameItem);
        }
        if(_itemType == ItemType.legArmor) {
            _inventoryManager.LegArmorSlot.EquipGear(itemName, _itemSprite, _itemDescription, _gameItem);
        }
        if(_itemType == ItemType.weapon) {
            _inventoryManager.WeaponSlot.EquipGear(itemName, _itemSprite, _itemDescription, _gameItem);
        }

        EmptySlot();
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
            DisplayItemDescriptions();
            if(ItemDescriptionImage.sprite == null) {
                ItemDescriptionImage.sprite = emptySprite;
            }
        }
    }
    
    public void OnRightClick() {
        if(hasItem) {
            _inventoryManager.DeselectAllSlots();
            selectedShader.SetActive(true);
            selectionPanel.SetActive(true);
            currentItemSelected = true;
            DisplayItemDescriptions();
        }
    }

    public void UseButtonClicked() {
        
        if(_itemType != ItemType.consumable) {
            EquipGear();
        }
        else {
            _inventoryManager.UseItem(itemName);
        }

        EmptySlot();
    }

    private void DiscardButtonClicked() {
        GameObject itemToDrop = new GameObject(itemName);
        SpriteRenderer sr = itemToDrop.AddComponent<SpriteRenderer>();
        Item newItem = itemToDrop.AddComponent<Item>();
        newItem.gameItem = _gameItem;
        sr.sprite = _gameItem.itemSprite;
        newItem.name = _gameItem.itemName;
        newItem.itemName = _gameItem.itemName;
        newItem.spriteRender = sr;
        newItem.itemDescription = _gameItem.itemDescription;
        newItem.itemType = _gameItem.itemType;

        sr.sortingOrder = 0;
        sr.sortingLayerName = "Interactables";
        itemToDrop.AddComponent<BoxCollider2D>().isTrigger = true;
        
        itemToDrop.transform.position = GameObject.FindWithTag("Player").transform.position + new Vector3(1f, 0.5f, 0);

        EmptySlot();
    }

    private void DisplayItemDescriptions() {
        ItemDescriptionNameText.text = itemName;
        ItemDescriptionText.text = _itemDescription;
        ItemDescriptionImage.sprite = _itemSprite;
    }

    public void EmptySlot() {
        itemName = "";
        _itemImage.sprite = emptySprite;
        ItemDescriptionNameText.text = "";
        ItemDescriptionText.text = "";
        ItemDescriptionImage.sprite = emptySprite;
        hasItem = false;
        selectionPanel.SetActive(false);
        selectedShader.SetActive(false);
    }
}
