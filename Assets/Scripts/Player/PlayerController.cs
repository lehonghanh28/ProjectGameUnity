using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    // public Animator moveAni;
    public int runSpeed;
    private int jumpCount = 0;
    private bool doubleJump = true;
    Animator anim;
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        //set player auto run
        transform.position += Vector3.right * runSpeed * Time.deltaTime;

        if(jumpCount == 2){
            doubleJump = false;
        }
        //set player jump
        if(Input.GetKeyDown("space") && doubleJump)
        {
            rb.velocity = Vector3.up * 8f;
            anim.SetTrigger("jump");
            jumpCount += 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D conllision)
    {
        if(conllision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
            doubleJump = true;
        }
    }
}
