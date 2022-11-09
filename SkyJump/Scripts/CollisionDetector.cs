using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float bunceStrength = 9f;

    PointCounter pointCounter;

    bool pointCounted = false;

    private void Start()
    {
        pointCounter = GameObject.FindGameObjectWithTag("Points").GetComponent<PointCounter>();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0)
        {
            rb = collision.rigidbody;

            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = bunceStrength;
                rb.velocity = velocity;
            }
            
            
            if (!pointCounted && gameObject.tag != "MainPlatform")
            {
                pointCounted = true;
                pointCounter.AddPoint();
            }
        }
    }
}
