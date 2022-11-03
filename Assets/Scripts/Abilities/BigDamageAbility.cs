using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu]
public class BigDamageAbility : AbstractAbilityBase
{
  [SerializeField] private float maxBigDamage = 50.0f;

  public BigDamageAbility() : base("Big Damage", 2.0f, 0) { }

  public override void callAbility(float effectFactor = 0.0f)
  {
    SkillHudBehaviour squareColor = GameObject.Find("HUD").GetComponent<SkillHudBehaviour>();
    float bigDamage = maxBigDamage * effectFactor;
    GameObject[] GOs = GameObject.FindGameObjectsWithTag("Enemy");
    foreach (GameObject GO in GOs)
    {
      EnemyBase enemy = GO.GetComponent<EnemyBase>();
      if (enemy.isPainted)
      {
        SoundEffectsManager.instanceSEM.playBigDamageAudio();
        enemy.TakeDamage(bigDamage);
        enemy.isPainted = false;
      }
    }
    MonoInstance.Instance.runAfterDelay(() =>
    {
      this.resetAbility();
      squareColor.ChangeColor(0, false);
    }, this.cooldownTime);
  }
}
