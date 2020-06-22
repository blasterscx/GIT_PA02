using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static HUD HUDManager;
    [SerializeField] private Text Txt_Score = null;
    [SerializeField] private Image Image_Lives = null;
    [SerializeField] private Text Txt_Message = null;
    public enum GameState {  GameOver, GameStart, GameIdle};
    public static GameState CurrentState = GameState.GameIdle;

    public static int Lives = 3;
    public static int Score = 0;
    public string highscore="Highscore";
    public Text scorecount;

    void Start()
    {
        Lives = 3;
        Score = 0;
        Time.timeScale = 0;
        CurrentState = GameState.GameIdle;
    }
    
    void Update()
    {
        if(CurrentState == GameState.GameIdle && Input.GetKeyDown(KeyCode.Return))
        {            
            CurrentState = GameState.GameStart;
            Time.timeScale = 1;
           DismissMessage();
        }

        else if(CurrentState == GameState.GameOver && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(0);
        }
        scorecount.text = Score.ToString("SCORE : " + Score);

       
            Image_Lives.rectTransform.sizeDelta = new Vector2(Lives * 50, 30);
        if (Lives == 0)
        {
            GameOver();
        }
        
    }
 
    public void life()
    {
        Lives -= 1;
        print("ouch");
    }
    public void score()
    {
        Score += 1;
        print(Score);
        print("Yeet");
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        CurrentState = GameState.GameOver;
        Txt_Message.color = Color.red;
        Txt_Message.text = "GAME OVER! \n PRESS ENTER TO RESTART GAME.";
        PlayerPrefs.SetInt(highscore, Score);
        SceneManager.LoadScene(1);
    }
    public void DismissMessage()
    {
        Txt_Message.text = "";
    }
}
