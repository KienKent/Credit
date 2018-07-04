using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class totalScore : MonoBehaviour {

	public static int SelfScore;
	public static int EnemyScore;

	// Use this for initialization
	void Start () {
		SelfScore = 0;
		EnemyScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//addScore (1);
		if(gameObject.tag == "SelfBar")
		gameObject.GetComponentInChildren<TextMesh> ().text = "" + SelfScore;
		else if(gameObject.tag =="EnemyBar")
		gameObject.GetComponentInChildren<TextMesh> ().text = "" + EnemyScore;	

	}

	public static void addSelfScore(int k){
		SelfScore += k;
	}

	public static void addEnemyScore(int k){
		EnemyScore += k;
	}

	public static void removeSelfScore(int k){
		SelfScore -= k;
	}
	public static void removeEnemyScore(int k){
		EnemyScore -= k;
	}
}
