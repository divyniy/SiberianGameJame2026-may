using System.Collections;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private ChestDrop[] drops;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ServiceLocator.Get<ItemManager>().AddUpgrade(DropItem().item);
            StartCoroutine(OpenChest());
        }
    }
    private IEnumerator OpenChest()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
    private ChestDrop DropItem()
    {
        float totalWeight = 0;

        foreach(ChestDrop a in drops)
        {
            totalWeight += a.weight;
        }
        float random = Random.Range(0, totalWeight);

        foreach(ChestDrop drop in drops)
        {
            if(random <= drop.weight)
            {
                return drop;
            }
            random -= drop.weight;
        }
        return null;
    }
}
[System.Serializable]
public class ChestDrop
{
    public UpgradeItem item;
    public int weight;
}
