using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_player1 : MonoBehaviour {

	Rigidbody rbPlayer;
	string nombre,joyX,joyY;

	[Header("Platform",order=0)]
	float rango=3.5f;
	public float limite=5.05f;

	[Header("Player",order=1)]
	public float velocidad=20;
	public int vidas=0;
	public float fuerzaGolpe;
	public bool puedeMover=true;
	public bool mover=true;
	float rcastLength;
	Vector3 vel=new Vector3(0,0,0);
	RaycastHit hit;
	public LayerMask lmask;

	[Header("Audio",order=2)]
	bool playingEngine=false;
	public AudioClip runningEngine,idle;
	AudioSource audios;






	// Use this for initialization
	void Start () {
		rbPlayer=gameObject.GetComponent<Rigidbody>();
		audios=gameObject.GetComponent<AudioSource>();
		rcastLength=(gameObject.GetComponent<Collider>().bounds.size.y)/2.0f;
		// Debug.Log(rcastLength);
		nombre=gameObject.name;
		nombre=nombre.Substring(1);
		joyX="Joy"+nombre+"X";
		joyY="Joy"+nombre+"Y";
	}

	// Update is called once per frame
	void FixedUpdate () {
		if(!puedeMover)
				return;
		getSuelo();
		if (!mover)
			return;

		  vel.z=Input.GetAxis(joyY)*Time.deltaTime*velocidad;
		  if (vel.z !=0.0f) {
				if (vel.z>0.0f) {
					transform.Rotate(0,Input.GetAxis(joyX)*velocidad*Time.deltaTime,0);
				}
			  else {
			    transform.Rotate(0,-Input.GetAxis(joyX)*velocidad*Time.deltaTime,0);
				}
				if (!playingEngine) {
					playingEngine=true;
					reproducirAudio(runningEngine);
				}
		  }
		  else{
		    transform.Rotate(0,Input.GetAxis(joyX)*velocidad/2*Time.deltaTime,0);
				// rbPlayer.AddTorque(Input.GetAxis(joyX)*velocidad/2*Time.deltaTime*transform.up);
				if (playingEngine) {
					playingEngine=false;
					reproducirAudio(idle);
				}
		  }
			// Debug.Log("velocidad Z: "+vel.z);
			// Debug.Log("joyY: "+ Input.GetAxis(joyY));
		rbPlayer.velocity=transform.forward * vel.z ;//+ Vector3.up * vel.y;

	}



	void reproducirAudio(AudioClip clip){
			audios.clip=clip;
			audios.Play();
	}



	IEnumerator respawn(){
		rbPlayer.velocity=Vector3.zero;
		transform.position= new Vector3(0.0f, 100f, 0.0f);//x=z=-3.5 ~ 3.5 , y=0.255
		yield return new WaitForSeconds(0.5f);
		transform.position= new Vector3(Random.Range(-rango, rango), rcastLength+0.1f, Random.Range(-rango, rango));//x=z=-3.5 ~ 3.5 , y=0.255
		transform.Rotate(0.0f,Random.Range(0, 360), 0.0f);
	}



	void getSuelo(){
		if (Physics.Raycast(transform.position, Vector3.down,rcastLength+0.2f,lmask)) {
			mover=true;
		}
		else{
			mover=false;
		}
		if (transform.position.y<-0.2f || Mathf.Abs(transform.position.x)>limite || Mathf.Abs(transform.position.z)>limite) {
			vidas--;
			if (!(vidas==0)) {
				StartCoroutine(respawn());
			}
			else{
				this.gameObject.SetActive(false);
			}
		}
	}


	IEnumerator inmovil(){
		yield return new WaitForSeconds(0.5f);
		puedeMover=true;
	}

//codigo nico
// void OnCollisionEnter(Collision collision){
// 		if(collision.collider.tag == "Player"){
// 				Vector3 contactPoint = collision.contacts[0].point - transform.position;
// 				Debug.Log("collision: "+contactPoint);
// 				rb.AddForce(-contactPoint.normalized * 5 + transform.up, ForceMode.VelocityChange);
// 				canCheckPiso = false;
// 				StartCoroutine(delayPiso());
// 		}
// }

//codigo mio
	void OnCollisionEnter(Collision c){
		//aplicar el transform(forward) del que pega por la velocidad del golpeado
		// Vector3 vectorSalto=Vector3.zero;
		// if (c.gameObject.name!="Plane") {
		// 	foreach (ContactPoint contact in c.contacts)
		// 	{
		// 		print(contact.thisCollider.tag + " hit " + contact.otherCollider.tag);
		// 		Vector3 otherVel=c.rigidbody.velocity;
		// 		Debug.Log(c.gameObject.name+";velocidad: "+otherVel.magnitude);
		// 		Vector3 fuerza=Vector3.zero;
		// 		if (contact.thisCollider.tag == "axis0") {
		// 			fuerza=Mathf.Pow(velForce,1)*-transform.forward*0.5f;
		// 		}
		// 		else if (contact.thisCollider.tag== "axis1" && contact.otherCollider.tag== "axis1") {
		// 			fuerza=0*transform.forward;
		//
		// 		}
		// 		else if(contact.thisCollider.tag == "axis1"){
		// 			fuerza=Mathf.Pow(velForce,1)*c.transform.forward;
		// 		}
		// 		rbPlayer.velocity=Vector3.zero;
		// 		rbPlayer.AddForce(fuerza*fuerzaGolpe+Vector3.up,ForceMode.Impulse);
		// 		puedeMover=false;
		// 		StartCoroutine(inmovil());
		// 	}
		// }
		if(c.collider.tag == "Player"){
			Vector3 contactPoint = c.contacts[0].point - transform.position;
			Debug.Log("collision: "+contactPoint);
			rbPlayer.AddForce(-contactPoint.normalized * fuerzaGolpe + transform.up, ForceMode.VelocityChange);
			puedeMover = false;
			StartCoroutine(inmovil());
		}
	}

}
