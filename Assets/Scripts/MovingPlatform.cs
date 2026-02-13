using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2f;
    public Transform[] points;

    private int index = 0;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;

       
        transform.position = points[0].position;
    }

    void FixedUpdate()
    {
        
        Vector2 target = points[index].position;
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        
        if (Vector2.Distance(rb.position, target) < 0.05f)
        {
            index++;
            if (index >= points.Length)
                index = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}