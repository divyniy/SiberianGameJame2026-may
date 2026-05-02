using UnityEngine;

public class TradeChest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(ServiceLocator.Get<Player>().health.health > 4) return;

            ServiceLocator.Get<ItemManager>().RemoveUpgrade();
            ServiceLocator.Get<Player>().TakeDamage(-1);

            Destroy(gameObject);
        }
    }
}
