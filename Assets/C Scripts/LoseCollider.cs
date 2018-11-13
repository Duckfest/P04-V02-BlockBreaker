using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

   // private Vector3 CurrentPaddlePosition;
    private Paddle paddle;
    // private Vector3 CurrentBallPosition;
    private Ball ball;

    private LevelManager LevelManager;
    // Use this for initialization

    void Start()
    {
        
    }

    
    // In case of hitting collider calling a method that will execute losing the life
    void OnTriggerEnter2D(Collider2D trigger)
    {

        Debug.Log("Time: " + Time.time + "The OnTriggerEnter in LoseCollider.cs is executed with StartStatus = " + GameObject.FindObjectOfType<Ball>().hasStarted);

        Debug.Log("The object was : " + trigger.gameObject.name);

        // calculate location of the object to see what might cause this Collision
        paddle = GameObject.FindObjectOfType<Paddle>();
        Vector3 CurrentPaddleLocation = paddle.transform.position;
        Debug.Log("Current Paddle Location =  " + CurrentPaddleLocation);

        ball = GameObject.FindObjectOfType<Ball>();
        Vector3 CurrentBallLocation = ball.transform.position;
        Debug.Log("Current Ball Location =  " + CurrentBallLocation);


        if (GameObject.FindObjectOfType<Ball>().hasStarted == true)
        {
            
           LevelManager = GameObject.FindObjectOfType<LevelManager>();
            LevelManager.DownTheDrain();
        }

       

    }


}
