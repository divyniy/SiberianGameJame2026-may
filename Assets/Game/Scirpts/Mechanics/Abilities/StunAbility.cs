using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StunAbility", menuName = "Сustom/Abilites/StunAbility")]
public class StunAbility : Ability
{
    public float radius;
    public float stunTime;

    public override void Activate()
    {
        List<Transform> objects = ServiceLocator.Get<EnemyManager>().GetEnemyInDistance(radius);
        if(objects.Count <= 0) return;
        
        Transform a = objects[Random.Range(0, objects.Count)];
        ServiceLocator.Get<EnemyManager>().StartCoroutine(ServiceLocator.Get<EnemyManager>().Stun(stunTime,a));
        Debug.Log(a);
    }
}
