using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractAbilityBase : ScriptableObject
{

  [SerializeField] public new string name;
  [SerializeField] public float cooldownTime;
  protected Sprite image;
  [SerializeField] public int abilityID;
  public enum AbilityState
  {
    ready, cooldown
  }

  public AbilityState state = AbilityState.ready;
  public AbstractAbilityBase(string name, float cooldownTime, int abilityID)
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
