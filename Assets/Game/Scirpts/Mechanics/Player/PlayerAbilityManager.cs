using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAbilityManager : MonoBehaviour, IService
{
    [SerializeField] private List<PlayerAbility> currentAbilities;
    public static UnityAction onDied;
    private int counter;

    private void Update()
    {
        
    }
    private void Active()
    {
        PlayerCharacteristics characteristics = ServiceLocator.Get<ItemManager>().GetPlayerCharacteristics;

        foreach(PlayerAbility ability in currentAbilities)
        {
            if(ability.isAvaiable)
            {
                ability.isAvaiable = false;
                ability.ability.Activate();
                StartCoroutine(ResetAbility(ability.ability.cooldown-characteristics.cooldown, ability));
            }
        }
    }
    private IEnumerator ResetAbility(float cooldown, PlayerAbility ability)
    {
        yield return new WaitForSeconds(cooldown);
        ability.isAvaiable = true;
        Active();
    }
    public void GiveRandomAbility()
    {
        if(currentAbilities.Count>3) return;

        GameConfig cfg = Resources.Load<GameConfig>("GameConfig");
        Ability abi = cfg.abilities[Random.Range(0, cfg.abilities.Length)];

        AddAbility(abi);
    }
    private void AddAbility(Ability randomAbility)
    {
        PlayerAbility ability = new PlayerAbility();
        ability.ability = randomAbility;
        ability.isAvaiable = true;
        currentAbilities.Add(ability);

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
    public bool isAvaiable = true;
}
