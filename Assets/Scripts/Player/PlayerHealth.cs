using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private float health = 0f;
    [SerializeField] private float maxHealth = 100f;
    private int heart;

    private GameObject healthObject;

    private void Start(){
        health = maxHealth;
        heart = 9;
        healthObject = GameObject.Find("Health");
    }

    public void UpdateHealth(float modifier){
        health += modifier;
        if (modifier == -10f){
            healthObject.GetComponent<Health>().RemoveHeart(heart);
            heart -= 1;
        }
        if (health > maxHealth){
            health = maxHealth;
        } else if (health <= 0f){
            health = 0f;
            
            // Debug.Log("Player is Dead"); //Fazer depois a morte do player propriamente
            SceneManager.LoadScene("GameOver");
        } 
    }
}
