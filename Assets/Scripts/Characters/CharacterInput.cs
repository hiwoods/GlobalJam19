using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    public float speed;
    [SerializeField] private bool isInSafeZone;
    [SerializeField] private bool isAlive = true;
    private Rigidbody rb;
    private AudioSource source;
    public bool IsAlive
    {
        get => isAlive;
        set
        {
            isAlive = value;

            if (!isAlive)
            {
                source.Stop();
            }
            OnPlayerStateChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public bool IsInSafeZone
    {
        get => isInSafeZone;
        set
        {
            isInSafeZone = value;
            OnPlayerStateChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public event EventHandler OnPlayerStateChanged;

    private void Start()
    {
        source = GetComponent<AudioSource>();
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

            IsInSafeZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("House"))
        {
            Debug.Log("Plaeyr exits the house");

            IsInSafeZone = false;
        }
    }
}
