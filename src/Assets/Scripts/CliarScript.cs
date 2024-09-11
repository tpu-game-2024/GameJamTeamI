using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCliarScript : MonoBehaviour
{
    static Canvas GameCliarCanvas;
    [SerializeField] PlayerScript playerScript;
    int HP;
    // Start is called before the first frame update
    void Awake()
    {
        GameCliarCanvas = GetComponent<Canvas>();
    }
    public void Update()
    {
        //        Debug.Log(HP);
        HP = playerScript.GetHP();
        if (HP <= 0)
        {
            GameCliar();
            if (Input.GetKey(KeyCode.Space))
            {
                Retry();
            }
        }
    }
    static void GameCliar()
    {
        Time.timeScale = 0f;
        GameCliarCanvas.enabled = true;
    }
    static public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScene");
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