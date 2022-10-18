using UnityEngine;

public class PaintPuddle : MonoBehaviour
{
    public float puddleRemotionTimer;
    public bool timerIsRunning = false;
    private void Start()
    {
        timerIsRunning = true;
        puddleRemotionTimer = 5f;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (puddleRemotionTimer > 0f)
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
