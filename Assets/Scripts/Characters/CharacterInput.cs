using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    public float speed;
    public float turningSpeed;
    public bool isInSafeZone;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        if (move != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(move);
        }
        rb.velocity = move * speed * Time.deltaTime;
    }

}
