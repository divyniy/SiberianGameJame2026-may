using UnityEngine;

public class DummyEnemy : MonoBehaviour
{
    [SerializeField] private EnemyConfig config;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 7)
        {
            other.GetComponent<Player>().TakeDamage(config.damage);
            Destroy(this.gameObject);
        }
    }
}
