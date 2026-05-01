using System.Collections;
using UnityEngine;

public class PlayerAbilityManager : MonoBehaviour
{
    [SerializeField] private PlayerAbility[] currentAbilities;

    private void Update()
    {
        
    }
    private void Start()
    {
        Active();
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
}

[System.Serializable]
public class PlayerAbility
{
    public Ability ability;
    public bool isAvaiable;
}
