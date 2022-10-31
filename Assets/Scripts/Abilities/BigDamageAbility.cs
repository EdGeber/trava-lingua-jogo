using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu]
public class BigDamageAbility : AbstractAbilityBase
{
  [SerializeField] private int bigDamage = 20;

  public BigDamageAbility() : base("Big Damage", 2, 1) { }

  public override void callAbility(float effectFactor = 1.0f)
  {
    if (this.state == AbilityState.ready)
    {
      SkillHudBehaviour squareColor = GameObject.Find("HUD").GetComponent<SkillHudBehaviour>();
      squareColor.ChangeColor(0,true);
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
      MonoInstance.Instance.runAfterDelay(() => { 
        this.resetAbility();
        squareColor.ChangeColor(0,false);
      }, this.cooldownTime);
    }
  }
}
