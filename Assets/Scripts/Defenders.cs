using UnityEngine;
using System.Collections;

public class Defenders : MonoBehaviour {

	public int currencyCost = 100;
	private CurrencyDisplay currencyDisplay;

	void Start () {
		currencyDisplay = GameObject.FindObjectOfType<CurrencyDisplay>();
	}

	public void AddCurrency(int amount) {
		currencyDisplay.AddCurrency(amount);
	}
}
