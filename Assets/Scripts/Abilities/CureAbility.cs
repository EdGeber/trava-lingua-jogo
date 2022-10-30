using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CureAbility : AbstractAbilityBase
{
  private const float cureAmount = 20f;

  public CureAbility() : base("Cure", 3, 2) { }

  public override void callAbility()
  {
    if (this.state == AbilityState.ready)
    {
      PlayerHealth playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
      playerHealth.UpdateHealth(cureAmount);
      this.setAbilityStateOnCooldown();
      MonoInstance.Instance.runAfterDelay(() => { this.resetAbility(); }, this.cooldownTime);
    }
  }

}
