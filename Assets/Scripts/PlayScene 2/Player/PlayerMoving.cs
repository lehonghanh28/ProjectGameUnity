using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;


public class PlayerMoving : MonoBehaviour
{   
    private Rigidbody2D rb;
    public float runSpeed;
    public UnityEngine.Vector3 move;
    private int jumpCount = 0;
    private bool doubleJump = true;
    Animator anim;
    public bool gameOver = false;

    public Coin nbCoin;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(!gameOver)
        {
            move.x = Input.GetAxisRaw("Horizontal");
            transform.position += move * runSpeed * Time.deltaTime;
            anim.SetFloat("run", Mathf.Abs(move.x));
            if(move.x != 0){
            if(move.x > 0){
                transform.localScale = new UnityEngine.Vector3(1, 1, 0);
            }
            else{
                transform.localScale = new UnityEngine.Vector3(-1, 1, 0);
            }
        }
        }
        if(jumpCount == 2){
            doubleJump = false;
        }

        if (Input.GetKeyDown("space") && doubleJump && !gameOver)
        {
            rb.velocity = UnityEngine.Vector3.up * 7.5f;
            anim.SetTrigger("jump");
            jumpCount += 1;
        }

        Debug.Log("Coin");

    }

    public void GameOver(){
        gameOver = true;
        anim.SetTrigger("death");  
        StartCoroutine("ShowGameOverPanel");

    }


     private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
            doubleJump = true;
        }

        if(collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }
        if(collision.gameObject.CompareTag("BottomDetector"))
        {
            GameOver();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            nbCoin.numberCoins ++;
            Destroy(collision.gameObject);
        }
    }

}
