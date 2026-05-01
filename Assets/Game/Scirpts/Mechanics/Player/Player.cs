using NUnit.Framework;
using UnityEngine;

public class Player : MonoBehaviour, IService, IDamagable
{
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform body;
    private PlayerMovmentComponent mover;
    public HealthComponent health {get;set;}
    public bool hasShield {get; private set;}

    private float speed;
    private float speedMultiplayer;

    public void TakeDamage(float damage)
    {
        if(hasShield) { SetShield(false); return;}

        health.TakeDamage(damage);
    }
    public void Die()
    {
        
    }
    public void SetShield(bool flag)
    {
        hasShield = flag;
    }

    public void SetSpeed(float percents)
    {
       speedMultiplayer = percents/10 * Resources.Load<PlayerConfig>("PlayerConfig").speed;
    }
    public Vector3 GetForward()
    {
        return body.forward;
    }
    private void FixedUpdate()
    {
        mover.FixedUpdate(speed - speedMultiplayer);
    }
    public void Execute()
    {
        mover = new PlayerMovmentComponent(transform, GetComponent<Rigidbody>(), orientation, body);
        health = new HealthComponent(Resources.Load<PlayerConfig>("PlayerConfig").health);
        speed = Resources.Load<PlayerConfig>("PlayerConfig").speed;

        hasShield = false;
        health.onDeath += Die;
    }
}
