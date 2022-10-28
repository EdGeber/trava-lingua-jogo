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
    // Start is called before the first frame update
    void Start()
    {
        Camera cam = Camera.main;
        
        top   .transform.position = cam.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height+1, -cam.transform.position.z)) + (top   .transform.localScale.y/2)*Vector3.up;
        bottom.transform.position = cam.ScreenToWorldPoint(new Vector3(Screen.width/2, -1             , -cam.transform.position.z)) + (bottom.transform.localScale.y/2)*Vector3.down;
        right .transform.position = cam.ScreenToWorldPoint(new Vector3(Screen.width+1, Screen.height/2, -cam.transform.position.z)) + (right .transform.localScale.x/2)*Vector3.right;
        left  .transform.position = cam.ScreenToWorldPoint(new Vector3(-1            , Screen.height/2, -cam.transform.position.z)) + (left  .transform.localScale.x/2)*Vector3.left;

    }
}
