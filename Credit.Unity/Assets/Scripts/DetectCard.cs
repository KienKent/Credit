using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCard : MonoBehaviour {

	public bool CardOn;
	public ArrayList cardlist;
	public int cardcount;
	public GameObject card;
	public double position;
	private double testing = 0f;
	// Use this for initialization
	void Start () {
		CardOn = false;
		cardcount = 0;
		cardlist = new ArrayList();
		card = null;
		position = 0f;
	}
/*		
	void OnMouseOver(){
		MouseOn = true;
	}

	void OnMouseExit(){
		MouseOn = false;
	}
*/
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Card") {
			card = coll.gameObject;
			CardOn = true;
		}
		else {
			CardOn = false;
		}
	}		
	//Fixing Weird Bug , when two bar collider collide with card
	void OnTriggerExit2D(Collider2D coll){
		card = coll.gameObject;
		if (coll.gameObject.tag == "Card") {
			CardDrag drag = card.GetComponent<CardDrag> ();
			if (drag.poweradded == true) {
				CardOn = false;
				cardlist.Remove (card);
				this.GetComponentInParent<rowScore> ().removeScore (drag.power);
				drag.poweradded = false;
			}
			card = null;
		}
	}
	// Update is called once per frame
	void Update () {
		if (CardOn == true && card != null) {
			CardDrag drag = card.GetComponent<CardDrag> ();
			if (drag.dragged == false && drag.poweradded == false){
				CardOn = false;
				cardlist.Add (card);
				this.GetComponentInParent<rowScore> ().addScore (drag.power);
				drag.poweradded = true;
				card = null;
			}
		}
		cardcount = cardlist.Count;
		if (cardlist.Count > 0) {
			testing = (1 - cardcount)/(1.75);
			for(int i = 0 ; i < cardcount ;i++){
				GameObject test = (GameObject)cardlist[i];
				Vector3 newPos = new Vector3 ((transform.position.x + (float)testing + i), transform.position.y, test.transform.position.z);
				test.transform.position = newPos;
			}
		}
	}
}
