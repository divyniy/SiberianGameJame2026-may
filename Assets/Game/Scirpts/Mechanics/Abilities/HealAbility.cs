using UnityEngine;

[CreateAssetMenu(fileName = "HealAbility", menuName = "Сustom/Abilites/HealAbility")]
public class HealAbility : Ability
{
    public float additionalSpeed;
    [Tooltip("ПИСАТЬ ПОЛОЖИТЕЛЬНОЕ ЧИСЛО")]public float minusHp;
    public override void Activate()
    {
        ServiceLocator.Get<Player>().TakeDamage(-Mathf.Abs(minusHp));
        ServiceLocator.Get<Player>().SetSpeed(additionalSpeed);
    }
}
