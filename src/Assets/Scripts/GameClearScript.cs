using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearScript : MonoBehaviour
{
    static Canvas GameClearCanvas;
    [SerializeField] BossHP bosshp;
    // Start is called before the first frame update
    void Awake()
    {
        GameClearCanvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        int BossHP = bosshp.GetBossHP();

        if (BossHP <= 0)
        {
            Time.timeScale = 0f;
            GameClearCanvas.enabled = true;

            if (Input.GetKey(KeyCode.Space))
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("TitleScene");
            }
        }
    }


}

