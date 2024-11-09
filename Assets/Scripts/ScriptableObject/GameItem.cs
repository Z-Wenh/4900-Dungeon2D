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

    public void UseItem() {
        if(statToChange == StatToChange.health) {
            GameObject.Find("Player").GetComponent<EntityStatus>().AddHealth(statChangeAmount);
        }
        if(statToChange == StatToChange.experience) {
            GameObject.Find("Player Experience Bar HUD").GetComponent<ExperienceController>().IncreaseExp(statChangeAmount);
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
        defense
    };

}