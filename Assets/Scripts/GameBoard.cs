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

    public DrawEnding draw;
    public VictoryEnding victory;
    public TicTacToeEngine engine = new TicTacToeEngine();
    public OrbManager orbManager;
    public MisakiBehavior misakiBehavior;
    public UtcBehavior utcBehavior;
    public GameObject misakiCube;
    public GameObject utcCube;


    // Start is called before the first frame update
    private void Start()
    {
        //ya r
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

    // Update is called once per frame
    private void Update()
    {
        //toggle player turn
        /*if (Input.GetMouseButtonDown(0) && isPlaying) //detect touche / left click 
        {
            playerTurn = !playerTurn;
        }*/
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
            utcBehavior.Loose();
        }
        else
        {
            victory.Show("Unity-chan's victory", id);
            misakiBehavior.Loose();
            utcBehavior.Win();
        }
    }

    private void EndOfGame()
    {
        // We enable the 'new game' button and disable all the cells
        isPlaying = false;
        misakiCube.SetActive(false);
        utcCube.SetActive(false);
        orbManager.Start();
    }

}