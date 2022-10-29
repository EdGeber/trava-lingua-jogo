using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SlowEnemiesAbility : AbstractAbilityBase
{
  private float slowFactor = 0.1f;
  private List<EnemyBase> slowedEnemies;
  private int slowDuration = 5;
  public SlowEnemiesAbility() : base("Slow Enemies", 2, 0)
  {
  }

  public override void callAbility()
  {
    // TODO: implementar uma lógica para resetar o cooldown da habilidade, pois atualmente o tempo de cooldown é o tempo de duração do slow
    if (this.state == AbilityState.ready)
    {
      var enemiesFoundOnCanvas = FindObjectsOfType(typeof(EnemyBase)) as EnemyBase[];
      foreach (var enemy in enemiesFoundOnCanvas)
      {
        if (enemy.isPainted)
        {
          slowedEnemies.Add(enemy);
          enemy.Speed = enemy.Speed * slowFactor;
        }
      }
      this.setAbilityStateOnCooldown();
      MonoInstance.Instance.runAfterDelay(() => { this.resetAbility(); }, this.slowDuration);
    }
  }

  protected override void resetAbility()
  {
    foreach (var enemy in slowedEnemies)
    {
      enemy.Speed = enemy.InitialSpeed;
    }
    this.setAbilityStateReady();
  }
}
