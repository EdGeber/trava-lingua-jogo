using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBoundaries : MonoBehaviour
{
    private Vector3 worldCenter;
    [SerializeField] private GameObject top;
    [SerializeField] private GameObject right;
    [SerializeField] private GameObject bottom;
    [SerializeField] private GameObject left;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        foreach(Transform child in transform) {
            child.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        StartCoroutine(fixWallPositions());
    }

    private IEnumerator fixWallPositions() {
        // fix wall position every 0.25 second
        while(true) {
            top.transform.localScale *= 2*cam.ScreenToWorldPoint(new Vector3(Screen.width, 100, 0)).x/top.transform.localScale.x;
            bottom.transform.localScale = top.transform.localScale;

            right.transform.localScale *= 2*cam.ScreenToWorldPoint(new Vector3(100, Screen.height, 0)).y/right.transform.localScale.y;
            left.transform.localScale = right.transform.localScale;

            top   .transform.position = cam.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height+1, -cam.transform.position.z)) + (top   .transform.localScale.y/2)*Vector3.up;
            bottom.transform.position = cam.ScreenToWorldPoint(new Vector3(Screen.width/2, -1             , -cam.transform.position.z)) + (bottom.transform.localScale.y/2)*Vector3.down;
            right .transform.position = cam.ScreenToWorldPoint(new Vector3(Screen.width+1, Screen.height/2, -cam.transform.position.z)) + (right .transform.localScale.x/2)*Vector3.right;
            left  .transform.position = cam.ScreenToWorldPoint(new Vector3(-1            , Screen.height/2, -cam.transform.position.z)) + (left  .transform.localScale.x/2)*Vector3.left;

            yield return new WaitForSeconds(0.25f);
        }
    }
}
