using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public void RemoveHeart(int heart)
    {
        Destroy(transform.GetChild(heart).gameObject);
    }
}
