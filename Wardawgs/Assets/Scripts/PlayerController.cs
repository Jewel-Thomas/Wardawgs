using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2;
    public Vector3 endRightPosition;
    public Vector3 endLeftPosition;
    float elapsedTime;
    float desiredTime = 3;
    float percentElapsed;
    RectTransform rectTransform;
    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPosition = rectTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime+=Time.deltaTime;
        percentElapsed = elapsedTime/desiredTime;
        Move();
    }

    void Move()
    {
        // Testing in Unity Editor
        #if UNITY_EDITOR
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(transform.right*100*Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            
        }
        #endif
    }
}
