using UnityEngine;

public class ChunkController : MonoBehaviour, IService
{
    private Vector3 lastPosition;
    [SerializeField] private Transform player;
    [SerializeField] private float distanceToUpdate;

    Bounds bounds;

    public void Execute()
    {
        lastPosition = player.transform.position;
        bounds = GetComponent<MeshRenderer>().bounds;
    }
    private void Update()
    {
        UpdateChunck();
    }
    private void UpdateChunck()
    {
        if(Vector3.Distance(player.transform.position, lastPosition) > distanceToUpdate)
        {
            lastPosition = player.transform.position;
            transform.position = new Vector3(player.transform.position.x, 0, player.transform.position.z);
        }
    }
}
