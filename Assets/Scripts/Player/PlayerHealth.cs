using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
  [SerializeField] private float health = 0f;
  [SerializeField] private float maxHealth = 100f;

  private void Start()
  {
    health = maxHealth;
  }

  public void UpdateHealth(float modifier)
  {
    health += modifier;
    if (health > maxHealth)
    {
      health = maxHealth;
    }
    else if (health <= 0f)
    {
      health = 0f;

      Debug.Log("Player is Dead"); //Fazer depois a morte do player propriamente
    }
  }
}
