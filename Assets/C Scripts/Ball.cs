using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public AudioClip bounceSound;
    public bool hasStarted = false;

    private Paddle paddle;
    private bool brickgeraakt = false;
    private Vector3 paddleToBallVector;
    private Vector3 OriginalBallPlacement;
    private Vector3 OriginalPaddlePlacement;
    
    void Start()
    {
        CalculatePaddleToBrick();
    }

    // When the game starts, we go 'looking for the paddle'
    void CalculatePaddleToBrick()
    {
        Vector3 OriginalBallPlacement = this.transform.position;

        // calculate distance to centre of the paddle so we can stay in the same place (calculated from our core)
        paddle = GameObject.FindObjectOfType<Paddle>();
        Vector3 OriginalPaddlePlacement = paddle.transform.position;
        // Debug.Log("Original Paddle Location =  " + OriginalPaddlePlacement);
        paddleToBallVector = this.transform.position - paddle.transform.position;
    }


    // Basically, Update function only manages the initial launch of the ball, on the click of the mouse
    void Update()
    {
        if (hasStarted == false) { PlaceBallOnPaddle(); }

        if (Input.GetMouseButtonDown(0))
        {
            if (hasStarted == false)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(1f, 8f);
                // Tell the system to ignore future launches (while ball is in play)
                hasStarted = true;
            }
        }
    }



    void OnCollisionEnter2D(Collision2D bounce)
    {
        if (hasStarted == true)
        {

            // Raken we het linker oortje?
     //       if (bounce.gameObject.GetComponent<Leftbounce>())
     //       {
    //            Debug.Log("Ball registreert collision linker oor");
     //           BallLeftBounce();
     //       }

     //       else
            {

                // If we don't hit a brick
                if (!bounce.gameObject.GetComponent<BrickHit>())
                {
                    brickgeraakt = false;
                    AudioSource.PlayClipAtPoint(bounceSound, transform.position, 0.3f);
                }

                // Dus we WEL hebben een brick geraakt
                else { brickgeraakt = true; }


                BallBehaviour();
            }
        }

    }



    //Adding a tiny bit of randomness to the ball movement
    void BallBehaviour()
    {
        Vector2 tweak = new Vector2(Random.Range(-0.1f, 0.1f), Random.Range(0f, 0.1f));
        GetComponent<Rigidbody2D>().velocity += tweak;
    }

    //When the ball hits the 'left ear' of our paddle
   // void BallLeftBounce()
   // {
   //     Vector2 knalnaarlinks = new Vector2(Random.Range(-3f, -1f), 12f);
  //      Debug.Log("The bounce-left velocity = " + knalnaarlinks);
  //      GetComponent<Rigidbody2D>().velocity = knalnaarlinks;
   // }



    
    

        
    


    void PlaceBallOnPaddle()
    {
        this.transform.position = paddle.transform.position + paddleToBallVector;
    }

    public void RestartLevel()
    {
        hasStarted = false;
        PlaceBallOnPaddle();
    }
}


        