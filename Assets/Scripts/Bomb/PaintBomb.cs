using UnityEngine;

public class PaintBomb : MonoBehaviour
{
    public PaintPuddle PuddlePrefab;

    public float puddleSpawnTimer = 2f;
    public float bombRemotionTimer = 2f;
    public bool timerIsRunning = false;
    public bool destroyPuddle = true;

    void Start()
    {
        timerIsRunning = true;
    }
    void Update()
    {
        if (!PauseBehaviour.gameIsPaused)
        {
            if (timerIsRunning)
            {
                if (puddleSpawnTimer > 0f)
                {
                    puddleSpawnTimer -= Time.deltaTime;
                }
                else
                {
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
