using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    public float arrowSpeed = 10f;

    private void Update()
    {
        transform.position += Time.fixedDeltaTime * arrowSpeed * transform.up;
    }
    
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
