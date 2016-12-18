using UnityEngine;
using System.Collections;

public class CurrencySpawner : MonoBehaviour {

	public Sprite[] currencyModels;

	private GameObject currency;

	void Start() {
		currency = transform.GetChild(0).GetChild(0).gameObject;
	}

	public void SetActiveCurrencyModel() {
		currency.GetComponent<SpriteRenderer>().sprite = currencyModels[Random.Range(0, currencyModels.Length)];
	}
}
