using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform playerPos;
    public GameObject projectile;
    public float speed;
    private bool leftclickIsPressed;


    public void Start()
    {
        playerPos = GetComponent<Transform>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left click detected");
            leftclickIsPressed = true;
        } 
    }

    private void FixedUpdate()
    {
        if (leftclickIsPressed)
        {
            Debug.Log("Instantiating projectile");
            Instantiate(projectile, playerPos.position, playerPos.rotation);
            leftclickIsPressed = false;
        }

    }
}
