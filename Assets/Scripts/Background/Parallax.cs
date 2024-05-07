using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject camera;
    public float parallaxEf;
    private float width, positionX;
    void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x;
        positionX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float parallaxDistance = camera.transform.position.x * parallaxEf;
        float remainingDistance = camera.transform.position.x * (1 - parallaxEf);
    
        transform.position = new Vector3(positionX + parallaxDistance, transform.position.y, transform.position.z);

        if(remainingDistance > positionX + width)
        {
            positionX += width;
        }
    }

}
