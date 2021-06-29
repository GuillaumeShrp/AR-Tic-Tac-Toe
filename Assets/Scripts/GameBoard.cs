using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBoard : MonoBehaviour
{
    public bool playerTurn; // value flip when turn change
    public bool isPlaying;
    public int currentGridId;
    public int gridId;
    public int scoreMisaki;
    public int scoreUtc;

    public DrawEnding draw;
    public VictoryEnding victory;
    public TicTacToeEngine engine;
    public OrbManager orbManager;
    public CharacterBehavior misakiBehavior;
    public CharacterBehavior misakiSantaBehavior;
    public CharacterBehavior utcBehavior;
    public CharacterBehavior utcSantaBehavior;
    public GameObject misakiCube;
    public GameObject utcCube;


    // Start is called before the first frame update
    private void Start()
    {
        engine = new TicTacToeEngine();
        scoreMisaki = 0;
        scoreUtc = 0;
        misakiBehavior.UpdateScore(scoreMisaki);
        utcBehavior.UpdateScore(scoreUtc);
    }

    public void InitGame()
    {
        Debug.Log("initGame");
        isPlaying = true; //activate orbManager update
        orbManager.InitOrbs();

        //convention: player 1 = false & player 2 = true
        playerTurn = false; // first player is set 
        engine.NewGame(playerTurn);
        gridId = -1;
        currentGridId = gridId;

        misakiCube.SetActive(playerTurn);
        utcCube.SetActive(!playerTurn);
    }
    
    public void WinCondition()
    {
        var winner = engine.IsVictory();
        Debug.Log(winner);
        if (winner == -1) // This is when there is no winner
        {
            EndOfGame();
            Debug.Log("DrawEnding");
            draw.Show();
        }
        else if (winner > 0)
        {
            EndOfGame();
            Debug.Log("VictoryEnding");
            // because in engine.IsVictory returns 1 or 2 for the winner
            WinnerIsAnimation(winner - 1);
        }
    }

    private void WinnerIsAnimation(int id)
    {
        if (id == 0)
        {
            victory.Show("Misaki's victory", id);
            misakiBehavior.Win();
            misakiSantaBehavior.Win();
            utcBehavior.Loose();
            utcSantaBehavior.Loose();
            misakiBehavior.UpdateScore(++scoreMisaki);
            misakiSantaBehavior.UpdateScore(++scoreMisaki);
        }
        else
        {
            victory.Show("Unity-chan's victory", id);
            misakiBehavior.Loose();
            misakiSantaBehavior.Loose();
            utcBehavior.Win();
            utcBehavior.UpdateScore(++scoreUtc);
            utcSantaBehavior.UpdateScore(++scoreUtc);
        }
    }

    private void EndOfGame()
    {
        // We enable the 'new game' button and disable all the cells
        isPlaying = false;
        misakiCube.SetActive(true);
        utcCube.SetActive(true);
        orbManager.Start();
    }

}