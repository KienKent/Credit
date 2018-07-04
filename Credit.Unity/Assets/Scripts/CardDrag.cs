using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class CardDrag : MonoBehaviour {

	public int power;
	public int id;
	public bool dragged;
	public bool poweradded;
	// Use this for initialization
	void Start () {
		power = 4;
		dragged = false;
		id = 2;
		poweradded = false;
	}

	private Vector3 offset;

	void OnMouseDown()
	{
		offset = gameObject.transform.position -
			Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
	}

	void OnMouseDrag()
	{
		Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
		transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
		dragged = true;
	}
		
	void OnTriggerStay2D(Collider2D coll){
		if (coll.gameObject.tag == "Hand") {
			Debug.Log ("test");
			if (dragged == false) {
				Hand hand = coll.gameObject.GetComponent<Hand> ();
				if (hand.track != hand.hand.Count) {
					hand.HandArrange ();
					hand.track = hand.hand.Count;
				}
			}
		}
	}

	void OnMouseUp(){
		dragged = false;
	}

	// Update is called once per frame
	void Update () {
		
	}
}