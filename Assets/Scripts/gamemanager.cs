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

	public GameObject [] ganador = new GameObject[1];
	public GameObject plano;
	public GameObject hotdog;
	public GameObject papas;
	public GameObject helado;
	public GameObject pretzel;
	private GameObject modelo;
	private bool bfinal = true;

	// string[] names = Input.GetJoystickNames();

	void Awake(){
		//Random.InitState(System.DateTime.Now.Second * System.DateTime.Now.Minute);
		if(Instance == null)
			Instance = this;
		audioSource = GetComponent<AudioSource>();
	}
	void Start () {
		Time.timeScale = 1;
		pausa = false;
		Time.timeScale = 1;
		pantallaPausa.SetActive(false);
		pantallaFinal.SetActive(false);
		pantallaScores.SetActive(true);
		plano.SetActive(true);

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
		for (int i=0;	 i<4; i++) {
			HP[i].text="VIDAS PLAYER"+(i+1)+":"+players[i].GetComponent<move_player1>().vidas;
		}


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
			if (bfinal){
				FinalPartida();
				bfinal = false;
			}
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

	public void FinalPartida(){
		ganador = GameObject.FindGameObjectsWithTag("Player");
		modelo = ganador[0].transform.GetChild(2).gameObject;
		modelo.transform.SetParent(pantallaFinal.transform,false);
		modelo.transform.localPosition = new Vector3(-22f,24f,-96f);
		modelo.transform.localScale = new Vector3(300f,300f,300f);
		modelo.transform.localRotation = Quaternion.Euler(new Vector3(1f,-100f,0f));
		//Destroy(plano);
		plano.SetActive(false);
		//Destroy(ganador[0]);
		ganador[0].SetActive(false);
		pantallaFinal.SetActive(true);
		pantallaScores.SetActive(false);
		modelo.SetActive(true);
	}

	public void VolverMenuInicio(){
		SceneManager.LoadScene("PantallaInicio");
	}

	public void NuevaPartida(){
		Destroy(GameObject.Find("SeleccionesManager"));
		SceneManager.LoadScene("ElegirCarro");
	}
}
		// Debug.Log(players[0].GetComponent<move_player1>().vidas);
