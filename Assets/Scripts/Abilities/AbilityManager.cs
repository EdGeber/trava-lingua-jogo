using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AbilityManager : MonoBehaviour
{
  [SerializeField] public List<AbstractAbilityBase> Abilities;
  [SerializeField] public AudioInputManager audioInputManager;

  public void StartWithAbilitiesReady()
  {
    foreach (var ability in Abilities)
    {
      ability.setAbilityStateReady();
    }
  }

  public void callSlowEnemiesAbility()
  {

    var slowEnemiesAbility = Abilities.Find(ability => ability.abilityID == 0);
    audioInputManager.StartRecognising = true;
    audioInputManager.dictationEngine.resultOfHypotesis = "";
    audioInputManager.dictationEngine.resultOfRecognition = "";
    MonoInstance.Instance.runAfterDelay(() => { slowEnemiesAbility.callAbility(audioInputManager.correctWordsRatio); }, MonoInstance.recognitionDelay + 1.0f);
  }

  public void callBigDamageAbility()
  {
    var bigDamageAbility = Abilities.Find(ability => ability.abilityID == 1);
    audioInputManager.StartRecognising = true;
    audioInputManager.dictationEngine.resultOfHypotesis = "";
    audioInputManager.dictationEngine.resultOfRecognition = "";
    bigDamageAbility.callAbility();
  }

  public void callCureAbility()
  {
    var cureAbility = Abilities.Find(ability => ability.abilityID == 2);
    audioInputManager.StartRecognising = true;
    audioInputManager.dictationEngine.resultOfHypotesis = "";
    audioInputManager.dictationEngine.resultOfRecognition = "";
    cureAbility.callAbility();
  }

  public void callFreezeAbility()
  {
    var freezeAbility = Abilities.Find(ability => ability.abilityID == 3);
    audioInputManager.StartRecognising = true;
    audioInputManager.dictationEngine.resultOfHypotesis = "";
    audioInputManager.dictationEngine.resultOfRecognition = "";
    freezeAbility.callAbility();
  }
}
