using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private float backgroundScrollSpeed = 0.2f;
    private Vector2 offset;
    private Material blueSpace;
    void Start()
    {
        blueSpace = gameObject.GetComponent<Renderer>().material;
        offset = new Vector2(0, backgroundScrollSpeed);
    }
    
    void Update()
    {
        blueSpace.mainTextureOffset += offset * Time.deltaTime;
        backgroundScrollSpeed += Time.deltaTime*0.01f;
        offset = new Vector2(0, backgroundScrollSpeed);
    }
}
