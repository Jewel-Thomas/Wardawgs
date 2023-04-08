using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionState : MonoBehaviour
{
    public Player player;
    public enum State{
        Center,
        Right,
        Left
    }
    Vector3 currentPosition;
    public Vector3 centerPosition;
    public Vector3 leftPosition;
    public Vector3 rightPosition;


    public State statePosition;
    // Start is called before the first frame update
    void Start()
    {
        currentPosition = transform.position;
        centerPosition = new Vector3(0,-7.63f,0);
        leftPosition = new Vector3(-4.29f,-7.63f,0);
        rightPosition = new Vector3(4.29f,-7.63f,0);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == centerPosition)
        {
            statePosition = State.Center;
            player.isMoving = false;
        }
        if(transform.position == leftPosition)
        {
            statePosition = State.Left;
            player.isMoving = false;
        }
        if(transform.position == rightPosition)
        {
            statePosition = State.Right;
            player.isMoving = false;
        }
    }
}
