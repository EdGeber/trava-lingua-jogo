using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu]
public class CureAbility : AbstractAbilityBase
{
  [SerializeField] private float maxCureAmount = 20f;

  public CureAbility() : base("Cure", 3.0f, 2) { }

  public override void callAbility(float effectFactor = 0.0f)
  {
    SkillHudBehaviour squareColor = GameObject.Find("HUD").GetComponent<SkillHudBehaviour>();
    PlayerHealth playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    if (effectFactor > 0.75f)
    {
      SoundEffectsManager.instanceSEM.playHealAudio();
      playerHealth.UpdateHealth(maxCureAmount);
    }
    else if (effectFactor > 0.3f)
    {
      SoundEffectsManager.instanceSEM.playHealAudio();
      playerHealth.UpdateHealth(maxCureAmount / 2);
    }
    MonoInstance.Instance.runAfterDelay(() =>
    {
      this.resetAbility();
      squareColor.ChangeColor(2, false);
    }, this.cooldownTime);
  }

}
