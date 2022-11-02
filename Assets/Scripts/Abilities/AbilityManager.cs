using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

public class AbilityManager : MonoBehaviour
{
  [SerializeField] public List<AbstractAbilityBase> Abilities;
  [SerializeField] public AudioInputManager audioInputManager;
  public TextMeshProUGUI TravaLingua;

  public void StartWithAbilitiesReady()
  {
    foreach (var ability in Abilities)
    {
      ability.setAbilityStateReady();
    }
  }

  private void callAbilityProcedure(int abilityID)
  {
    var selectedAbility = Abilities.Find(ability => ability.abilityID == abilityID);
    if (selectedAbility.state == AbstractAbilityBase.AbilityState.ready)
    {
      TravaLingua.text = TL.pegaTravaLinguas();
      SkillHudBehaviour squareColor = GameObject.Find("HUD").GetComponent<SkillHudBehaviour>();
      squareColor.ChangeColor(abilityID, true);
      audioInputManager.StartRecognising = true;
      audioInputManager.dictationEngine.resultOfHypotesis = "";
      audioInputManager.dictationEngine.resultOfRecognition = "";
      MonoInstance.Instance.runAfterDelay(() => { selectedAbility.callAbility(audioInputManager.correctWordsRatio); }, MonoInstance.recognitionDelay + 1.0f);
      selectedAbility.setAbilityStateOnCooldown();
    }
  }

  public void callSlowEnemiesAbility()
  {
    callAbilityProcedure(1);
  }

  public void callBigDamageAbility()
  {
    callAbilityProcedure(0);
  }

  public void callCureAbility()
  {
    callAbilityProcedure(2);
  }

  public void callFreezeAbility()
  {
    callAbilityProcedure(3);
  }
}
