using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SlowEnemiesAbility : AbstractAbilityBase
{
  [SerializeField] private float slowFactor = 0.5f;
  private List<EnemyBase> slowedEnemies;
  [SerializeField] private int slowDuration = 5;
  public SlowEnemiesAbility() : base("Slow Enemies", 2, 0) { }

  public override void callAbility()
  {
    if (this.state == AbilityState.ready)
    {
      var enemiesFoundOnCanvas = FindObjectsOfType(typeof(EnemyBase)) as EnemyBase[];
      foreach (var enemy in enemiesFoundOnCanvas)
      {
        if (enemy.isPainted)
        {
          slowedEnemies.Add(enemy);
          enemy.Speed = enemy.Speed * this.slowFactor;
        }
      }
      this.setAbilityStateOnCooldown();
      MonoInstance.Instance.runAfterDelay(() => { this.resetAbility(); }, this.slowDuration);
      MonoInstance.Instance.runAfterDelay(() => { this.setAbilityStateReady(); }, this.cooldownTime);
    }
  }

  protected override void resetAbility()
  {
    foreach (var enemy in slowedEnemies)
    {
      enemy.Speed = enemy.InitialSpeed;
    }
  }
}
