using UnityEngine;

public class PaintPuddle : MonoBehaviour
{
    private TL TL;
    public float puddleRemotionTimer = 2;
    public float paintDuration = 5;

    private void Start() {
        TL = GameObject.Find("/System/TL").GetComponent<TL>();
        Destroy(gameObject, puddleRemotionTimer);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag == "Enemy") {
            EnemyBase enemy = collider.gameObject.GetComponent<EnemyBase>();
            enemy.isPainted = true;
            TL.runAfterDelay(() => enemy.isPainted = false, paintDuration);
        }
    }
}
