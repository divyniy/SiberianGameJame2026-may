using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public float cooldown;
    public int damage;

    public abstract void Activate();
}