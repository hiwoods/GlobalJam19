using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public CharacterInput player;
    

    // Update is called once per frame
    void Update()
    {
        if (!player.isAlive)
        {
            text.enabled = true;
            Time.timeScale = 0;
        }
    }
}
