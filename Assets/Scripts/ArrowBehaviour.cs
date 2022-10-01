using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    public float arrowSpeed = 4f;

    private void Update()
    {
        //GameObject offset = GameObject.Find("LaunchOffset");
        transform.position += Time.deltaTime * arrowSpeed * transform.up;
        //transform.rotation = offset.transform.rotation;
    }
    
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Destroy(gameObject);
    }
}
