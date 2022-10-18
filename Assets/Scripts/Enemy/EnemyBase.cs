using UnityEngine;

public class EnemyBase : MonoBehaviour
{   
    [SerializeField] private float speed = 3f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform player;
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackPeriod = 1f;
    [SerializeField] private float attackDistance = 0.05f;
    [System.NonSerialized]
    private Animator anim;
    
    //[Header("Health")] descobrir para que servem Headers
    private float canAttack;

    private void Start(){
        anim = GetComponent<Animator>();
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
        } else {
            // TODO: attack animation
            anim.SetFloat("horizontal", 0);
            anim.SetFloat("vertical", 0);
            if (attackPeriod <= canAttack){
                player.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f;
            }
        }
    }

}