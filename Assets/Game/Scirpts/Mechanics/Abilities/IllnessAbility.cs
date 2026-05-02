using UnityEngine;

[CreateAssetMenu(fileName = "IllnessAbility", menuName = "Сustom/Abilites/IllnessAbility")]
public class IllnessAbility : Ability
{
    public override void Activate()
    {
        
    }
    public void Effect()
    {
        GameObject game = ServiceLocator.Get<EnemyManager>().GetRandomEnemy();

        if(game != null)
        game.GetComponent<IDamagable>().health.TakeDamage(damage);
    }
}
