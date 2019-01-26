using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    private GameObject player;
    private Hunger hunger;
    private Slider slider;
    private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        var player = GameObject.FindGameObjectWithTag("Player");
        text = GetComponentInChildren<TextMeshProUGUI>();
        hunger = player.GetComponent<Hunger>();
        hunger.OnHungerValueChanged += OnHungerChanged_EH;
    }

    private void OnDisable()
    {
        hunger.OnHungerValueChanged -= OnHungerChanged_EH;
    }

    private void OnHungerChanged_EH(object sender, EventArgs e)
    {
        slider.value = Mathf.CeilToInt((sender as Hunger).HungerValue);

        text.text = slider.value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
