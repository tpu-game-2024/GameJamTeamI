using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    static Canvas GameOverCanvas;
    PlayerScript playerScript;
    int HP;
    // Start is called before the first frame update
    void Awake()
    {
        GameOverCanvas = GetComponent<Canvas>();
    }
    private void Update()
    {
        HP = playerScript.GetHP();
        if (HP >= 0)
        {
            GameOver();
        }
    }
    static void GameOver()
    {
        Time.timeScale = 0f;
        GameOverCanvas.enabled = true;
    }
    static public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scene1");
    }
    static public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }
}
