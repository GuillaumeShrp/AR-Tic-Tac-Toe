using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryEnding : MonoBehaviour
{
	public TMPro.TextMeshProUGUI _text;

	public Color32 misakiColor = new Color32(184, 230, 255, 120);
	public Color32 utcColor = new Color32(179, 143, 53, 120);

	public void Show(string token, int id)
	{
		gameObject.SetActive(true);
		if(id==0)
			GetComponent<Image>().color = misakiColor;
        else
			GetComponent<Image>().color = utcColor;

		_text.text = token;
		StartCoroutine(WaitForIt());
	}

	IEnumerator WaitForIt()
	{
		yield return new WaitForSeconds(3);
		gameObject.SetActive(false);
	}
}
