using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FreezeEnemiesAbility : AbstractAbilityBase
{
  private List<EnemyBase> freezedEnemies;
  private const int freezeDuration = 7;

  public FreezeEnemiesAbility() : base("Freeze", 3, 3) { }

  public override void callAbility()
  {
    if (this.state == AbilityState.ready)
    {
      var enemiesFoundOnCanvas = FindObjectsOfType(typeof(EnemyBase)) as EnemyBase[];
      foreach (var enemy in enemiesFoundOnCanvas)
      {
        if (enemy.isPainted)
        {
          freezedEnemies.Add(enemy);
          enemy.Speed = 0;
        }
      }
      this.setAbilityStateOnCooldown();
      MonoInstance.Instance.runAfterDelay(() => { this.resetAbility(); }, this.cooldownTime);
    }
  }

  protected override void resetAbility()
  {
    foreach (var enemy in freezedEnemies)
    {
      enemy.Speed = enemy.InitialSpeed;
    }
    this.setAbilityStateReady();
  }
}
