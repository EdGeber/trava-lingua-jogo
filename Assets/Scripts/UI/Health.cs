using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public void RemoveHeart(int heart)
    {
        GameObject heartObj = transform.GetChild(heart).gameObject;
        SpriteRenderer heartSprite = heartObj.GetComponent<SpriteRenderer>();
        heartSprite.color = new Color(1f,1f,1f,0f);
    }
}
