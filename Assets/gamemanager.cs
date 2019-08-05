using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour {
	public GameObject [] players=new GameObject[4];
	public Text [] HP=new Text[4];
	// Use this for initialization
	void Start () {
		if (players[2].activeSelf) {
			HP[2].gameObject.SetActive(true);
		}
		if (players[3].activeSelf) {
			HP[3].gameObject.SetActive(true);
		}
	}

	// Update is called once per frame
	void Update () {
		// Debug.Log(players[0].GetComponent<move_player1>().vidas);
		for (int i=0;i<4; i++) {
			HP[i].text="PLAYER"+(i+1)+":"+players[i].GetComponent<move_player1>().vidas;
		}

	}
}
