using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBoard : MonoBehaviour
{
    public bool playerTurn; // value flip when turn change
    public bool isPlaying;

    public Button newGameButton;
    /*public Draw draw;
    public Victory victory;*/
    public TicTacToeEngine engine = new TicTacToeEngine();


    // Start is called before the first frame update
    void Start()
    {
        initGame();
    }

    void initGame()
    {
        playerTurn = false; // first player is set
        newGameButton.interactable = false;
        isPlaying = true; //activate orbManager update
        engine.NewGame();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput(); //which orb is selected ?
        engine.Place(2); //######## FIND INDEX
    }

    void GetInput()
    {
        if (Input.GetMouseButtonDown(0)) //detect touche / left click 
        {
            playerTurn = !playerTurn;
        }
    }

    void WinCondition()
    {
        var winner = engine.IsVictory();
        if (winner == -1)
        {
            //CatsGame(); // This is when there is no winner
            //GetComponent<Animation
            //GameObject.Find("gameBoard").GetComponent<gameBoard>().player_turn
        }
        else
        {
            //WinnerIs(winner - 1);
            // because in engine.IsVictory returns 1 or 2 for the winner
        }
    }

    
}