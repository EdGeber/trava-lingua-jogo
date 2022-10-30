using UnityEngine;

public class PaintPuddle : MonoBehaviour
{
  private TL TL;
  public float puddleRemotionTimer = 2;
  public float paintDuration = 5;
  public float receivedInitialPuddleDamageDuration = 0;
  public float timerTrigger = 5;

  private void Start()
  {
    TL = GameObject.Find("/System/TL").GetComponent<TL>();
    Destroy(gameObject, puddleRemotionTimer);
  }

  private void Update()
  {
    if (timerTrigger > 0)
    {
      timerTrigger -= 1;
    }
  }

  private void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.gameObject.tag == "Enemy")
    {
      EnemyBase enemy = collider.gameObject.GetComponent<EnemyBase>();
      enemy.isPainted = true;
      if (!enemy.getReceivedInitialPuddleDamage() && timerTrigger > 0)
      {
        enemy.TakeDamage(20);
        enemy.setReceivedInitialPuddleDamage(true);
      }
      TL.runAfterDelay(() => enemy.isPainted = false, paintDuration);
      enemy.setReceivedInitialPuddleDamage(false);
    }
  }
}
