using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtcBehavior : MonoBehaviour
{
    public Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();

    }

    public void Loose()
    {
        anim.Play("KneelDown", -1, 0f);

    }

    public void Win()
    {
        anim.Play("Salute", -1, 0f);

    }
}
