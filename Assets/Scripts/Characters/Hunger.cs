using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunger : MonoBehaviour
{
    public float maxHunger = 100;
    [SerializeField] private float hungerValue = 80;
    public float decayRate = 1;

    public float HungerValue
    {
        get => hungerValue;
        set
        {
            hungerValue = Mathf.Clamp(value, 0, maxHunger);
            OnHungerValueChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public event EventHandler OnHungerValueChanged;


    private CharacterInput player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterInput>();
    }

    // Update is called once per frame
    void Update()
    {
        HungerValue -= decayRate * Time.deltaTime;

        if (HungerValue <= 0)
        {
            player.IsAlive = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //handle food
        if (other.gameObject.CompareTag("Food"))
        {
            Debug.Log("Player eating food");

            var food = other.gameObject.GetComponent<Food>();

            if (food.IsAvailable)
            {
                HungerValue = HungerValue + food.Value;
                food.Consume();
            }
        }
    }
}
