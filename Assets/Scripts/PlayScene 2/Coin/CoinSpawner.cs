using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{   
    public GameObject coin;
    [HideInInspector]
    public float coinSpawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnCoins");
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMoving>().gameOver)
        {
            StopCoroutine("SpawnCoins");
        }
    }

    private void SpawnCoin()
    {
        int random = Random.Range(1,3);
        if(random == 1)
        {
            Instantiate(coin, new Vector3(transform.position.x, -2.5f, 0), Quaternion.identity);
        }

        else if(random == 2)
        {
            Instantiate(coin, new Vector3(transform.position.x, 4.2f, 0), Quaternion.identity);
        }
    }

    IEnumerator SpawnCoins()
    {
        while(true){
            SpawnCoin();
            yield return new WaitForSeconds(coinSpawnInterval);
        }
    }
}
