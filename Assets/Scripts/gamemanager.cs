using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour {
	public static gamemanager Instance;
	public GameObject [] players=new GameObject[4];
	public Text [] HP=new Text[4];
	//public Canvas pantallaInicio,pantallaPausa,pantallaFinal,pantallaScores;
	//public Canvas pantallaPausa,pantallaFinal,pantallaScores;
	public GameObject pantallaPausa,pantallaFinal,pantallaScores;
	public bool pausa;
	private AudioSource audioSource;

	// string[] names = Input.GetJoystickNames();

	void Awake(){
		//Random.InitState(System.DateTime.Now.Second * System.DateTime.Now.Minute);
		if(Instance == null)
			Instance = this;
		audioSource = GetComponent<AudioSource>();
	}
	void Start () {
		pausa = false;
		Time.timeScale = 1;
		pantallaPausa.SetActive(false);
		pantallaFinal.SetActive(false);
		pantallaScores.SetActive(false);


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
		
		if(Input.GetButtonDown("Pausa")){
			if(!pausa){
				PausarJuego();
			}
			else{
				ResumirJuego();
			}
		}

	}

	public void PausarJuego(){
		pantallaPausa.SetActive(true);
		Time.timeScale = 0;
		pausa=true;
	}
	public void ResumirJuego(){
		pantallaPausa.SetActive(false);
		Time.timeScale = 1;
		pausa=false;
	}
}
