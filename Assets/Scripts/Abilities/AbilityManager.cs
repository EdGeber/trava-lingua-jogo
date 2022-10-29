using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AbilityManager : ScriptableObject
{
  [SerializeField] public List<AbstractAbilityBase> Abilities;

  public void callSlowEnemiesAbility()
  {
    Debug.Log("SLOW ENEMIES");
    var slowEnemiesAbility = Abilities.Find(ability => ability.abilityID == 0);
    slowEnemiesAbility.callAbility();
  }

  public void callBigDamageAbility()
  {
    Debug.Log("BIG DAMAGE");
    var bigDamageAbility = Abilities.Find(ability => ability.abilityID == 1);
    bigDamageAbility.callAbility();
  }

  public void callCureAbility()
  {
    Debug.Log("CURE");
    var cureAbility = Abilities.Find(ability => ability.abilityID == 2);
    cureAbility.callAbility();
  }
}
