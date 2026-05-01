using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Сustom/Items/Boost")]
public class UpgradeItem : ScriptableObject
{
    public string upgradeItemName;

    public float strength;
    public float speed;
    public float length;
    public float cooldown;
}
