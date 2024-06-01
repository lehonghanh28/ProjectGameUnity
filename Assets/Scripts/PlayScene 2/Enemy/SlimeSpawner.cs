using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject slime;
    [HideInInspector]
    public float slimeSpawnInterval = 50f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnSlimes");
    }

    // Update is called once per frame
    void Update()
    {   
        //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().gameOver
        if(PlayerManager.gameOver)
        {
            StopCoroutine("SpawnSlimes");
        }
        if(PlayerManage.gameOver1){
            StopCoroutine("SpawnSlimes");
        }
    }

    private void SpawnSlime()
    {
        Instantiate(slime, new Vector3(transform.position.x, 3f, 0), Quaternion.identity);
    }

    IEnumerator SpawnSlimes()
    {
        while(true){
            SpawnSlime();
            yield return new WaitForSeconds(slimeSpawnInterval);
        }
    }
}
