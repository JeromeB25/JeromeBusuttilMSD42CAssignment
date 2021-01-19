using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //SerializeFields 
    [SerializeField] float playerMoveSpeed = 10f;
    [SerializeField] float padding = 0.1f;
    [SerializeField] float health = 50f;

    //SerializeFields
    //Sound
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 1f;

    [SerializeField] AudioClip CrashSound; 
    [SerializeField] [Range(0, 1)] float CrashSoundVolume = 1f;

    //Particles
    [SerializeField] GameObject ExplosionParticles;
    [SerializeField] float Particletime = 1f;

    float xMin, xMax, yMin, yMax; 

    // Start is called before the first frame update
    void Start()
    {
        GameCamera();
    }

    private void GameCamera()
    {
        Camera gamecamera = Camera.main;

        xMin = gamecamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gamecamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gamecamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gamecamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding; 
    }
    // Update is called once per frame
    void Update()
    {
        playerMove();   
    }

    private void playerMove()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * playerMoveSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);

        transform.position = new Vector2(newXPos, yMin); 
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        //access the DamageDealer class from otherObject which hits enemy and reduce health accordingly
        ObstacleDamageDealer dmgDealer = otherObject.gameObject.GetComponent<ObstacleDamageDealer>();

        if (!dmgDealer)
        {
            return;
        }

        ProcessHit(dmgDealer);
    }

    private void ProcessHit(ObstacleDamageDealer dmgDealer)
    {
        health -= dmgDealer.Damage();

        dmgDealer.ObstacleHit();
        AudioSource.PlayClipAtPoint(CrashSound, Camera.main.transform.position, CrashSoundVolume);


        GameObject Particles = Instantiate(ExplosionParticles, transform.position, Quaternion.identity);
        Destroy(Particles, Particletime);

        if (health <= 0)
        {
            Die();
        }
    }

    public float GetHealth()
    {
        return health; 
    }

    private void Die()
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
        //Find the Level object and run its methond LoadGameOver()
        FindObjectOfType<Level>().LoadGameOver();
    }
}
