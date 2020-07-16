using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMenu : MonoBehaviour
{

    //Serialized Fields
    [SerializeField] AudioClip blockSound;
    [SerializeField] GameObject sparkleVFX;


    public void OnCollisionEnter2D(Collision2D collision)
    {
          DestroyBlock();
 
    }


    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(blockSound, Camera.main.transform.position);
        TriggerSparkleVFX();
        Destroy(gameObject);
    }

    private void TriggerSparkleVFX()
    {
        GameObject sparkle = Instantiate(
            sparkleVFX, transform.position, transform.rotation);
        Destroy(sparkle, 2f);
    }
}