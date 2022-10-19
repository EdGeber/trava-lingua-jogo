using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private TL TL;
    public PaintBomb BombPrefab;
    private Camera cam;
    private const int bigDamage = 20;
    private bool canDealBigDamage = true;
    private const int attackCooldown = 2;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        TL = GameObject.Find("/System/TL").GetComponent<TL>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Bomb")) throwBomb();

        if(Input.GetButtonDown("BigDamage")) dealBigDamage();
    }

    void throwBomb() {
        // Transforms the Screen position to World position using the current mouse position
        // Reference: https://docs.unity3d.com/ScriptReference/Camera.ScreenToWorldPoint.html
        Vector3 mouseWorldPos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));
        Instantiate(BombPrefab, mouseWorldPos, transform.rotation);
    }

    void dealBigDamage() {
        if(!canDealBigDamage) return;

        GameObject[] GOs = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject GO in GOs) {
            EnemyBase enemy = GO.GetComponent<EnemyBase>();
            if(enemy.isPainted) {
                enemy.TakeDamage(bigDamage);
            }
        }
        Debug.Log("Big damage!");
        canDealBigDamage = false;
        TL.runAfterDelay(
            () => {
                canDealBigDamage = true;
                Debug.Log("BigDamage cooldown reset!");
            },
            attackCooldown
        );
    }
}
