using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour {

    float timer;
    float endTimer;

    public static bool gameON;

    public Text timerText;

    public Text P1Carry;
    public Text P1Total;

    public Text P2Carry;
    public Text P2Total;

    public Text player1Win;
    public Text player2Win;

    private void Start()
    {
        gameON = true;
        timer = 120;
        endTimer = 125;
        player1Win.text = "";
        player2Win.text = "";
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        endTimer -= Time.deltaTime;

        timerText.text = "" + timer.ToString("F1");

        P2Carry.text = "" + Player_2_Move.player2Carry.ToString();
        P1Carry.text = "" + Player_1_Move.player1Carry.ToString();

        P2Total.text = "" + Player_2_Move.player2Total.ToString();
        P1Total.text = "" + Player_1_Move.player1Total.ToString();

        if (timer <= 0)
        {
            timerText.text = "";
            gameON = false;
            Announce();
        }

        if (endTimer <= 0 || Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    void Announce()
    {

        if(Player_1_Move.player1Total > Player_2_Move.player2Total)
        {
            player1Win.text = "BLUE IS WIN!";
        }
        else if(Player_1_Move.player1Total == Player_2_Move.player2Total)
        {
            player1Win.text = "DRAW!";
        }

        if (Player_1_Move.player1Total < Player_2_Move.player2Total)
        {
            player2Win.text = "RED IS WIN!";
        }
        else if (Player_1_Move.player1Total == Player_2_Move.player2Total)
        {
            player2Win.text = "DRAW!";
        }
    }


}
