using UnityEngine;

public class PaintBomb : MonoBehaviour
{
  public PaintPuddle PuddlePrefab;

  public float puddleSpawnTimer = 2f;
  public float bombRemotionTimer = 2f;
  public bool timerIsRunning = false;
  public bool destroyPuddle = true;
  [SerializeField] public AudioSource bombAudioSource;

  void Start()
  {
    timerIsRunning = true;
  }
  void Update()
  {
    if (!PauseBehaviour.GameIsPaused)
    {
      if (timerIsRunning)
      {
        if (puddleSpawnTimer > 0f)
        {
          puddleSpawnTimer -= Time.deltaTime;
        }
        else
        {
          this.bombAudioSource.Play();
          Instantiate(PuddlePrefab, transform.position, transform.rotation);
          puddleSpawnTimer = 0f;
          timerIsRunning = false;
        }
      }
      else
      {
        if (bombRemotionTimer > 0f)
        {
          bombRemotionTimer -= Time.deltaTime;
        }
        else
        {
          Destroy(gameObject);
        }
      }
    }
  }
}
