using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpaen : MonoBehaviour
{
    public GameObject openPipe;
    public GameObject closedPipe;
    public Logic logic;
    public float heightOffset;
    public float timer = 0;
    public float originalSpawnRate = 4;
    public float spawnRate;
    public float closedPipeChance = 0.4f;
    public float lastScoreUpdate = 0;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnRate > 0.8 && logic.playerScore % 4 == 0 && logic.playerScore != 0 && logic.playerScore != lastScoreUpdate)
        {
            spawnRate /= 1.1f;
            lastScoreUpdate = logic.playerScore;
        }

        if (logic.playerScore == 0)
        {
            spawnRate = originalSpawnRate;
            lastScoreUpdate = 0;
        }

        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            spawnPipe();
        }
    }

    public void spawnPipe()
    {
        GameObject pipeToSpawn;
        
        if(Random.value < closedPipeChance)
        {
            heightOffset /= 2;
            pipeToSpawn = closedPipe;
        }
        else
        {
            heightOffset = 3;
            pipeToSpawn = openPipe;
        }

        float lowerPoint = transform.position.y - heightOffset;
        float upperPoint = transform.position.y + heightOffset;

        Instantiate(pipeToSpawn, new Vector3(transform.position.x, Random.Range(upperPoint, lowerPoint), 0), transform.rotation); 
    }
}
