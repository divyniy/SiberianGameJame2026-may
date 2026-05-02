using System.Collections;
using UnityEngine;

public class ChunkController : MonoBehaviour, IService
{
    [Header("References")]
    [SerializeField] private GameObject chestPrafab;
    [SerializeField] private GameObject tradePrefab;
    private Vector3 lastPosition;
    [SerializeField] private Transform player;

    [Header("Variables")]
    [SerializeField] private float distanceToUpdate;
    
    [SerializeField] private float minRange;
    [SerializeField] private float maxRange;

    Bounds bounds;

    public void Execute()
    {
        lastPosition = player.transform.position;
        bounds = GetComponent<MeshRenderer>().bounds;

        StartCoroutine(StartSpawn(chestPrafab));
        StartCoroutine(StartSpawn(tradePrefab));
    }
    private IEnumerator StartSpawn(GameObject prefab)
    {
        yield return new WaitForSeconds(Random.Range(25, 75));
        
        Spawn(1, prefab);
        StartCoroutine(StartSpawn(prefab));
    }
    private void Update()
    {
        UpdateChunck();
    }
    private void FixedUpdate()
    {
        
    }
    private void UpdateChunck()
    {
        if(Vector3.Distance(player.transform.position, lastPosition) > distanceToUpdate)
        {
            lastPosition = player.transform.position;
            transform.position = new Vector3(player.transform.position.x, 0, player.transform.position.z);
        }
    }
    public void Spawn(int amount, GameObject prefab)
    {
        for(int i =0; i<amount; i++)
        {
            float difX = Random.value > 0.5 ? 1 : -1; 
            float difY = Random.value > 0.5 ? 1 : -1; 

            float randomX = Random.Range(minRange, maxRange) * difX;
            float randomY = Random.Range(minRange, maxRange) * difY;

            Vector3 pos = new Vector3(player.transform.position.x + randomX, player.transform.position.y, player.transform.position.z + randomY);

            Instantiate(prefab, pos, Quaternion.identity);
        }
        
    }
}
