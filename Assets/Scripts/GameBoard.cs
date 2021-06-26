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

    public Button newGameButton;
    public DrawEnding draw;
    public VictoryEnding victory;
    public TicTacToeEngine engine = new TicTacToeEngine();
    public OrbManager orbManager; 


    // Start is called before the first frame update
    private void Start()
    {
        //ya r
    }

    public void InitGame()
    {
        Debug.Log("initGame");
        newGameButton.interactable = false;
        isPlaying = true; //activate orbManager update
        orbManager.InitOrbs();

        //convention: player 1 = false & player 2 = true
        playerTurn = false; // first player is set 
        engine.NewGame(playerTurn);
        gridId = -1;
        currentGridId = gridId;
    }

    // Update is called once per frame
    private void Update()
    {
        //toggle player turn
        if (Input.GetMouseButtonDown(0)) //detect touche / left click 
            playerTurn = !playerTurn;
        
    }
    
    public void WinCondition()
    {
        var winner = engine.IsVictory();
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
            victory.Show("Player " + (winner).ToString());
            // because in engine.IsVictory returns 1 or 2 for the winner
        }
    }        

    private void EndOfGame()
    {
        // We enable the 'new game' button and disable all the cells
        isPlaying = false;
        newGameButton.interactable = true;
        orbManager.Start();
    }

}