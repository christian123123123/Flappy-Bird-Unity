using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D player;
    public Logic logic;
    public GameObject projectile;
    [SerializeField]
    private float jumpPower;
    private bool spaceIsPressed;
    private bool birdIsAlive = true;
    private bool leftclickIsPressed;
    private AudioSource flapAudioSource;
    private AudioSource gameOverAudioSource;
    private AudioSource backgroundMusic;
    private AudioSource shootingSound;
    private AudioSource openSesameSound;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();

        #region "Getting Audio Components"
        flapAudioSource = GetComponents<AudioSource>()[0];
        gameOverAudioSource = GetComponents<AudioSource>()[1];
        backgroundMusic = GetComponents<AudioSource>()[2];
        shootingSound = GetComponents<AudioSource>()[3];
        #endregion

        backgroundMusic.Play();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spaceIsPressed = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left click detected");
            leftclickIsPressed = true;
        }

        if (!birdIsAlive)
        {
            Time.timeScale = 0f;
            backgroundMusic.Stop();
            logic.gameOver();
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
        // Update is called once per frame
    void FixedUpdate()
    { 
        if (spaceIsPressed && birdIsAlive)
        {
            player.velocity = Vector2.up * jumpPower * Time.deltaTime;
            flapAudioSource.Play();
        }

        if (leftclickIsPressed && birdIsAlive)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            shootingSound.Play(); 
        }

        spaceIsPressed = false;
        leftclickIsPressed = false;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Pipe"))
        {
            birdIsAlive = false;
            gameOverAudioSource.Play();
        }
    }
}
