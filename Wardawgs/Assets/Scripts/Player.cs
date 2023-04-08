using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //configuration parameters 
    [Header("Player")] 
    [SerializeField] private int health = 200;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float padding = 2f;
    
    [Header("SFX")] 
    [SerializeField] [Range(0, 1)] private float deathSoundVolume = 0.75f;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] [Range(0, 1)] private float fireSfxVolume = 0.25f;
    [SerializeField]  AudioClip fireSfx;

    [Header("VFX")] 
    [SerializeField] private GameObject explosion;
    [SerializeField] private float durationOfExplosion = 1f;
    
    [Header("Projectile")]
    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float projectileFiringPeriod = 0.1f;

    private Coroutine firingCoroutine;
    private float xMin;
    private float xMax;

    private float yMin;
    private float yMax;
    private bool isFiring = false;
    public Vector3 endPosition;
    public float elapsedTime;
    public float desiredTime = 5;
    public bool isMoving = false;
    public bool isRight = false;
    public AnimationCurve curve;
    public PositionState positionState;
    public float swipeSpeed = 0.01f;
    private Touch touch;
    private Vector2 screenBounds;
    public static bool isAlive = true;
    public static bool isYellow = false;
    public static bool isRed = false;
    public static bool isBlue = false;
    public GameObject MultiLaserPrefab;
    public GameObject SpreadLaserPrefab;
    public GameObject shield;
    CircleCollider2D coll;

    // Start is called before the first frame update
    private void Start()
    {
        coll = GetComponent<CircleCollider2D>();
        ScoreDisplay.score = 0;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,
        Camera.main.transform.position.z));
        isAlive = true;
        isYellow = false;
        isRed = false;
        isBlue = false;
        HeartLogic.livesLeft = 3;
    }

    // Update is called once per frame
    private void Update()
    {
        SwipeMotion();
        // Fire();
        if(transform.position.x >= screenBounds.x-0.52f)
        {
            transform.position = new Vector3(screenBounds.x-0.52f,transform.position.y,transform.position.z);
        }
        if(transform.position.x <= -screenBounds.x+0.52f)
        {
            transform.position = new Vector3(-screenBounds.x+0.52f,transform.position.y,transform.position.z);
        }
    }

    public void Fire()
    {
        if(isYellow)
        {
            GameObject multiLaser = Instantiate(MultiLaserPrefab,transform.position,
            Quaternion.identity) as GameObject;
            AudioSource.PlayClipAtPoint(fireSfx, Camera.main.transform.position, fireSfxVolume);
            Rigidbody2D[] rb2Ds = multiLaser.GetComponentsInChildren<Rigidbody2D>();
            foreach (Rigidbody2D rb2D in rb2Ds)
            {
                rb2D.velocity = new Vector2(0,projectileSpeed);
            }
        }
        else if(isRed)
        {
            GameObject spreadLaser = Instantiate(MultiLaserPrefab,transform.position,
            Quaternion.identity) as GameObject;
            GameObject spreadLaser1 = Instantiate(MultiLaserPrefab,transform.position,
            Quaternion.identity) as GameObject;
            AudioSource.PlayClipAtPoint(fireSfx, Camera.main.transform.position, fireSfxVolume);
            Rigidbody2D[] rb2Ds = spreadLaser.GetComponentsInChildren<Rigidbody2D>();
            Rigidbody2D[] rb2D1s = spreadLaser1.GetComponentsInChildren<Rigidbody2D>();
            foreach (Rigidbody2D rb2D in rb2Ds)
            {
                rb2D.velocity = new Vector2(projectileSpeed,projectileSpeed);
            }
            foreach (Rigidbody2D rb2D in rb2D1s)
            {
                rb2D.velocity = new Vector2(-projectileSpeed,projectileSpeed);
            }
        }
        else
        {
            GameObject laser = Instantiate(laserPrefab,
            transform.position,
            Quaternion.identity) as GameObject;
            AudioSource.PlayClipAtPoint(fireSfx, Camera.main.transform.position, fireSfxVolume);
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0,projectileSpeed);
        }
    }

    private IEnumerator FireContinuously()
    {
        while(true)
        {
            GameObject laser = Instantiate(
                        laserPrefab, 
                        transform.position, 
                        Quaternion.identity) as GameObject; 
            AudioSource.PlayClipAtPoint(fireSfx, Camera.main.transform.position, fireSfxVolume);
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }

    void SwipeMotion()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * swipeSpeed,transform.position.y,transform.position.z);
            }
        }
    }


  

    private void OnTriggerEnter2D(Collider2D other)
    {
        // DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        // ProcessHit(damageDealer);
        if(other.CompareTag("Meteor") || other.CompareTag("Big Meteor"))
        {
            HeartLogic.livesLeft--;
            if(HeartLogic.livesLeft <=0)
            {
                Die();               
            }
        }
        if(other.CompareTag("MultiLaser"))
        {
            Destroy(other.gameObject);
            StartCoroutine(MultiPowerUp());
        }
        if(other.CompareTag("SpreadLaser"))
        {
            Destroy(other.gameObject);
            StartCoroutine(SpreadPowerUp());
        }
        if(other.CompareTag("Shield"))
        {
            Destroy(other.gameObject);
            StartCoroutine(ShieldPowerUp());
        }
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        if (health <= 0)
        {
            Die();
        }
    }

    public int GetHealth()
    {
        return health;
    }

    private void Die()
    {
        isAlive = false;
        FindObjectOfType<Level>().LoadGameOver();
        GameObject explosionVFX = Instantiate(explosion, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
        Destroy(explosionVFX, durationOfExplosion);
        Destroy(gameObject);
    }

    public IEnumerator MultiPowerUp()
    {
        isYellow = true;
        yield return new WaitForSeconds(5);
        isYellow = false;
    }

    public IEnumerator SpreadPowerUp()
    {
        isRed = true;
        yield return new WaitForSeconds(5);
        isRed = false;
    }

    public IEnumerator ShieldPowerUp()
    {
        shield.SetActive(true);
        coll.enabled = false;
        yield return new WaitForSeconds(5);
        coll.enabled = true;
        shield.SetActive(false);
    }

}
