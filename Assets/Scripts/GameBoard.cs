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
    public TMPro.TextMeshPro misakiTextScore;
    public TMPro.TextMeshPro utcTextScore;


    // Start is called before the first frame update
    private void Start()
    {
        engine = new TicTacToeEngine();
        scoreMisaki = 0;
        scoreUtc = 0;
        misakiTextScore.text = scoreMisaki.ToString();
        utcTextScore.text = scoreUtc.ToString();
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
            misakiTextScore.text = (++scoreMisaki).ToString();

            misakiBehavior.Win();
            misakiSantaBehavior.Win();
            utcBehavior.Loose();
            utcSantaBehavior.Loose();
        }
        else
        {
            victory.Show("Unity-chan's victory", id);
            utcTextScore.text = (++scoreUtc).ToString();

            misakiBehavior.Loose();
            misakiSantaBehavior.Loose();
            utcBehavior.Win();
            utcSantaBehavior.Win();
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