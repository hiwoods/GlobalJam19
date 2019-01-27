using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public bool IsAvailable;
    public float Value = 10;
    public float respawnTime = 30f;
    private MeshRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }
    
    public void Consume()
    {
        renderer.enabled = false;
        IsAvailable = false;

        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnTime);

        IsAvailable = true;
        renderer.enabled = true;
    }
}
