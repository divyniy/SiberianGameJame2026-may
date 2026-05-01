using System.Collections;
using UnityEngine;

public class ArrowProjectile : MonoBehaviour, IProjectile
{
    private Transform target;
    private Transform sender;
    private float damage;

    public void Setup(Transform target, Transform sender)
    {
        this.target = target;
        this.sender = sender;

        if(target == null) Destroy(gameObject);
        transform.LookAt(target);
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
                StartCoroutine(TakeDamageAfterSeconds(1, other.gameObject.GetComponent<IDamagable>()));
            }
        }
    }
    private IEnumerator TakeDamageAfterSeconds(float timer, IDamagable damagable)
    {
        yield return new WaitForSeconds(timer);
        damagable.TakeDamage((int)damage);
    }
}

