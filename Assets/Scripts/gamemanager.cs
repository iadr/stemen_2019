using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour {
	public GameObject [] players=new GameObject[4];
	public Text [] HP=new Text[4];
	public Canvas pantallaInicio,pantallaPausa,pantallaFinal,pantallaScores;

	// string[] names = Input.GetJoystickNames();

	// Use this for initialization
	void Start () {
		Debug.Log(Input.GetJoystickNames().Length);
		if (Input.GetJoystickNames().Length >2) {
			if (Input.GetJoystickNames().Length == 3) {
				players[2].gameObject.SetActive(true);
				HP[2].gameObject.SetActive(true);
			}
			else{
				players[3].gameObject.SetActive(true);
				HP[3].gameObject.SetActive(true);
			}
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
