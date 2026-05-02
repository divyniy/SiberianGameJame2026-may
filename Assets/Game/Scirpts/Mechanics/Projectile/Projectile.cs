using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour, IProjectile
{
    private Transform target;
    private Transform sender;
    [SerializeField] private float damage;

    public void Setup(Transform target, Transform sender)
    {
        this.target = target;
        this.sender = sender;

        if(target == null) Destroy(gameObject);
        damage += (int)ServiceLocator.Get<ItemManager>().GetPlayerCharacteristics.strength;

        transform.forward = ServiceLocator.Get<Player>().GetForward();
        StartCoroutine(Die());
    }
    
    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * 15;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform != sender)
        {
            if(other.GetComponent<IDamagable>() != null)
            {
                other.GetComponent<IDamagable>().TakeDamage(Mathf.RoundToInt(damage));
                Destroy(this.gameObject);
            }
        }
    }
    private IEnumerator Die()
    {
        yield return new WaitForSeconds(15);
        Destroy(gameObject);
    }
}

public interface IProjectile
{
    public void Setup(Transform target, Transform sender);
}