using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IEnemy, IDamagable
{   
    [SerializeField] private EnemyConfig config;
    public EnemyMover mover {get; set;}
    public HealthComponent health {get;set;}

    float currentSpeed;

    private bool isMoving = true;

    public void Execute()
    {
        health = new HealthComponent(config.health);
        mover = new EnemyMover(GetComponent<NavMeshAgent>(), config);
        currentSpeed = config.speed;

        health.onDeath += Die;
    }
    private void Die()
    {
        health.onDeath -= Die;

        if(gameObject != null) Destroy(this.gameObject);
    }
    public void ChangeSpeed(float percents)
    {
        currentSpeed = config.speed -  percents/10 * config.speed ;
    }
    private void Update()
    {
        if(isMoving) mover.Update(currentSpeed); 
        Debug.Log(currentSpeed);
    }

    public void ToogleFollowing(bool flag)
    {
       isMoving = flag;
       GetComponent<NavMeshAgent>().enabled = flag;
    }
}

public class EnemyMover
{
    private NavMeshAgent agent;
    private Vector3 point => ServiceLocator.Get<Player>().transform.position;
    public EnemyMover(NavMeshAgent agent, EnemyConfig config)
    {
        this.agent = agent;
        agent.speed = config.speed;
    }

    public void Update(float speed)
    {
        agent.speed = speed;
        agent.destination = point;
    }
}

public interface IEnemy
{
    public EnemyMover mover {get; set;}
    public HealthComponent health {get;set;}
    public void ChangeSpeed(float percents);
    public void Execute();
    public void ToogleFollowing(bool flag);
}