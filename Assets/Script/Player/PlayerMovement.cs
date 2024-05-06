using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator moveAni;
    public int speed = 4;
    public float move;
    public bool flipRight = true;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        //Di chuyen trai phai
        move = Input.GetAxisRaw("Horizontal"); //A = -1,0  D = 1
        rb.velocity = new Vector2(speed*move, rb.velocity.y);
        
        //Check quay dau
        if(flipRight == true && move == -1)
        {
            transform.localScale = new Vector3(-1 , 1, 1);
            flipRight = false;
        }
        if(flipRight == false && move == 1)
        {
            transform.localScale = new Vector3(1 , 1, 1);
            flipRight = true;
        }

        //Animation
        moveAni.SetFloat("moveAnimator", Mathf.Abs(move));

    }
}
