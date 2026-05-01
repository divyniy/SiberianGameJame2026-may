using UnityEngine;

public class Player : MonoBehaviour, IService, IDamagable
{
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform body;
    private PlayerMovmentComponent mover;
    public HealthComponent health {get;set;}

    public void TakeDamage(float damage)
    {
        health.TakeDamage(damage);
    }
    public void Die()
    {
        
    }
    public Vector3 GetForward()
    {
        return body.forward;
    }
    private void FixedUpdate()
    {
        mover.FixedUpdate();
    }
    public void Execute()
    {
        mover = new PlayerMovmentComponent(transform, GetComponent<Rigidbody>(), orientation, body);
        health = new HealthComponent(Resources.Load<PlayerConfig>("PlayerConfig").health);
        health.onDeath += Die;
    }
}
