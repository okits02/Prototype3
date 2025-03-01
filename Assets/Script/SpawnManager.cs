using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacleObject;
    public Vector3 spawnPoint = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeaRate = 2;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeaRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (playerControllerScript.GameOver == false)
        {
            Instantiate(obstacleObject, spawnPoint, obstacleObject.transform.rotation);
        }
    }
}
