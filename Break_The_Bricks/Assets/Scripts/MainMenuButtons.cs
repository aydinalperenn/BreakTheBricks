using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{

    private void Awake()
    {
        Cursor.visible = true;

    }

    public void StartGame()
    {
        Brick.totalBrickNum = 0;
        GameObject.FindObjectOfType<Score>().GetComponent<Score>().RestartScore();
        SceneManager.LoadScene("Episode1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
