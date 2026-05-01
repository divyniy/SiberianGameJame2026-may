using UnityEngine;

[CreateAssetMenu(fileName = "DaggerAbility", menuName = "Сustom/Abilites/DaggerAbility")]
public class DaggerAbility : Ability
{
    public GameObject projectile;

    public override void Activate()
    {
        Transform target = ServiceLocator.Get<EnemyManager>().GetClosestEnemyToTransform();
        Transform transform = ServiceLocator.Get<Player>().transform;

        GameObject current = Instantiate(projectile, transform.position, Quaternion.identity);
        current.GetComponent<Projectile>().Setup(target,transform);
    }
}
