using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Text))]
public class CurrencyDisplay : MonoBehaviour {

	public enum Status {SUCCESS, FAILURE};

	private Text currencyText;
	private int currency = 100;


	void Start() {
		currencyText = GetComponent<Text>();
		UpdateDisplay();
	}

	public void AddCurrency(int amount) {
		currency += amount;
		UpdateDisplay();
	}

	public Status UseCurrency(int amount) {
		if (currency>= amount) {
			currency -= amount;
			UpdateDisplay();
			return Status.SUCCESS;
		}

		return Status.FAILURE;
	}

	private void UpdateDisplay() {
		currencyText.text = currency.ToString();
	}
}
