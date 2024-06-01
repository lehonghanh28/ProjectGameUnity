using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ball;
    public GameObject bullet;
    private Transform player;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerManage.gameOver1)
        {
            StopCoroutine("Shoot");
        }

        if(Vector3.Distance(ball.transform.position, player.position) <= 20f){
            timer += Time.deltaTime;
            if(timer > 4){
                timer = 0;
                Shoot();
            }
        }
    }

    private void Shoot(){
        Instantiate(bullet, ball.transform.position, Quaternion.identity);
    }

}
