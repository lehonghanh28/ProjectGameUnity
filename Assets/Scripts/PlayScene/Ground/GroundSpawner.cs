using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject Ground1, Ground2, Ground3, Ground4;
    bool hasGround = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasGround)
        {
            SpawnGround();
            hasGround = true;
        }
    }

    public void SpawnGround(){
        int randomNum = Random.Range(1, 5);

        if(randomNum == 1)
        {
            Instantiate(Ground1, new Vector3(transform.position.x + 3, -4.36f, 0), Quaternion.identity);
        }

        if(randomNum == 2)
        {
            Instantiate(Ground2, new Vector3(transform.position.x + 4, -3.0f, 0), Quaternion.identity);
        }

        if(randomNum == 3)
        {
            Instantiate(Ground3, new Vector3(transform.position.x + 5, 0.1f, 0), Quaternion.identity);
        }

        if(randomNum == 4)
        {
            Instantiate(Ground4, new Vector3(transform.position.x + 7, 2.0f, 0), Quaternion.identity);
        }
    }
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            hasGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            hasGround = false;
        }
    }
}
