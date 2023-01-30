using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    float speed = 1;
    BoxCollider2D box;
    float groundWidth;
    float armWidth;
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.CompareTag("Ground"))
        {
            box = GetComponent<BoxCollider2D>();
            groundWidth = box.size.x; //get the size of the ground sprite dynamically
        }
        else if(gameObject.CompareTag("Arms"))
        {
            armWidth = GameObject.FindGameObjectWithTag("SingleArm").GetComponent<CircleCollider2D>().radius; //Will get the first object
        }


    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.gameOver)
        {
            transform.position = new Vector2(
                transform.position.x - speed * Time.deltaTime, 
                transform.position.y);
        }

        if(gameObject.CompareTag("Ground"))
        {
            if(transform.position.x <= -groundWidth) 
            //when it comes to the end it is moved at the beggining again
            //so the move is endless
            {
                transform.position = new Vector2(
                    transform.position.x + groundWidth * 2, 
                    transform.position.y);        
            }
        }
        else if(gameObject.CompareTag("Arms"))
        {
            if(transform.position.x < GameManager.bottomLeft.x - armWidth)
            {
                Destroy(gameObject);
            }
        }

    }
}
