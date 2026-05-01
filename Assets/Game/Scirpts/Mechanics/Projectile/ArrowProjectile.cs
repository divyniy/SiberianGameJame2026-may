using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowProjectile : MonoBehaviour, IProjectile
{
    private Transform target;
    private Transform sender;
    [SerializeField] private float damage;

    public void Setup(Transform target, Transform sender)
    {
        this.target = target;
        this.sender = sender;

        if(target == null) Destroy(gameObject);
        transform.LookAt(target);
        StartCoroutine(Die());
    }
    
    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * 15;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Player")
        {
            if(other.GetComponent<IDamagable>() != null)
            {
                StartCoroutine(TakeDamageAfterSeconds(1, other.gameObject));
            }
        }
    }
    private IEnumerator TakeDamageAfterSeconds(float timer, GameObject obj)
    {
        yield return new WaitForSeconds(timer);
        if(obj != null)
        obj.GetComponent<IDamagable>().TakeDamage((int)damage);
    }
    private IEnumerator Die()
    {
        yield return new WaitForSeconds(15);
        Destroy(gameObject);
    }
}

