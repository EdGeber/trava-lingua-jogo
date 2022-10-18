using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{   
    [SerializeField] private float speed = 3f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform player;
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackSpeed = 1f;
    [SerializeField] private float attackDistance = 0.05f;
    private Animator anim;
    
    //[Header("Health")] descobrir para que servem Headers

    private float health;
    [SerializeField] private float maxHealth = 50f;
    private float canAttack;
    private void Start(){
        anim = GetComponent<Animator>();
        health = maxHealth;

    }

    public void TakeDamage(float damage){
        health -= damage;
        
        if (health <= 0){
            Destroy(gameObject, 0.53f); //delay de 0.58 segundos pra bater com a animação
        }
    }

    private void Update(){
        canAttack += Time.deltaTime;
    }
    
    void FixedUpdate()
    {
        Vector2 displacement = player.position - transform.position;
        if(attackDistance < displacement.magnitude) {
            rb.MovePosition(rb.position + displacement.normalized*speed*Time.fixedDeltaTime);
            anim.SetFloat("horizontal", displacement.x);
            anim.SetFloat("vertical", displacement.y);
            anim.SetFloat("health", health);
        } else {
            // TODO: attack animation
            anim.SetFloat("horizontal", 0);
            anim.SetFloat("vertical", 0);
            if (attackSpeed <= canAttack){
                player.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f;
            }
        }
    }

}