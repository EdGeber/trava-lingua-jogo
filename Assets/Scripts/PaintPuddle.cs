using UnityEngine;

public class PaintPuddle : MonoBehaviour
{
    public float puddleRemotionTimer = 2;
    public bool timerIsRunning = false;
    private void Start()
    {
        timerIsRunning = true;
    }
    void Update()
    {
        if (timerIsRunning)
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
