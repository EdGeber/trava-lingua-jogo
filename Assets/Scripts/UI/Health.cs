using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Mudar a remoção para opacidade 0, e criar a função para recuperar
    // Assim, o coração perdido pode ser recuperado depois
    public void RemoveHeart(int heart)
    {
        Destroy(transform.GetChild(heart).gameObject);
    }
}
