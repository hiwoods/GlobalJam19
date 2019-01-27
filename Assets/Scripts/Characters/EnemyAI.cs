using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 50;

    private Rigidbody rb;

    public CharacterInput player;
    private Vector3 moveTarget;

    private Vector3 origin;

    private Coroutine goBackRoutine;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        origin = transform.position;
    }

    private void Update()
    {
        if (player && !player.isInSafeZone)
        {
            MoveTo(player.transform.position);
            moveTarget = Vector3.zero;
        }
        else if (moveTarget != Vector3.zero)
        {
            MoveTo(moveTarget);

            if (Vector3.Distance(transform.position, origin) < 0.1f)
            {
                moveTarget = Vector3.zero;
            }
        }
        else
        {
            rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.zero;
            if (goBackRoutine == null)
                goBackRoutine = StartCoroutine(GoingBackToOrigin());
        }

        void MoveTo(Vector3 position)
        {
            var direction = (position - transform.position).normalized;
            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(direction);
            }
            rb.velocity = direction * speed * Time.deltaTime;
        }
    }

    private IEnumerator GoingBackToOrigin()
    {
        yield return new WaitForSeconds(2);
        
        if (!player || player.isInSafeZone)
        {
            moveTarget = origin;
        }
        goBackRoutine = null;
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!player)
                player = other.gameObject.GetComponent<CharacterInput>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            if (!player)
            {
                player = other.gameObject.GetComponent<CharacterInput>();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (player)
                player.isAlive = false;
            else
            {
                player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInput>();
                player.isAlive = false;
            }
       
        }
    }
}
