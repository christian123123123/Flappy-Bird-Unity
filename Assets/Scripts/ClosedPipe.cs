using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedPipe : MonoBehaviour
{
    public GameObject circleCollider;
    public GameObject pipe;
    private AudioSource openSesameSound;
    private bool isOpened = false;
    
    // Start is called before the first frame update
    void Start()
    {
        openSesameSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile") && !isOpened)
        {
            openSesameSound.Play();
            Transform upperPipe = pipe.transform.Find("pipe-up");
            upperPipe.position = new Vector3(upperPipe.position.x, upperPipe.position.y + 1.9f, upperPipe.position.z);
            isOpened = true;
        }
    }
}
