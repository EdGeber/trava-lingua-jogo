using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillHudBehaviour : MonoBehaviour
{
    public void ChangeColor(int child, bool active)
    {
        GameObject bigDamageHudObj = transform.GetChild(1).gameObject;
        GameObject squareSprite = bigDamageHudObj.transform.GetChild(child).GetChild(0).gameObject;
        SpriteRenderer skillSquare = squareSprite.GetComponent<SpriteRenderer>();
        if (active)
        {
            skillSquare.color = new Color(0.121569f,0.145098f,0.152941f,1f);
        }
        else
        {
            skillSquare.color = new Color(0.286275f,0.450980f,0.517647f,1f);
        }
    }
}
