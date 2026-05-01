using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SlowingAbility", menuName = "Сustom/Abilites/SlowingZoneAbility")]
public class SlowingAbility : Ability
{
    public int percents;
    public float distance;
    public override void Activate()
    {
        List<Transform> a = ServiceLocator.Get<EnemyManager>().GetEnemyInDistance(distance);

        foreach(Transform i in a)
        {
            i.GetComponent<IEnemy>().ChangeSpeed(percents);
        } 
    }
}
