using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    public bool player_turn; // value flip when turn change
    public bool win;
    // Start is called before the first frame update
    void Start()
    {
        initGame();
    }

    void initGame()
    {
        win = false;
        //init player turn (random or choosen)
        //reset gameboard
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput(); //which orb is selected ?
        UpdateOrb(); //associated player pawn to display
        CheckWinner();

    }

    void GetInput()
    {
        if(Input.GetMouseButtonDown(0)) //detect touche / left click 
        {
            player_turn = !player_turn;
        }
    }

    void UpdateOrb()
    {
        //transform.
    }

    void CheckWinner()
    {
        if (win)
        {
            Celebration();
        }
    }

    void Celebration()
    {
        //animation launch
    }
}
