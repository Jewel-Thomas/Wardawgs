using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorHealth : MonoBehaviour
{
    public GameObject Explosion;
    public float health = 10;
    public AudioClip deathSFX;
    // Start is called before the first frame update
    void Start()
    {
        health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Laser"))
        {
            if(health <= 0)
            {
                Destroy(this.gameObject);
                Destroy(other.gameObject);
                GameObject explosion = Instantiate(Explosion, transform.position, Quaternion.identity) as GameObject;
                AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, 1);
                Destroy(explosion,1);
                ScoreDisplay.score += 10;
            }
            else
            {
                health-=10;
            }
            
        }
    }
}
