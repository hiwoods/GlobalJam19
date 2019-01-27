using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    AudioSource audioData;
    public AudioClip clip;
    
    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
               

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("somebody is in house");

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player enter house");

            audioData.Play();

            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("player left");

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player left house");
            audioData.Stop();

        }

    }
}