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
    public string itemName;
    private Sprite _itemSprite;
    private string _itemDescription;
    public bool hasItem;
    public ItemType itemType;

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

    public void AddItem(string itemName, Sprite itemSprite, string itemDescription, ItemType itemType) {
        this.itemName = itemName;
        _itemSprite = itemSprite;
        _itemDescription = itemDescription;
        _itemImage.sprite = itemSprite;
        hasItem = true;
        this.itemType = itemType;
    }

    public void EquipGear() {
        if(itemType == ItemType.headArmor) {
            _inventoryManager.HeadArmorSlot.EquipGear(itemName, _itemSprite, _itemDescription);
        }
        if(itemType == ItemType.bodyArmor) {
            _inventoryManager.BodyArmorSlot.EquipGear(itemName, _itemSprite, _itemDescription);
        }
        if(itemType == ItemType.legArmor) {
            _inventoryManager.LegArmorSlot.EquipGear(itemName, _itemSprite, _itemDescription);
        }
        if(itemType == ItemType.weapon) {
            _inventoryManager.WeaponSlot.EquipGear(itemName, _itemSprite, _itemDescription);
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
            ItemDescriptionNameText.text = itemName;
            ItemDescriptionText.text = _itemDescription;
            ItemDescriptionImage.sprite = _itemSprite;
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
        }
    }

    public void UseButtonClicked() {
        
        if(itemType != ItemType.consumable) {
            EquipGear();
            Debug.Log(itemName + " IS EQUIPPED");
        }
        else {
            _inventoryManager.UseItem(itemName);
            Debug.Log(itemName + " IS USED");
        }

        EmptySlot();
    }

    public void DiscardButtonClicked() {
        GameObject itemToDrop = new GameObject(itemName);
        Item newItem = itemToDrop.AddComponent<Item>();
        newItem.itemName = itemName;
        newItem.spriteRender.sprite = _itemSprite;
        newItem.itemDescription = _itemDescription;
        newItem.itemType = itemType;

        SpriteRenderer sr = itemToDrop.AddComponent<SpriteRenderer>();
        sr.sprite = _itemSprite;
        sr.sortingOrder = 0;
        sr.sortingLayerName = "Interactables";

        itemToDrop.AddComponent<BoxCollider2D>().isTrigger = true;
        
        itemToDrop.transform.position = GameObject.FindWithTag("Player").transform.position + new Vector3(1f, 0.5f, 0);

        EmptySlot();
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
