using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public void ManageHeart(int heart, int status)
    {
        GameObject heartObj = transform.GetChild(heart).gameObject;
        SpriteRenderer heartSprite = heartObj.GetComponent<SpriteRenderer>();
        if (status == 0) {heartSprite.color = new Color(1f,1f,1f,0f);} 
        else {heartSprite.color = new Color(1f,1f,1f,1f);}
    }
}
