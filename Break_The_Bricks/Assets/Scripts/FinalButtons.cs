using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalButtons : MonoBehaviour
{

    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        Cursor.visible = true;

    }

    private void Start()
    {
        scoreText.text = "Score: " + GameObject.FindObjectOfType<Score>().GetComponent<Score>().GetScore();
        // �zerinde score scripti olan objemize eri�ip, score scriptini �ekip, score scriptindeki getscore fonksiyonunu �a��r�yoruz.
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
