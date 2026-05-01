using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform target;
    private Transform sender;
    private float damage;

    public void Setup(Transform target, Transform sender)
    {
        this.target = target;
        this.sender = sender;
    }
    
    private void Update()
    {
        if(target == null) Destroy(gameObject);

        float step = 15 * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform != sender)
        {
            if(other.GetComponent<IDamagable>() != null)
            {
                other.GetComponent<IDamagable>().TakeDamage((int)damage);
                Destroy(this.gameObject);
            }
        }
    }
}
