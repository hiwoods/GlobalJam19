using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    public float speed;
    public bool isInSafeZone;
    [SerializeField] private bool isAlive = true;
    private Rigidbody rb;

    public bool IsAlive {
        get => isAlive;
        set
        {
            isAlive = value;
            OnPlayerStateChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public event EventHandler OnPlayerStateChanged;

    private void Start()
    {
        isAlive = true;
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        if (move != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(move);
            rb.angularVelocity = Vector3.zero;
        }
        rb.velocity = move * speed * Time.deltaTime;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("House"))
        {
            Debug.Log("Plaeyr enters the house");

            isInSafeZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("House"))
        {
            Debug.Log("Plaeyr exits the house");

            isInSafeZone = false;
        }
    }
}
