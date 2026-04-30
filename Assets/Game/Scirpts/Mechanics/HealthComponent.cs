using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class HealthComponent
{
    public int health;
    public UnityAction onDeath;


    public HealthComponent(int startHealth)
    {
        health = startHealth;
    }
    public void Hit(int damage)
    {
        health -= damage;
        onDeath?.Invoke();
    }
}

public interface IDamagable
{
    public HealthComponent health {get;set;}
}
