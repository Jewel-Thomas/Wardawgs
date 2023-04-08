using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health = 500;
    [SerializeField] private float minTimeBetweenShots = 0.2f;
    [SerializeField] private float maxTimeBetweenShots = 3f;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private GameObject Explosion;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private float durationOfExplosion = 1f;
    [SerializeField] private AudioClip deathSFX;
    [SerializeField] [Range(0, 1)] private float deathSoundVolume = 0.75f;
    [SerializeField] [Range(0, 1)] private float fireSfxVolume = 0.5f;
    [SerializeField] AudioClip fireSfx;
    [SerializeField] private int scoreValue = 150;
    private float shotCounter;
    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndFire();
    }

    private void CountDownAndFire()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        GameObject laser = Instantiate(
                        laserPrefab, 
                        transform.position,
                        Quaternion.identity
                        ) as GameObject;
        AudioSource.PlayClipAtPoint(fireSfx, Camera.main.transform.position, fireSfxVolume);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6) return;
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
        GameObject explosion = Instantiate(Explosion, transform.position, Quaternion.identity) as GameObject;
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSoundVolume);
        Destroy(explosion, durationOfExplosion);
        Destroy(gameObject);
    }
}

