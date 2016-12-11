using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public GameObject defenderPrefab;
	public static GameObject selectedDefender;

	private Button[] buttonArray;

	// Use this for initialization
	void Start () {
		buttonArray = GameObject.FindObjectsOfType<Button>();
	}
	
	// Update is called once per frame
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
