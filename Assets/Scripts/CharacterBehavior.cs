using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    public Animator anim;

    public void Loose()
    {
        Debug.Log("LooseAnimation");
        anim.Play("KneelDown", -1, 0f);
        Rescale(-1);
    }

    public void Win()
    {
        Debug.Log("LooseWin");
        anim.Play("Salute", -1, 0f);
        Rescale(1);
    }

    public void Rescale(int v)
    {
        transform.localScale = new Vector3(transform.localScale.x + v,
                                                transform.localScale.y + v,
                                                transform.localScale.z + v);
    }
}
