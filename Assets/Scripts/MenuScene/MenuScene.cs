using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    public const int Maingame_Scene = 0;
    public const int Menu_Scene = 1;

    public void LoadMainGame()
    {
        SceneManager.LoadScene(Maingame_Scene);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
