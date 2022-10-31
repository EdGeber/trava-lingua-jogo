using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractAbilityBase : ScriptableObject
{

  [SerializeField] public new string name;
  [SerializeField] public int cooldownTime;
  protected Sprite image;
  [SerializeField] public int abilityID;
  protected enum AbilityState
  {
    ready, cooldown
  }

  protected AbilityState state = AbilityState.ready;
  public AbstractAbilityBase(string name, int cooldownTime, int abilityID)
  {
    this.name = name;
    this.cooldownTime = cooldownTime;
    this.abilityID = abilityID;
  }

  public abstract void callAbility(float effectFactor = 1.0f);

  public virtual void setAbilityStateOnCooldown()
  {
    this.state = AbilityState.cooldown;
  }

  public virtual void setAbilityStateReady()
  {
    this.state = AbilityState.ready;
  }

  protected virtual void resetAbility()
  {
    this.setAbilityStateReady();
  }
}
