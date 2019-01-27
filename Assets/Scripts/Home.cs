using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    public Transform roof;

    // Start is called before the first frame update
    void Start()
    {
        roof = transform.Find("roof");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("somebody is in house");

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player enter house");

            roof.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("player left");

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player left house");

            roof.gameObject.SetActive(true);
        }

    }
}
