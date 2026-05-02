using System;
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

        health -= Convert.ToInt16(damage);

        if(health<=0)
        {
            onDeath?.Invoke();
            health = 0;
        }
        
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
