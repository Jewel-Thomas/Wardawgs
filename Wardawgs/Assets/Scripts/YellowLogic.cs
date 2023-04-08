using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowLogic : MonoBehaviour
{
    
    public bool check;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * BackgroundScroller.fallSpeed/3 * Time.deltaTime,Space.World);
        DestroyOutOfBounds();
    }

    void DestroyOutOfBounds()
    {
        if(transform.position.y < -14f)
        {
            Destroy(this.gameObject);
        }
    }


    
}
