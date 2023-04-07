using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private float backgroundScrollSpeed = 0.2f;
    private Vector2 offSet;
    private Material blueSpace;
    void Start()
    {
        blueSpace = gameObject.GetComponent<Renderer>().material;
        offSet = new Vector2(0, backgroundScrollSpeed);
    }
    
    void Update()
    {
        blueSpace.mainTextureOffset += offSet * Time.deltaTime;
    }
}
