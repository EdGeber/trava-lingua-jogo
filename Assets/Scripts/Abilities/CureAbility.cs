using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu]
public class CureAbility : AbstractAbilityBase
{
  [SerializeField] private float cureAmount = 20f;

  public CureAbility() : base("Cure", 3, 2) { }

  public override void callAbility(float effectFactor = 1.0f)
  {
    if (this.state == AbilityState.ready)
    {
      SkillHudBehaviour squareColor = GameObject.Find("HUD").GetComponent<SkillHudBehaviour>();
      squareColor.ChangeColor(2,true);
      PlayerHealth playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
      playerHealth.UpdateHealth(cureAmount);
      this.setAbilityStateOnCooldown();
      MonoInstance.Instance.runAfterDelay(() => { 
        this.resetAbility();
        squareColor.ChangeColor(2,false);
      }, this.cooldownTime);
    }
  }

}
