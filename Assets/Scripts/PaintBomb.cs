using UnityEngine;

public class PaintBomb : MonoBehaviour
{
    public PaintPuddle PuddlePrefab;

    public float puddleSpawnTimer = 2;
    public float puddleRemotionTimer = 2;
    public bool timerIsRunning = false;
    public bool destroyPuddle = true;
    private void Start()
    {
        timerIsRunning = true;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (puddleSpawnTimer > 0)
            {
                puddleSpawnTimer -= Time.deltaTime;
            }
            else
            {
                Instantiate(PuddlePrefab, transform.position, transform.rotation);
                puddleSpawnTimer = 0;
                timerIsRunning = false;
            }
        } else
        {
            if (puddleRemotionTimer > 0)
            {
                puddleRemotionTimer -= Time.deltaTime;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
