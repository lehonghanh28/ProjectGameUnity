using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float runSpeed;
    private int jumpCount = 0;
    private bool doubleJump = true;
    Animator anim;
    public bool gameOver = false;
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        StartCoroutine("IncreaseSpeed");
    }

    // Update is called once per frame
    void Update()
    {   
        if(!gameOver)
        {
            transform.position += Vector3.right * runSpeed * Time.deltaTime;
        }
        //set player auto run

        if(jumpCount == 2){
            doubleJump = false;
        }
        //set player jump
        if(Input.GetKeyDown("space") && doubleJump && !gameOver)
        {
            rb.velocity = Vector3.up * 7.5f;
            anim.SetTrigger("jump");
            jumpCount += 1;
        }
    }

    public void GameOver(){
        gameOver = true;
        anim.SetTrigger("death");
        StopCoroutine("IncreaseSpeed");   
    }

    private void OnCollisionEnter2D(Collision2D conllision)
    {
        if(conllision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
            doubleJump = true;
        }
        if(conllision.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }
        if(conllision.gameObject.CompareTag("BottomDetector"))
        {
            GameOver();
        }
    }

    IEnumerator IncreaseSpeed()
    {
        while(true){
            yield return new WaitForSeconds(10);
            if(runSpeed < 8)
            {
                runSpeed += 0.2f;
            }
            if(GameObject.Find("GroundSpawner").GetComponent<ObstacleSpawn>().obsSpawnInterval > 1)
            {
                GameObject.Find("GroundSpawner").GetComponent<ObstacleSpawn>().obsSpawnInterval -= 0.1f;
            }
        }
    }
}
