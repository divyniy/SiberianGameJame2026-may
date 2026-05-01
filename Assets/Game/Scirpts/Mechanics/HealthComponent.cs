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
    public void TakeDamage(float damage)
    {
        health -= (int)damage;
        if(health<=0)
        onDeath?.Invoke();
    }
}

public interface IDamagable
{
    public HealthComponent health {get;set;}

    public void TakeDamage(int damage)
    {
        health.TakeDamage(damage);
    }
    
}
