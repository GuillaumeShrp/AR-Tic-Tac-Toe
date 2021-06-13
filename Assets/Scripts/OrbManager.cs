using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbManager : MonoBehaviour
{
    public bool stopRays;
    public float maxRayDistance = 100.0f;
    public GameObject[] orbs;
    public GameObject square;
    public LayerMask collisionLayer = 1 << 10 ;

    void Start()
    {
        square.SetActive(false);
    }

    void Update()
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
                        orbs[k].SetActive(false);
                        square.SetActive(true);
                        //if with reference to game manager to know wich object to reveal
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
                        //TOCOPY
                    }
                }
            }

        }
#endif
    }
}