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
    public Image itemDescriptionImage;

    void Awake() {
        _inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
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
        _inventoryManager.UseItem(itemName);
        
        if(itemType != ItemType.consumable) {
            EquipGear();
            Debug.Log(itemName + " IS EQUIPPED");
        }

        Debug.Log(itemName + " IS USED");
        EmptySlot();
    }

    public void DiscardButtonClicked() {
        GameObject itemToDrop = new GameObject(itemName);
        Item newItem = itemToDrop.AddComponent<Item>();
        newItem.itemName = itemName;
        newItem.sprite = _itemSprite;
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
        itemDescriptionImage.sprite = emptySprite;
        hasItem = false;
        selectionPanel.SetActive(false);
        selectedShader.SetActive(false);
    }
}
