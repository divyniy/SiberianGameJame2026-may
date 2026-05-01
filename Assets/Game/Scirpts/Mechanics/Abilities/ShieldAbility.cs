using UnityEngine;

[CreateAssetMenu(fileName = "ShieldAbility", menuName = "Сustom/Abilites/ShieldAbility")]
public class ShieldAbility : Ability
{
    public override void Activate()
    {
        if(!ServiceLocator.Get<Player>().hasShield)
        {
            ServiceLocator.Get<Player>().SetShield(true);
        }
    }
}
