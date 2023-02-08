using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmSpawner : MonoBehaviour
{
    public GameObject arm;
    public float maxY,minY;
    float randY;

    public float maxTime;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        //InstantiateArm(); Arms will appear after the game starts (in GhostControl)
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.gameOver && GameManager.gameHasStarted)
        {
            timer += Time.deltaTime; //Difference of time between 2 carrets
            if(timer>=maxTime)
            {
                InstantiateArm();
                timer = 0;
            }
        }

    }

    public void InstantiateArm()
    {
        randY = Random.Range(minY,maxY);
        GameObject newArm = Instantiate(arm); //Create a copy of a prefab
        newArm.transform.position = new Vector2(transform.position.x,randY); //get the position of the spawner and place the new arms there
    }
}
