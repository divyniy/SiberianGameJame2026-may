using System.Collections;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAbilityManager : MonoBehaviour, IService
{
    [SerializeField] private PlayerAbility[] currentAbilities;
    public static UnityAction onDied;
    private int counter;

    private void Update()
    {
        
    }
    private void Active()
    {
        foreach(PlayerAbility ability in currentAbilities)
        {
            if(ability.isAvaiable)
            {
                ability.isAvaiable = false;
                ability.ability.Activate();
                StartCoroutine(ResetAbility(ability.ability.cooldown, ability));
            }
        }
    }
    private IEnumerator ResetAbility(float cooldown, PlayerAbility ability)
    {
        yield return new WaitForSeconds(cooldown);
        ability.isAvaiable = true;
        Active();
    }

    public void Execute()
    {
        Active();
        onDied += CountPassive;
    }
    private void CountPassive()
    {
        counter++;

        if(counter>2)
        {
            counter = 0;

            foreach(PlayerAbility ability in currentAbilities)
            {
                if(ability.ability is IllnessAbility)
                {
                    IllnessAbility abil = ability.ability as IllnessAbility;
                    abil.Effect();
                }
            }
        }
    }
}

[System.Serializable]
public class PlayerAbility
{
    public Ability ability;
    public bool isAvaiable;
}
