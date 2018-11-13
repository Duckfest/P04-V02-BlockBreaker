using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour {
    public int buildIndex;

    public static int lives = 3;
    public static float time;

    // Everytime a new level is started
    public void LoadLevel(string name)
    {
       // Reset of brick counter to make sure they doný accumulate and become hogher than max
       BrickHit.breakableChildrenCount = 0;

       SceneManager.LoadScene(name);
    }
        

    public void BrickDestroyed()
    {
        // When all breakable bricks are destroyed, you can go on to next level 
        if (BrickHit.breakableChildrenCount <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    // What happens when you hit the LoseCollider on the bottom
    public void DownTheDrain()
    {
        lives--;
        Debug.Log("The player has " + lives + " lives");

        // In case of game over
        if (lives <= 0)
        {
            lives = 3;
            SceneManager.LoadScene("Completed");
        }

        // In case player has lives left
        else
        {
            GameObject.FindObjectOfType<Lives>().DrawBallsforLives();
            GameObject.FindObjectOfType<Ball>().RestartLevel();
        }
        
    }
        
   



    
}