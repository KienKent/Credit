using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

	public ArrayList hand;
	private int handcount;
	private float testing = 0f;
	private Transform left;
	private GameObject card;
	private float width;
	public int track;
	private CardDrag drag;
	// Use this for initialization
	void Start () {
		hand = new ArrayList();
		handcount = 0;
		left = this.gameObject.transform.GetChild (0);
		width = 0.5f;
		track = handcount;
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Card") {
			card = coll.gameObject;
			hand.Add (card);
			drag = card.GetComponent<CardDrag> ();
			card = null;
			//	CardOn = true;
		}
		/*else {
			CardOn = false;
		}*/
	}

	void OnTriggerStay2D(Collider2D coll){
		
	}

	void OnTriggerExit2D(Collider2D coll){
		card = coll.gameObject;
		if (coll.gameObject.tag == "Card") {
			drag = card.GetComponent<CardDrag> ();
			hand.Remove(card);
		}
		card = null;
	}
	// Update is called once per frame

	public void HandArrange(){
		for (int i = 0; i < handcount; i++) {
			GameObject test = (GameObject)hand [i];
			Vector3 newPos = new Vector3 ((left.position.x + i * width), transform.position.y, transform.position.z - i - 1);
			test.transform.position = newPos;
		}
	}
	void Update () {
		handcount = hand.Count;
		/*if (handcount > 0) {
			if (drag.dragged == false) {
				testing = (1 - handcount) / 2;

			}
		}*/
	}
}
