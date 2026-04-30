using UnityEngine;

public class Player : MonoBehaviour, IService, IDamagable
{
    private PlayerMovmentComponent mover;
    public HealthComponent health {get;set;}

    private void Start()
    {
        Execute();

        
    }
    private void FixedUpdate()
    {
        mover.FixedUpdate();
    }
    public void Execute()
    {
        mover = new PlayerMovmentComponent(transform, GetComponent<Rigidbody>());
        health = new HealthComponent(100);
    }
}
