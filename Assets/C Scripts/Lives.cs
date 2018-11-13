using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{

    public Sprite[] LivesSprites;
    private int spriteIndex;

    // Use this for initialization
    void Start ()
    {
        DrawBallsforLives();
    }

        public void DrawBallsforLives()
    {
        // To know what sprite to load we need to calculate the spriteIndex value based on the amount of lives (remaining)
        ConvertLivestoSpriteIndex();
        
        // Load sprite
        this.GetComponent<SpriteRenderer>().sprite = LivesSprites[spriteIndex];
    }

    public void ConvertLivestoSpriteIndex()
    {
        if (LevelManager.lives == 3) { spriteIndex = 0; }
        if (LevelManager.lives == 2) { spriteIndex = 1; }
        if (LevelManager.lives == 1) { spriteIndex = 2; }
    }


    // Update is called once per frame
    void Update () {
		
	}
}
