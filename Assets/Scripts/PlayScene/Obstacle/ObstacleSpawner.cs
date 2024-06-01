using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{   
    public GameObject obs1, obs2;
    [HideInInspector]
    public float obsSpawnInterval = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnObstacles");
    }

    // Update is called once per frame
    void Update()
    {   
        //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().gameOver
        if(PlayerManager.gameOver)
        {
            StopCoroutine("SpawnObstacles");
        }
        if(PlayerManage.gameOver1){
            StopCoroutine("SpawnObstacles");
        }
    }

    private void SpawnObstacle()
    {
        int random = Random.Range(1,3);
        if(random == 1)
        {
            Instantiate(obs1, new Vector3(transform.position.x, 0.3f, 0), Quaternion.identity);
        }

        else if(random == 2)
        {
            Instantiate(obs2, new Vector3(transform.position.x, 0.3f, 0), Quaternion.identity);
        }
    }

    IEnumerator SpawnObstacles()
    {
        while(true){
            SpawnObstacle();
            yield return new WaitForSeconds(obsSpawnInterval);
        }
    }
}
