using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public int cooldown;
    public int damage;

    public abstract void Activate();
}