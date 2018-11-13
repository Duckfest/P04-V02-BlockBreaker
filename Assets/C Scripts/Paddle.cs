using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;
    
    // On paddle in Unity give coordinates where paddle leaves playing field
    public float minX, maxX;

    private Ball ball;

	// Use this for initialization
	void Start ()
    {
    ball = GameObject.FindObjectOfType<Ball>();
        Debug.Log(ball);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (autoPlay == false)
        {
            MoveWithMouse();
        }
        else
        {
            AutoPlay();
        }
          
	}

    void MoveWithMouse()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        float MousePosInBlocks;
        MousePosInBlocks = (Input.mousePosition.x / Screen.width) * 16;
        paddlePos.x = Mathf.Clamp(MousePosInBlocks, minX, maxX);
        this.transform.position = paddlePos;
    }

    void AutoPlay()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        Vector3 ballPos = ball.transform.position;
      
        paddlePos.x = Mathf.Clamp(ballPos.x, 0.7f, 15.3f);
        this.transform.position = paddlePos;
    }
}
