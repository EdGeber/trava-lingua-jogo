using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu]
public class SlowEnemiesAbility : AbstractAbilityBase
{
  [SerializeField] private float maxSlowFactor = 0.5f;
  private List<EnemyBase> slowedEnemies = new List<EnemyBase>();
  [SerializeField] private int slowDuration = 5;

  public SlowEnemiesAbility() : base("Slow Enemies", 2.0f, 1) { }

  public override void callAbility(float effectFactor = 1.0f)
  {
    // if effectFactor == 1, max slow (0.5f)
    float maxSlowFactorCompliment = 1.0f - this.maxSlowFactor;
    float slowFactor = 1.0f - (maxSlowFactorCompliment * effectFactor);
    SkillHudBehaviour squareColor = GameObject.Find("HUD").GetComponent<SkillHudBehaviour>();
    var enemiesFoundOnCanvas = FindObjectsOfType(typeof(EnemyBase)) as EnemyBase[];
    foreach (var enemy in enemiesFoundOnCanvas)
    {
      if (enemy.isPainted)
      {
        SoundEffectsManager.instanceSEM.playSlowAudio();
        slowedEnemies.Add(enemy);
        enemy.Speed = enemy.Speed * (slowFactor);
        enemy.isPainted = false;
      }
    }
    MonoInstance.Instance.runAfterDelay(() => { this.resetAbility(); }, this.slowDuration);
    MonoInstance.Instance.runAfterDelay(() =>
    {
      this.setAbilityStateReady();
      squareColor.ChangeColor(1, false);
    }, this.cooldownTime);
  }

  protected override void resetAbility()
  {
    foreach (var enemy in slowedEnemies)
    {
      enemy.Speed = enemy.InitialSpeed;
    }
  }
}
