using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IEnemy, IDamagable
{   
    [SerializeField] private EnemyConfig config;
    public EnemyMover mover {get; set;}
    public HealthComponent health {get;set;}

    private bool isMoving = true;

    public void Execute()
    {
        health = new HealthComponent(config.health);
        mover = new EnemyMover(GetComponent<NavMeshAgent>(), config);

        health.onDeath += Die;
    }
    private void Die()
    {
        health.onDeath -= Die;

        if(gameObject != null) Destroy(this.gameObject);
    }
    private void Update()
    {
        if(isMoving) mover.Update();
    }

    public void ToogleFollowing(bool flag)
    {
       isMoving = flag;
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

    public void Update()
    {
        agent.destination = point;
    }
}

public interface IEnemy
{
    public EnemyMover mover {get; set;}
    public HealthComponent health {get;set;}
    public void Execute();
    public void ToogleFollowing(bool flag);
}