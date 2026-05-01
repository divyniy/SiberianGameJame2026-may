using UnityEngine;

public class SmokeProjectile : MonoBehaviour, IProjectile
{
    [SerializeField] private GameObject zone;
    private Transform target;
    private Transform sender;
    private float damage;
    private float timer;

    public void Setup(Transform target, Transform sender)
    {
        this.target = target;
        this.sender = sender;

        if(target == null) Destroy(gameObject);
    }
    
    private void Update()
    {
        timer += Time.deltaTime;

        if(timer > 0.05f)
        {
            Instantiate(zone, transform.position, Quaternion.identity);
            Debug.Log("test");
            timer = 0;
        }

        float step = 15 * Time.deltaTime;
        if(transform != null && target != null) transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform != sender)
        {
            if(other.GetComponent<IDamagable>() != null)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
