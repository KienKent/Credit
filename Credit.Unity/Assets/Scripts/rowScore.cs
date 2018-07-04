using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rowScore : MonoBehaviour {

	private int score;
	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponentInChildren<TextMesh> ().text = "" + score;
	}

	void OnMouseDown(){
		if (gameObject.tag == "SelfBar")
			totalScore.addSelfScore (1);
		else if (gameObject.tag == "EnemyBar")
			totalScore.addEnemyScore (1);	
		addScore (1);
		gameObject.GetComponentInChildren<TextMesh> ().text = "" + score;
	}

    public void addScore(int k){
		score += k;
		if (gameObject.tag == "SelfBar")
			totalScore.addSelfScore (k);
		else if (gameObject.tag == "EnemyBar")
			totalScore.addEnemyScore (k);	
	}

	public void removeScore(int k){
		score -= k;
		if (gameObject.tag == "SelfBar")
			totalScore.removeSelfScore (k);
		else if (gameObject.tag == "EnemyBar")
			totalScore.removeEnemyScore (k);	
	}
}	