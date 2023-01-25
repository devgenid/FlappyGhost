using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostControl : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    const float MIN_ANGLE = -7;
    const float MAX_ANGLE = 5;

    float angle=0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) //0 the left button
        {
            rb.velocity = Vector2.zero; //disable gravity
            rb.velocity = new Vector2(rb.velocity.x, speed); //only move up/down
        }
        GhostRotation();
    }

    void GhostRotation()
    {
        if(rb.velocity.y > 0) //moving up
        {
            if(angle<=MAX_ANGLE)
            {
                angle += 0.5f;
            }
        }
        else if(rb.velocity.y < 0.5f) //moving down
        {
            if(angle>=MIN_ANGLE)
            {
                angle -= 0.3f;
            }
        }

        transform.rotation = Quaternion.Euler(0,0,angle);
    }
}
