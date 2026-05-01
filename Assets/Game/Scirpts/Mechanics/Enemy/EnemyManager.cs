using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour, IService
{
    [SerializeField] private GameObject[] enemiesList;
    [SerializeField] private List<IEnemy> createdEnemies = new List<IEnemy>();
    [SerializeField] private Transform player;
    [SerializeField] private float radius;

    private Vector3 lastPos;
    
    private void Start()
    {
        Execute();
    }

    public void Spawn(int amount = 1)
    {
        for(int i = 1; i < amount+1; i++)
        {
            float angle = i * 2 * Mathf.PI / amount;

            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;

            lastPos = player.position + new Vector3(x,0,z);
            GameObject enemy = Instantiate(enemiesList[Random.Range(0, enemiesList.Length)], lastPos, Quaternion.identity);

            enemy.GetComponent<IEnemy>().Execute();
            createdEnemies.Add(enemy.GetComponent<IEnemy>());
        }
    }

    public void Execute()
    {
        Spawn(25);
    }
}
