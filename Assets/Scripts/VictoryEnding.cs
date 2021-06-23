using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryEnding : MonoBehaviour
{
	public TMPro.TextMeshProUGUI _text;
	public void Show(string token)
	{
		gameObject.SetActive(true);
		_text.text = token;
		StartCoroutine(WaitForIt());

	}

	IEnumerator WaitForIt()
	{
		yield return new WaitForSeconds(3);
		gameObject.SetActive(false);
	}
}
