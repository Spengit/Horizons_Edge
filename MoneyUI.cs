﻿
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyUI : MonoBehaviour
{

	public Text moneyText;

	// Update is called once per frame
	void Update()
	{
		moneyText.text = "$" + PlayerStatus.player_money.ToString();
	}
}
