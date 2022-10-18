using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private Animator anim;
    [System.NonSerialized]
    public float health;
    [SerializeField]
    private float maxHealth = 50f;
    public bool isPainted = false;

    private void Start(){
        anim = GetComponent<Animator>();
        health = maxHealth;
    }

    void Update()
    {
        anim.SetFloat("health", health);
    }

    public void TakeDamage(float damage){
        health -= damage;
        
        if (health <= 0){
            Destroy(gameObject, 0.53f); //delay de 0.53 segundos pra bater com a animação
        }
    }

    public void hi() => Debug.Log("hi");
}
