using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {

	public GameObject defenderPrefab;
	public static GameObject selectedDefender;

	private Button[] buttonArray;
	private Text costText;

	void Start () {
		buttonArray = GameObject.FindObjectsOfType<Button>();
		costText = GetComponentInChildren<Text>();

		if (!costText) {
			Debug.LogWarning( name + " has no cost text");
		}

		costText.text = defenderPrefab.GetComponent<Defenders>().currencyCost.ToString();
	}

	void Update () {
	
	}

	void OnMouseDown() {
		SetAllButtonsToBlack();

		GetComponent<SpriteRenderer>().color = Color.white;
		selectedDefender = defenderPrefab;
	}

	void SetAllButtonsToBlack() {
		foreach(Button currentButton in buttonArray) {
			currentButton.GetComponent<SpriteRenderer>().color = Color.black;
		}
	}
}
