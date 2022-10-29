using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AbilityManager : ScriptableObject
{
  [SerializeField] public List<AbstractAbilityBase> Abilities;

  public void callSlowEnemiesAbility()
  {
    var slowEnemiesAbility = Abilities.Find(ability => ability.abilityID == 0);
    slowEnemiesAbility.callAbility();
  }

  public void callBigDamageAbility()
  {
    var bigDamageAbility = Abilities.Find(ability => ability.abilityID == 1);
    bigDamageAbility.callAbility();
  }
}
