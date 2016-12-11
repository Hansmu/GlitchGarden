using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;

	private GameObject defenderParent;
	private CurrencyDisplay currencyDisplay;

	void Start() {
		defenderParent = GameObject.Find("Defenders");
		currencyDisplay = GameObject.FindObjectOfType<CurrencyDisplay>();

		if (!defenderParent) {
			defenderParent = new GameObject("Defenders");
		}
	}

	void OnMouseDown() {
		Vector2 clickGridLocation = SnapToGrid(CalculateWorldPointOfMouseClick());
		GameObject defender = Button.selectedDefender;
		int defenderCost = defender.GetComponent<Defenders>().currencyCost;

		if (currencyDisplay.UseCurrency(defenderCost) == CurrencyDisplay.Status.SUCCESS) {
			SpawnDefender(clickGridLocation);
		}
	}

	void SpawnDefender(Vector2 clickGridLocation) {
		Quaternion zeroRotation = Quaternion.identity;
		GameObject newDefender = Instantiate(Button.selectedDefender, clickGridLocation, zeroRotation) as GameObject;

		newDefender.transform.parent = defenderParent.transform;
	}

	Vector2 SnapToGrid(Vector2 rawWorldPosition) {
		float roundedX = Mathf.RoundToInt(rawWorldPosition.x);
		float roundedY = Mathf.RoundToInt(rawWorldPosition.y);

		return new Vector2(roundedX, roundedY);
	}

	Vector2 CalculateWorldPointOfMouseClick() {
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f; //Doesn't really matter

		Vector3 mouseLocationVector3 = new Vector3(mouseX, mouseY, distanceFromCamera);
		Vector2 worldPosition = myCamera.ScreenToWorldPoint(mouseLocationVector3);

		return worldPosition;
	}
}
