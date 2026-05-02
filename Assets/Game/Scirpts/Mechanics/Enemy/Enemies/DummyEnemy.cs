using UnityEngine;

public class DummyEnemy : MonoBehaviour
{
    [SerializeField] private EnemyConfig config;
    [SerializeField] private GameObject blood;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 7)
        {
            Instantiate(blood, transform.position, Quaternion.identity);
            other.GetComponent<Player>().TakeDamage(config.damage);
            Destroy(this.gameObject);
        }
    }
}
