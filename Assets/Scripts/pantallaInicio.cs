using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class pantallaInicio : MonoBehaviour {

	public GameObject modelo;
	public GameObject CanvasPantallaTitulo;
	public GameObject CanvasPantallaInstrucciones;
	public GameObject botonInstrucciones;
	private bool volver = false;
	private bool boolinst = false;
	public GameObject CanvasPantallaCreditos;
	void Start () {
		CanvasPantallaTitulo.SetActive(true);
		CanvasPantallaInstrucciones.SetActive(false);
		CanvasPantallaCreditos.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		modelo.transform.Rotate(0,50*Time.deltaTime,0);

		if (Input.GetButtonDown("Fire2") && volver){
			VerPantallaTitulo();
			if (boolinst){
				EventSystem.current.SetSelectedGameObject(botonInstrucciones);
				boolinst = false;
			}
		}
	}

	public void ComenzarPartida(){
		SceneManager.LoadScene("test01");
	}

	public void VerPantallaTitulo(){
		CanvasPantallaTitulo.SetActive(true);
		CanvasPantallaInstrucciones.SetActive(false);
		CanvasPantallaCreditos.SetActive(false);
		volver = false;
	}

	public void VerCreditos(){
		CanvasPantallaTitulo.SetActive(false);
		CanvasPantallaCreditos.SetActive(true);
		volver = true;
	}
	
	public void VerInstrucciones(){
		CanvasPantallaTitulo.SetActive(false);
		CanvasPantallaInstrucciones.SetActive(true);
		volver = true;
		boolinst = true;
	}

	public void SalirPartida(){
		Application.Quit();
	}
}
