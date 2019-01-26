using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 50;

    private Rigidbody rb;

    private Transform chaseTarget;

    private Vector3 origin; 

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        origin = transform.position;
    }

    private void Update()
    {
        if (chaseTarget)
        {
            var direction = (chaseTarget.position - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(direction);
            rb.velocity = direction * speed * Time.deltaTime;
        }
        else
        {
            rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.zero;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("chasing player");
            var player = other.gameObject.GetComponent<CharacterInput>();
            if (!player.isInSafeZone)
            {
                chaseTarget = other.transform;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("chasing player");
            var player = other.gameObject.GetComponent<CharacterInput>();
            if (!player.isInSafeZone)
            {
                chaseTarget = other.transform;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("lost player");
            chaseTarget = null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Kill the player");
        }
    }
}
