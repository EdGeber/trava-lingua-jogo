using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu]
public class FreezeEnemiesAbility : AbstractAbilityBase
{
  private List<EnemyBase> freezedEnemies = new List<EnemyBase>();
  [SerializeField] private float maxFreezeDuration = 8.0f;

  public FreezeEnemiesAbility() : base("Freeze", 3.0f, 3) { }

  public override void callAbility(float effectFactor = 0.0f)
  {
    SkillHudBehaviour squareColor = GameObject.Find("HUD").GetComponent<SkillHudBehaviour>();
    float freezeDuration = maxFreezeDuration * effectFactor;
    var enemiesFoundOnCanvas = FindObjectsOfType(typeof(EnemyBase)) as EnemyBase[];
    foreach (var enemy in enemiesFoundOnCanvas)
    {
      if (enemy.isPainted)
      {
        freezedEnemies.Add(enemy);
        enemy.Speed = 0;
        enemy.isPainted = false;
      }
    }
    MonoInstance.Instance.runAfterDelay(() => { this.resetAbility(); }, freezeDuration);
    MonoInstance.Instance.runAfterDelay(() =>
    {
      this.setAbilityStateReady();
      squareColor.ChangeColor(3, false);
    }, this.cooldownTime);
  }

  protected override void resetAbility()
  {
    foreach (var enemy in freezedEnemies)
    {
      enemy.Speed = enemy.InitialSpeed;
    }
  }
}
