using UnityEngine;

[CreateAssetMenu(fileName = "HealAbility", menuName = "Сustom/Abilites/HealAbility")]
public class HealAbility : Ability
{
    public override void Activate()
    {
        ServiceLocator.Get<Player>().TakeDamage(-3);
        ServiceLocator.Get<Player>().SetSpeed(1);
    }
}
