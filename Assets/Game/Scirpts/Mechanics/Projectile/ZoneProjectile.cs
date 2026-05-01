using UnityEngine;

public class ZoneProjectile : MonoBehaviour, IProjectile
{
    [SerializeField] private GameObject zone;

    private Transform target;
    private Transform sender;
    private float damage;

    public void Setup(Transform target, Transform sender)
    {
        this.target = target;
        this.sender = sender;
        Instantiate(zone, transform.position, Quaternion.identity);
        if(target == null) Destroy(gameObject);
    }
    
    private void Update()
    {
        if(target == null) Destroy(gameObject);

        float step = 15 * Time.deltaTime;
        if(transform != null && target != null) transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform != sender)
        {
            if(other.GetComponent<IDamagable>() != null)
            {
                other.GetComponent<IDamagable>().TakeDamage((int)damage);
                Instantiate(zone, other.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
