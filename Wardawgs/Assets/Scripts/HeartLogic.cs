using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartLogic : MonoBehaviour
{
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public static int livesLeft; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(livesLeft == 2)
        {
            heart1.SetActive(false);
        }
        if(livesLeft == 1)
        {
            heart2.SetActive(false);
        }
        if(livesLeft == 0)
        {
            heart3.SetActive(false);
        }
    }
}
