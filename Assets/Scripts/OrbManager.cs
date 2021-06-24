using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbManager : MonoBehaviour
{
    public bool stopRays;
    public float maxRayDistance = 100.0f;
    public GameObject[] orbs;
    public GameObject[] squares0;
    public GameObject[] squares1;
    public LayerMask collisionLayer = 1 << 10 ;
    public GameBoard gameBoard;

    public void Start()
    {
        for (int i = 0; i < squares0.Length; i++)
        {
            orbs[i].SetActive(false);
            squares0[i].SetActive(false);
            squares1[i].SetActive(false);
        }
    }

    public void InitOrbs()
    {
        for (int i = 0; i < squares0.Length; i++)
        {
            orbs[i].SetActive(true);
            squares0[i].SetActive(false);
            squares1[i].SetActive(false);
        }
    }

    private void Update()
    {
        if (gameBoard.isPlaying)
        {

#if UNITY_EDITOR
            if (Input.GetMouseButtonDown (0)&&!stopRays) {
                Debug.Log("ray casted");
                Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, maxRayDistance, collisionLayer))
                {
                Debug.Log("orb selected");
                    for(int k = 0; k < orbs.Length; k++)
                    {
                        if (hit.transform.gameObject.name == orbs[k].name)
                        {
                            gameBoard.engine.Place(k);
                            orbs[k].SetActive(false);
                            //Debug.Log(gameBoard.playerTurn);
                            if(gameBoard.playerTurn)
                            {
                                squares0[k].SetActive(true);
                            }
                            else
                            {
                                squares1[k].SetActive(true);
                            }
                            gameBoard.WinCondition();
                        }
                    }
                }
            }
#else
            if (Input.touchCount > 0 && !stopRays)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(Input.touchCount - 1).position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, maxRayDistance, collisionLayer))
                {
                    for (int k = 0; k < orbs.Length; k++)
                    {
                        if (hit.transform.gameObject == orbs[k])
                        {
                            gameBoard.engine.Place(k); //update game logic
                            orbs[k].SetActive(false);
                            if (gameBoard.playerTurn)
                            {
                                squares0[k].SetActive(true);
                            }
                            else
                            {
                                squares1[k].SetActive(true);
                            }
                            gameBoard.WinCondition();
                        }
                    }
                }
            }
        }
#endif
    }
}}