using UnityEngine;

public class EnemyBase : MonoBehaviour
{
  [SerializeField] private float speed = 3f;
  public float Speed
  {
    get { return speed; }
    set { speed = value; }
  }
  public float InitialSpeed { get; set; }
  public bool IsFreezed { get; set; }
  [SerializeField] private Rigidbody2D rb;
  private Transform player;
  [SerializeField] private float attackDamage;
  [SerializeField] private float attackPeriod = 1f;
  [SerializeField] private float attackDistance = 0.05f;
  private Animator anim;
  public float health = 50f;
  public bool isPainted = false;
  private bool receivedInitialPuddleDamage = false;


  //[Header("Health")] descobrir para que servem Headers
  private float canAttack;

  private void Start()
  {
    attackDamage = 10f;
    anim = GetComponent<Animator>();
    player = GameObject.Find("Player").GetComponent<Transform>();
    this.InitialSpeed = this.speed;
  }

  private void Update(){
    if (!PauseBehaviour.gameIsPaused)
    {
        canAttack += Time.deltaTime;
    }
  }

  void FixedUpdate()
  {
    Vector2 displacement = player.position - transform.position;
    if (attackDistance < displacement.magnitude && this.speed != 0)
    {
      rb.MovePosition(rb.position + displacement.normalized * speed * Time.fixedDeltaTime);
      anim.SetFloat("horizontal", displacement.x);
      anim.SetFloat("vertical", displacement.y);
      anim.SetBool("isMoving", true);
    }
    else
    {
      // TODO: attack animation
      anim.SetFloat("horizontal", 0);
      anim.SetFloat("vertical", 0);
      anim.SetFloat("vitality", health);
      anim.SetBool("isMoving", false);
      if (attackPeriod <= canAttack && attackDistance < displacement.magnitude)
      {
        player.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
        canAttack = 0f;
      }
    }
  }

  public void TakeDamage(float damage)
  {
    health -= damage;
    if (health <= 0)
    {
      attackPeriod = 100f;
      Destroy(gameObject, 0.53f); //delay de 0.53 segundos pra bater com a animação
    }
  }

  public bool getReceivedInitialPuddleDamage()
  {
    return this.receivedInitialPuddleDamage;
  }

  public void setReceivedInitialPuddleDamage(bool state)
  {
    this.receivedInitialPuddleDamage = state;
  }

}