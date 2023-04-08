using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMeteorTravel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * BackgroundScroller.fallSpeed * 0.5f * Time.deltaTime,Space.World);  
        transform.Rotate(Vector3.forward * 50 * Time.deltaTime);
        DestroyOutOfBounds();
    }

     void DestroyOutOfBounds()
    {
        if(transform.position.y < -14f)
        {
            ScoreDisplay.score += 5;
            Destroy(this.gameObject);
        }
    }
}
