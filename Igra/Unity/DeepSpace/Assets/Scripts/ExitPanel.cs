using UnityEngine;
using System.Collections;

public class ExitPanel : MonoBehaviour {
	public GameObject panel;

	// Use this for initialization
	void Start () {
		hideMenu ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void hideMenu (){
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		panel.GetComponent<CanvasGroup> ().interactable = true;
		panel.GetComponent<CanvasGroup> ().interactable = false;
		panel.GetComponent<CanvasGroup> ().alpha = 0;
	}
	public void displayMenu(){
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		panel.GetComponent<CanvasGroup> ().interactable = true;
		panel.GetComponent<CanvasGroup> ().alpha = 1;
	}
	public void quitGame(){
		Application.Quit ();
	}
}
