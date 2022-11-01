using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu]
public class FreezeEnemiesAbility : AbstractAbilityBase
{
  private List<EnemyBase> freezedEnemies = new List<EnemyBase>();
  [SerializeField] private int freezeDuration = 4;

  public FreezeEnemiesAbility() : base("Freeze", 3, 3) { }

  public override void callAbility()
  {
    if (this.state == AbilityState.ready)
    {
      SkillHudBehaviour squareColor = GameObject.Find("HUD").GetComponent<SkillHudBehaviour>();
      squareColor.ChangeColor(3,true);
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
      MonoInstance.Instance.runAfterDelay(() => { 
        this.resetAbility();
        squareColor.ChangeColor(3,false);
      }, this.freezeDuration);
      MonoInstance.Instance.runAfterDelay(() => { this.setAbilityStateReady(); }, this.cooldownTime);
    }
  }

  protected override void resetAbility()
  {
    foreach (var enemy in freezedEnemies)
    {
      enemy.Speed = enemy.InitialSpeed;
    }
  }
}
