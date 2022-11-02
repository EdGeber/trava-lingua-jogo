using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownSlider : MonoBehaviour
{
    private float decrease;
    public bool resetSlider;
    private Slider cdBar;
    private SkillHudBehaviour hudIcons;

    void Start()
    {
        hudIcons = GameObject.Find("HUD").GetComponent<SkillHudBehaviour>();
        cdBar = transform.GetChild(0).gameObject.GetComponent<Slider>();
        decrease = -1f;
        resetSlider = true;
        cdBar.minValue = 0f;
        cdBar.maxValue = 5f;
        cdBar.value = 5f;
    }

    void Update()
    {
        if (!resetSlider)
        {
            cdBar.value += Time.deltaTime * decrease;
            if (cdBar.value == 0f)
            {
                resetSlider = true;
            }
        }
        else
        {
            cdBar.maxValue = 5f;
            cdBar.value = 5f;
            hudIcons.ActivateVoice(false);
        }
    }
}
