using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemy : MonoBehaviour
{   
    public float speed = 1f;
    int dir = 1;
    public Transform rightCheck;
    public Transform leftCheck;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * dir * Time.fixedDeltaTime);
        if (Physics2D.Raycast(rightCheck.position, Vector2.down, 2) == false)
            dir = -1;

        if (Physics2D.Raycast(leftCheck.position, Vector2.down, 2) == false)
            dir = 1;

    }

}
