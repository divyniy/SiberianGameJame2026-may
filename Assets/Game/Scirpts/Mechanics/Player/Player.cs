using UnityEngine;

public class Player : MonoBehaviour, IService, IDamagable
{
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform body;
    private PlayerMovmentComponent mover;
    public HealthComponent health {get;set;}

    // private void Start()
    // {
    //     Execute();
    // }
    public void TakeDamage(float damage)
    {
        health.TakeDamage(damage);
    }
    public void Die()
    {
        
    }
    private void FixedUpdate()
    {
        mover.FixedUpdate();
    }
    public void Execute()
    {
        mover = new PlayerMovmentComponent(transform, GetComponent<Rigidbody>(), orientation, body);
        health = new HealthComponent(100);
        health.onDeath += Die;
    }
}
