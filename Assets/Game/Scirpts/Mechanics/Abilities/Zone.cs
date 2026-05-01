using UnityEngine;

public class Zone : MonoBehaviour
{
    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if(timer > 0.5f)
        {
            if(other.GetComponent<IDamagable>()!=null)
            {
                other.GetComponent<IDamagable>().TakeDamage(3);
            }
        }
    }
}
