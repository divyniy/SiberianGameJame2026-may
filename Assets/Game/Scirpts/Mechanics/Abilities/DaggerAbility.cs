using UnityEngine;

[CreateAssetMenu(fileName = "ThrowingAbility", menuName = "Сustom/Abilites/ThrowingAbility")]
public class DaggerAbility : Ability
{
    public GameObject projectile;

    public override void Activate()
    {
        Transform target = ServiceLocator.Get<EnemyManager>().GetClosestEnemyToTransform();
        Transform transform = ServiceLocator.Get<Player>().transform;

        GameObject current = Instantiate(projectile, transform.position, Quaternion.identity);
        current.GetComponent<IProjectile>().Setup(target,transform);
    }
}
