using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    static Canvas GameOverCanvas;
    [SerializeField]PlayerScript playerScript;
    int HP;
    // Start is called before the first frame update
    void Awake()
    {
        GameOverCanvas = GetComponent<Canvas>();
    }
    public void Update()
    {
//        Debug.Log(HP);
        HP = playerScript.GetHP();
        if (HP <= 0)
        {
            GameOver();
            if(Input.GetKey(KeyCode.Space))
            {
                Retry();
            }
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
        SceneManager.LoadScene("TitleScene");
    }
}
