using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    //Parameters
    int numBlocks;

    //cached reference
    SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks()
    {
        numBlocks++;
    }

    public void BlockBroken()
    {
        numBlocks--;
        if (numBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
