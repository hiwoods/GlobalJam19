using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunger : MonoBehaviour
{
    [SerializeField] private float hungerValue = 100;
    public float decayRate = 1;

    public float HungerValue
    {
        get => hungerValue;
        set
        {
            hungerValue = Mathf.Clamp(value, 0, 100);
            OnHungerValueChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public event EventHandler OnHungerValueChanged;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HungerValue -= decayRate * Time.deltaTime;

        if (HungerValue <= 0)
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

            HungerValue = HungerValue + 20;
            Destroy(other.gameObject);

        }
    }
}
