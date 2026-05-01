using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VirusZone", menuName = "Сustom/Abilites/VirusZone")]
public class VirusZone : Ability
{
    public float distance;

    public override void Activate()
    {
        List<Transform> a = ServiceLocator.Get<EnemyManager>().GetEnemyInDistance(distance);
        
        if (a.Count <= 0) return;

        foreach(Transform z in a)
        {
            if(z.GetComponent<IEnemy>() != null)
            {
                z.GetComponent<IEnemy>().health.TakeDamage(damage);
            }
        }
    }
}
