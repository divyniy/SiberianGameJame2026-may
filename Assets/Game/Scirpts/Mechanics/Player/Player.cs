using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IService, IDamagable
{
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform body;

    private PlayerCharacteristics characteristics => ServiceLocator.Get<ItemManager>().GetPlayerCharacteristics;
    private PlayerMovmentComponent mover;
    public HealthComponent health {get;set;}
    public bool hasShield {get; private set;}

    private float speed;
    private float speedMultiplayer = 0;
    public static UnityAction onHit;

    public void TakeDamage(float damage)
    {
        if(hasShield) 
        { 
            SetShield(false); return;
        }
        
        health.TakeDamage(damage);
        onHit?.Invoke();
    }
    public void Die()
    {
        SceneManagerManager.ChangeScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void SetShield(bool flag)
    {
        hasShield = flag;
    }

    public void SetSpeed(float percents)
    {
       speedMultiplayer = percents/10 * (Resources.Load<PlayerConfig>("PlayerConfig").speed + characteristics.speed);
    }
    public Vector3 GetForward()
    {
        return body.forward;
    }
    private void FixedUpdate()
    {
        mover.FixedUpdate(Resources.Load<PlayerConfig>("PlayerConfig").speed + characteristics.speed - speedMultiplayer);
    }
    public void Execute()
    {
        mover = new PlayerMovmentComponent(transform, GetComponent<Rigidbody>(), orientation, body);
        health = new HealthComponent(Resources.Load<PlayerConfig>("PlayerConfig").health);
        speed = Resources.Load<PlayerConfig>("PlayerConfig").speed + characteristics.speed;

        hasShield = false;
        health.onDeath += Die;
    }
}
