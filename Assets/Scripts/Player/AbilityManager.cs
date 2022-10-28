using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AbilityManager : ScriptableObject
{
  [SerializeField] public AbstractAbilityBase slowEnemiesAbility;

  public void callSlowEnemiesAbility()
  {
    slowEnemiesAbility.callAbility();
  }
}
