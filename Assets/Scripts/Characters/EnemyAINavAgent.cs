using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAINavAgent : MonoBehaviour
{
    private Rigidbody rb;

    public CharacterInput player;

    public Vector3 origin;

    public Coroutine goBackRoutine;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player && !player.IsInSafeZone)
        {
            agent.SetDestination(player.transform.position);
        }
        else if (!player || player.IsInSafeZone)
        {
            if (goBackRoutine == null)
                StartCoroutine(GoingBackToOrigin());
        }
    }

    private IEnumerator GoingBackToOrigin()
    {
        yield return new WaitForSecondsRealtime(3);

        if (!player || player.IsInSafeZone)
        {
            agent.SetDestination(origin);
        }
        goBackRoutine = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (player == null)
                player = other.gameObject.GetComponent<CharacterInput>();
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
                player.IsAlive = false;
            else
            {
                player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInput>();
                player.IsAlive = false;
            }

        }
    }
}
