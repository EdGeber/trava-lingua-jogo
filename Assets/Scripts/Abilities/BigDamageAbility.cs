using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BigDamageAbility : AbstractAbilityBase
{
  private const int bigDamage = 20;

  public BigDamageAbility() : base("Big Damage", 2, 1) { }

  public override void callAbility()
  {
    if (this.state == AbilityState.ready)
    {
      GameObject[] GOs = GameObject.FindGameObjectsWithTag("Enemy");
      foreach (GameObject GO in GOs)
      {
        EnemyBase enemy = GO.GetComponent<EnemyBase>();
        if (enemy.isPainted)
        {
          enemy.TakeDamage(bigDamage);
        }
      }
      this.setAbilityStateOnCooldown();
      MonoInstance.Instance.runAfterDelay(() => { this.resetAbility(); }, this.cooldownTime);
    }
  }
}
