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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(!PlayerManage.gameOver1)
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

        if (Input.GetKeyDown("space") && doubleJump && !PlayerManage.gameOver1)
        {
            rb.velocity = UnityEngine.Vector3.up * 7.5f;
            anim.SetTrigger("jump");
            jumpCount += 1;
        }


    }

    // public void GameOver(){
    //     gameOver = true;
    //     anim.SetTrigger("death");  
    //     StartCoroutine("ShowGameOverPanel");

    // }


     private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
            doubleJump = true;
        }

        if(collision.gameObject.CompareTag("Obstacle"))
        {
            PlayerManage.gameOver1 = true;
            anim.SetTrigger("death");
             
        }
        if(collision.gameObject.CompareTag("BottomDetector"))
        {
            PlayerManage.gameOver1 = true;
            anim.SetTrigger("death");
            
        }
        if(collision.gameObject.CompareTag("Slime")){
            PlayerManage.gameOver1 = true;
            anim.SetTrigger("death");
        }

    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("BulletEnemy")){
            Destroy(collision.gameObject);
            PlayerManage.gameOver1 = true;
            anim.SetTrigger("death");
        }
    }    


}
