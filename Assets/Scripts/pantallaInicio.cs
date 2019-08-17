using UnityEngine;
using UnityEngine.SceneManagement;

public class pantallaInicio : MonoBehaviour {

	public GameObject modelo;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		modelo.transform.Rotate(0,50*Time.deltaTime,0);
	}

	public void ComenzarPartida(){
		SceneManager.LoadScene("test01");
	}

	public void VerCreditos(){

	}
	
	public void VerInstrucciones(){

	}
}
