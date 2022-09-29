using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{   
    public float speed = 3f;
    public Transform player;
    private Animator anim;
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackSpeed = 1f;
    
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
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        anim.SetFloat("horizontal", direction.x);
        anim.SetFloat("vertical", direction.y);
        anim.SetFloat("health", health);
    }

    private void OnCollisionStay2D(Collision2D other){
        TakeDamage(10f);
        if (other.gameObject.tag == "Player"){
            if (attackSpeed <= canAttack){
                other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f;            
            } else{
                canAttack += Time.deltaTime;
            }
        }
    }

}