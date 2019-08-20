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
		pantallaScores.SetActive(true);

        for(int i = 0; i < 4; ++i)
        {
            if(Selecciones.Instance.isOnline[i])
            {
                players[i].SetActive(true);
                Instantiate(Selecciones.Instance.carSelected[i], players[i].transform);
            }
            else
            {
                players[i].SetActive(false);
            }
        }
        Selecciones.Instance.RestartSelecciones();

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
		
		for(int i=0; i < 4;i++){
			if (players[i].activeSelf) {
				HP[i].gameObject.SetActive(true);
			}
		}

	}

	// Update is called once per frame
	void Update () {
		// Debug.Log(players[0].GetComponent<move_player1>().vidas);
		HP[0].text="PLAYER1:"+players[0].GetComponent<move_player1>().vidas;
		HP[1].text="PLAYER2:"+players[1].GetComponent<move_player1>().vidas;
		HP[2].text="PLAYER3:"+players[2].GetComponent<move_p3>().vidas;
		HP[3].text="PLAYER4:"+players[3].GetComponent<move_p4>().vidas;


		if(Input.GetButtonDown("Pausa")){
			if(!pausa){
				PausarJuego();
			}
			else{
				ResumirJuego();
			}
		}
		Debug.Log(GameObject.FindGameObjectsWithTag("Player").Length);
		if (GameObject.FindGameObjectsWithTag("Player").Length==1) {
			Time.timeScale=0;
			Debug.Log("Se acabo esto");
			// FINALIZAR JUEGO
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
