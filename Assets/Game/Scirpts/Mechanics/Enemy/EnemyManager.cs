using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour, IService
{
    [SerializeField] private GameObject[] enemiesList;
    [SerializeField] private List<GameObject> createdEnemies = new List<GameObject>();
    [SerializeField] private Transform player;
    //[SerializeField] private float radius;

    private Vector3 lastPos;
    
    public void Spawn(int amount = 1, float radius = 5)
    {
        for(int i = 1; i < amount+1; i++)
        {
            float angle = i * 2 * Mathf.PI / amount;

            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;

            lastPos = player.position + new Vector3(x,0,z);
            GameObject enemy = Instantiate(enemiesList[Random.Range(0, enemiesList.Length)], lastPos, Quaternion.identity);

            enemy.GetComponent<IEnemy>().Execute();
            createdEnemies.Add(enemy);
        }
    }

    public void Execute()
    {
        
    }
    public GameObject GetRandomEnemy()
    {
        return createdEnemies[Random.Range(0, createdEnemies.Count)];
    } 
    public Transform GetClosestEnemyToTransform()
    {
       return createdEnemies.Where(x => x != null).OrderByDescending(x => (x.transform.position - transform.position).sqrMagnitude).FirstOrDefault()?.transform;
    }
    public List<Transform> GetEnemyInDistance(float distance)
    {
        return createdEnemies.Where(x => x != null && Vector3.Distance(x.transform.position, player.position) < distance).Select(x => x.transform).ToList();
    }
    public IEnumerator Stun(float timer, Transform a)
    {
        IEnemy enemy = a.GetComponent<IEnemy>();

        a.GetComponent<Rigidbody>().isKinematic = true;
        a.GetComponent<MeshRenderer>().material.color = Color.red;
        enemy.ToogleFollowing(false);

        yield return new WaitForSeconds(timer);

        if(enemy==null) yield return null; 

        a.GetComponent<MeshRenderer>().material.color = Color.white;
        a.GetComponent<Rigidbody>().isKinematic = false;
        enemy.ToogleFollowing(true);
    }
}
