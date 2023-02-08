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

    public ScoreControl score;
    public GameManager gameManager;
    bool touchedGround;

    public Sprite ghostDied;
    SpriteRenderer sp;
    Animator anim;

    public ArmSpawner armSpawner;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb.gravityScale = 0; //zero gravity to keep ghost in the air before game starts
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !GameManager.gameOver) //0 the left button
        {
            if(!GameManager.gameHasStarted)
            {
                rb.gravityScale = 0.7f;
                gameManager.GameHasStarted();
                Flap();
                armSpawner.InstantiateArm();
            }
            else
            {
                Flap();
            }
        }
        GhostRotation();
    }

    void GhostRotation()
    {
        if(rb.velocity.y > 0) //moving up
        {
            rb.gravityScale = 0.8f;
            if(angle<=MAX_ANGLE)
            {
                angle += 0.5f;
            }
        }
        else if(rb.velocity.y < 0) //moving down
        {
            rb.gravityScale = 0.6f;
            if(angle>=MIN_ANGLE)
            {
                angle -= 0.3f;
            }
        }

        if(!touchedGround)
        {
            transform.rotation = Quaternion.Euler(0,0,angle);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Arms"))
        {
            score.Scored();
        }
        else if(collision.CompareTag("SingleArm"))
        {
            gameManager.GameOver();

        }

    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            if(!GameManager.gameOver)
            {
                gameManager.GameOver();
                Gameover();
            }
            else
            {
                Gameover();
            }
        }
    }

    void Gameover()
    {
        touchedGround = true;
        sp.sprite = ghostDied;
        anim.enabled = false;
        transform.rotation = Quaternion.Euler(0,0,-90);
    }

    void Flap()
    {
        rb.velocity = Vector2.zero; //disable gravity
        rb.velocity = new Vector2(rb.velocity.x, speed); //only move up/down
    }
}
