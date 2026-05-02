using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemManager : MonoBehaviour, IService
{
    [SerializeField] private List<UpgradeItem> upgrades;
    [SerializeField] private PlayerCharacteristics characteristic;

    public PlayerCharacteristics GetPlayerCharacteristics => characteristic;

    public void AddUpgrade(UpgradeItem item)
    {
        upgrades.Add(item);
        Recalculate();
    }
    public void RemoveUpgrade()
    {
        upgrades.RemoveAt(upgrades.Count-1);
        Recalculate();
    }
    [ContextMenu("Recalculate")]
    public void Recalculate()
    {
        characteristic = new PlayerCharacteristics();

        foreach(UpgradeItem item in upgrades)
        {
            characteristic.strength += item.strength;
            characteristic.speed += item.speed;
            characteristic.length += item.length;
            characteristic.cooldown += item.cooldown;
        }
    }
    public void Execute()
    {
        Recalculate();
    }
}


[System.Serializable]
public class PlayerCharacteristics
{
    public float  strength;
    public float speed;
    public float length;
    public float cooldown;
}
