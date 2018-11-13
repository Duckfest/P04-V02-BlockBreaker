using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickHit : MonoBehaviour
{
    //What do we need to access in Unity
    public Sprite[] hitSprites;
    public static int breakableChildrenCount = 0;
    public AudioClip crack;
    public AudioClip justahit;
    public GameObject smoke;

    //What do we use in this script only
    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable;

    // Use this for initialization
    void Start()
    {
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();

        // Keeping track of breakable bricks in level
        isBreakable = (this.tag == "Breakable");
        if (isBreakable)
        {
            breakableChildrenCount++;
         }
    }

    
    // Every time a brick is hit we execute this method
    void OnCollisionEnter2D(Collision2D col)
    {
        // Only executed for breakable bricks
        if (isBreakable)
        {
            HandleHits();
        }

    }

    void HandleHits()
    {
        // Hit counter goes up 1
        timesHit++;

        // Only a brick is hit a much as his maximum, we destroy the brick
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableChildrenCount--;
                             
            AudioSource.PlayClipAtPoint(crack, transform.position, 0.3f);
            GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity);
            smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
            Destroy(gameObject);
            levelManager.BrickDestroyed();
        }

        // Only bricks not destroyed need a new and damaged sprite
        else { LoadSprites(); }
    }

    void LoadSprites()
    {
        // Alleen geraakt sound
    AudioSource.PlayClipAtPoint(justahit, transform.position, 0.3f);
        
        // Calculate which sprite to load 1 timesHit loads element 0
        int spriteIndex = timesHit - 1;

        // Only load if there is a sprite to load
        if (hitSprites[spriteIndex] != null){ this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex]; }
        else { Debug.LogError ("sprite missing / geen plaatje"); }

    }
}

           