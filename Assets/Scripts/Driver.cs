using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 250f;
    [SerializeField] float defaultSpeed = 20f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float bumpSpeed = 15f;
    [SerializeField] float boostSpeed = 25f;

    void Update()
    {
        // movement controller
        InputController(steerSpeed, moveSpeed);

        // speed perks
        // SpeedPerks(bumpSpeed, boostSpeed);
    }

    void InputController(float steerSpeed, float moveSpeed) 
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);

        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(0, moveAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(moveSpeed > 20)
        {
            moveSpeed = defaultSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
         if (other.tag == "BumpSpeed") 
        {
            Debug.Log("Speed decreased");
            moveSpeed = bumpSpeed;
        }
        
        if (other.tag == "BoostSpeed") 
        {
            Debug.Log("Speed increased");
            moveSpeed = boostSpeed;
        }
    }
}
