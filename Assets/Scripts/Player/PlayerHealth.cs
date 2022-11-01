using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float health = 0f;
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
            healthObject.GetComponent<Health>().ManageHeart(heart, 0);
            heart--;
        } 
        else if (modifier == 20f)
        {
            if (heart == 8)
            {
                heart++;
                healthObject.GetComponent<Health>().ManageHeart(heart, 1);
            } 
            else if (heart < 8)
            {
                for (int i = 0; i < 2; i++)
                {
                    heart++;
                    healthObject.GetComponent<Health>().ManageHeart(heart, 1);
                }
            }
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
