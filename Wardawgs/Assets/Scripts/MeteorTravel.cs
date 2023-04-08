using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorTravel : MonoBehaviour
{
    public BackgroundScroller backgroundScroller;
    // Start is called before the first frame update
    void Start()
    {
        backgroundScroller = GameObject.FindGameObjectWithTag("BackGround").GetComponent<BackgroundScroller>();
    }

    // Update is called once per frame
    void Update()
    {
        // speed += backgroundScroller.backgroundScrollSpeed; 
        transform.Translate(Vector3.down * BackgroundScroller.fallSpeed * Time.deltaTime,Space.World);  
        transform.Rotate(Vector3.forward * 100 * Time.deltaTime);
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
