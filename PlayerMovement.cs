using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed =20f;
    private Rigidbody2D rb;
    public float rollDuration = 0.5f;
    public float rollSpeed = 10f;
    public float rollAcceleration = 30f;
    private bool isRolling = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput) * playerSpeed;
        rb.velocity = movement;


        if (Input.GetKey(KeyCode.Space) && !isRolling)
        {
            isRolling = true;
            StartCoroutine(Roll());

        }

    }

    IEnumerator Roll()
    {
        float rollTime = 0f;
        Vector2 rollDirection = rb.velocity.normalized;

        while (rollTime < rollDuration)
        {
            rb.velocity = rollDirection * Mathf.Lerp(rollSpeed, rollAcceleration, rollTime / rollDuration);
            rollTime += Time.deltaTime;
            yield return null;
        }

        isRolling = false;

    }
}
