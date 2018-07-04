using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassTurn : MonoBehaviour {

	private bool YourSkip;
	private bool MouseDown;
	private float time=0.0f;
	// Use this for initialization
	void Start () {
		YourSkip = false;
		MouseDown = false;
		time = 0.0f;
	}

	void OnMouseDown(){
		MouseDown = true;
	}

	void OnMouseUp(){
		MouseDown = false;
	}
	// Update is called once per frame
	void Update () {
		if (MouseDown == true) {
			time += Time.deltaTime;
			if(time >= 5){
				YourSkip = true;
				MouseDown = false;
				time = 0;
			}
		}
	}
}
