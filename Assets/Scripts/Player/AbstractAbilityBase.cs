using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractAbilityBase : ScriptableObject
{

  public new string name { get; set; }
  public int cooldownTime { get; set; }
  protected Sprite image;
  public int abilityID { get; set; }
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

  public abstract void callAbility();

  public virtual void setAbilityStateOnCooldown()
  {
    this.state = AbilityState.cooldown;
  }

  public virtual void setAbilityStateReady()
  {
    this.state = AbilityState.ready;
  }
}
