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
        // üzerinde score scripti olan objemize eriþip, score scriptini çekip, score scriptindeki getscore fonksiyonunu çaðýrýyoruz.
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
