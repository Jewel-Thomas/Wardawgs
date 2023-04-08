using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationScript : MonoBehaviour
{
    public float speed = 10f;


    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(-100,100);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(transform.forward,speed*Time.deltaTime); 
    }
}
