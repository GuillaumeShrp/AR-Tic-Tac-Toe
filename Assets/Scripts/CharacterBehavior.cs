using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    public Animator anim;
	public TMPro.TextMeshPro _text1;
    public TMPro.TextMeshPro _text2; 
    public Vector3 scaleChange;

    public void Start()
    {
        anim = GetComponent<Animator>();
        scaleChange = new Vector3(3, 3, 3);
    }

    public void Loose()
    {
        anim.Play("KneelDown", -1, 0f);
    }

    public void Win()
    {
        anim.Play("Salute", -1, 0f);
    }

    public void UpdateScore(int score)
    {
        _text1.text = score.ToString();
        _text2.text = score.ToString();
        transform.localScale = new Vector3( transform.localScale.x + score, 
                                            transform.localScale.y + score, 
                                            transform.localScale.z + score);
    }
}
