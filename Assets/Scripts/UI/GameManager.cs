using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI quitButton;
    public TextMeshProUGUI endGameText;
    public CharacterInput player;

    private Button btn;

    private void Start()
    {
        Time.timeScale = 1f;
        btn = endGameText.GetComponent<Button>();
        player.OnPlayerStateChanged += OnPlayerStateChange_EH;
    }

    private void OnPlayerStateChange_EH(object sender, EventArgs e)
    {
        if (!player.IsAlive)
        {
            btn.interactable = true;
            endGameText.enabled = true;
            quitButton.enabled = true;
            Time.timeScale = 0;
        }
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(1);
    }
}
