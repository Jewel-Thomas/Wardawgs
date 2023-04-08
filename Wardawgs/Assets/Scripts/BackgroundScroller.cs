using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float backgroundScrollSpeed = 0.2f;
    private Vector2 offSet;
    private Material blueSpace;
    public static float fallSpeed = 10;
    void Start()
    {
        backgroundScrollSpeed = 0.2f;
        blueSpace = gameObject.GetComponent<Renderer>().material;
        InvokeRepeating("IncreaseSpeed",30,30);
    }
    
    void Update()
    {
        if(Player.isAlive)
        {
            blueSpace.mainTextureOffset += offSet * Time.deltaTime;
            offSet = new Vector2(0, backgroundScrollSpeed);
            backgroundScrollSpeed+=Time.deltaTime*0.01f;
        }
        else
        {
            CancelInvoke();   
        }
        
    }
    void IncreaseSpeed()
    {
        fallSpeed+=5;
    }
}
