using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "GameItem")]
public class GameItem : ScriptableObject {
    public string itemName;
    public Sprite itemSprite;
    public StatToChange statToChange = new StatToChange();
    public AttributeToChange attributeToChange = new AttributeToChange();
    public int statChangeAmount;
    public int attributeChangeAmount;
    public bool UsableItem;
    public bool EquipableItem;
    [TextArea] public string itemDescription;
    public ItemType itemType;
    
    public void UseItem() {
        if(statToChange == StatToChange.health) {
            GameObject.Find("Player").GetComponent<EntityStatus>().AddHealth(statChangeAmount);
        }
        if(statToChange == StatToChange.experience) {
            GameObject.FindGameObjectWithTag("ExperienceHUD").GetComponent<ExperienceController>().IncreaseExp(statChangeAmount);
        }
        if(attributeToChange == AttributeToChange.damage) {
            GameObject.Find("Player").GetComponent<PlayerAttack>().IncreaseAttackDamage(attributeChangeAmount);
        }
        if(attributeToChange == AttributeToChange.defense) {
            GameObject.Find("Player").GetComponent<EntityStatus>().IncreaseDefense(attributeChangeAmount);
        }
    }

    public void EquipCurrentGear() {
        if(attributeToChange == AttributeToChange.damage) {
            GameObject.Find("Player").GetComponent<PlayerAttack>().IncreaseAttackDamage(attributeChangeAmount);
        }
        if(attributeToChange == AttributeToChange.defense) {
            GameObject.Find("Player").GetComponent<EntityStatus>().IncreaseDefense(attributeChangeAmount);
        }
        if(attributeToChange == AttributeToChange.maxHealth) {
            GameObject.Find("Player").GetComponent<EntityStatus>().AddMaxHealth(attributeChangeAmount);
        }
    }

    public void UnEquipCurrentGear() {
        if(attributeToChange == AttributeToChange.damage) {
            GameObject.Find("Player").GetComponent<PlayerAttack>().IncreaseAttackDamage(-attributeChangeAmount);
        }
        if(attributeToChange == AttributeToChange.defense) {
            GameObject.Find("Player").GetComponent<EntityStatus>().IncreaseDefense(-attributeChangeAmount);
        }
        if(attributeToChange == AttributeToChange.maxHealth) {
            GameObject.Find("Player").GetComponent<EntityStatus>().AddMaxHealth(-attributeChangeAmount);
        }
    }

    public enum StatToChange {
        none,
        health,
        experience,
    };

    public enum AttributeToChange {
        none,
        damage,
        defense,
        maxHealth
    };

}
