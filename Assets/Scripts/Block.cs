using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    //Serialized Fields
    [SerializeField] AudioClip blockSound;
    [SerializeField] GameObject sparkleVFX;
    [SerializeField] Sprite damagedSprite;
    [SerializeField] int maxHits = 1;

    //cached references
    Level actualLevel;

    //States
    int timeHits = 0;

    private void Start()
    {
        if (tag == "Breakable")
        {
            actualLevel = FindObjectOfType<Level>();
            actualLevel.CountBlocks();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            timeHits++;
            if (timeHits >= maxHits)
                DestroyBlock();
            else
            {
                ChangeCurrentSprite();
            }
        }
    }

    private void ChangeCurrentSprite()
    {
        GetComponent<SpriteRenderer>().sprite = damagedSprite;
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(blockSound, Camera.main.transform.position);
        actualLevel.BlockBroken();
        TriggerSparkleVFX();
        FindObjectOfType<GameStatus>().UpdateBlockScore();
        Destroy(gameObject);
    }

    private void TriggerSparkleVFX()
    {
        GameObject sparkle = Instantiate(
            sparkleVFX, transform.position, transform.rotation);
        Destroy(sparkle, 2f);
    }
}