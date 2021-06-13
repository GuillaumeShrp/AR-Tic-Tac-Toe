using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateOrb();
        GetInput();

    }

    void GetInput()
    {
        if(Input.GetMouseButton(0))
        //detect touche / left click 
        {
            //changeOrb = true;
        }
    }

    void UpdateOrb()
    {
        //transform.
    }
}
