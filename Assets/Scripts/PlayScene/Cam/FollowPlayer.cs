using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{   
    private GameObject player;
    
    private UnityEngine.Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new UnityEngine.Vector3(player.transform.position.x + offset.x,  transform.position.y, transform.position.z);
    }
}
