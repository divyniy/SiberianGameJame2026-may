using System.Collections;
using UnityEngine;

public class Zone : MonoBehaviour
{
    [SerializeField] private float timeAlive;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
    }
    private void Start()
    {
        StartCoroutine(DestroyGameObject());
    }
    private IEnumerator DestroyGameObject()
    {
        yield return new WaitForSeconds(timeAlive);
        Destroy(gameObject);
    }
    private void OnTriggerStay(Collider other)
    {
        if(timer > 0.5f)
        {
            if(other.GetComponent<IDamagable>()!=null)
            {
                if(other.tag != "Player")
                other.GetComponent<IDamagable>().TakeDamage(3);
            }
            timer = 0;
        }
    }
}
