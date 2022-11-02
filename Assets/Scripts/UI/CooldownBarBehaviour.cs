using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownBarBehaviour : MonoBehaviour
{
    private CooldownSlider cdSlider;
    private SkillHudBehaviour hudIcons;
    void Start()
    {
        cdSlider = transform.GetChild(4).gameObject.GetComponent<CooldownSlider>();
        hudIcons = gameObject.GetComponent<SkillHudBehaviour>();
    }

    public void StartCooldownBar()
    {
        cdSlider.resetSlider = false;
        hudIcons.ActivateVoice(true);
    }
}
