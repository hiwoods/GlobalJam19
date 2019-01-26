using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunger : MonoBehaviour
{
    public float hungerValue = 100;
    public float decayRate = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hungerValue -= decayRate * Time.deltaTime;

        if (hungerValue <= 0)
        {
            Debug.Log("Player dies");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //handle food
        if (other.gameObject.CompareTag("Food"))
        {
            Debug.Log("Player eating food");
            
            hungerValue = Mathf.Clamp(hungerValue + 20, 0, 100);

            Destroy(other.gameObject);
        }
    }
}
