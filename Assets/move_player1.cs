using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_player1 : MonoBehaviour {
	Rigidbody rbPlayer;
	public float velocidad=20;
	public float rechazo;
	float rcastLength;
	public int vidas;
	Vector3 vel=new Vector3(0,0,0);
	RaycastHit hit;
	public LayerMask lmask;
	bool mover;
	// bool isMoving=false;
	bool playingEngine=false;
	public float velForce=10	;
	string nombre,joyX,joyY;

	public AudioClip runningEngine,idle;
	AudioSource audios;

	// Use this for initialization
	void Start () {
		rbPlayer=gameObject.GetComponent<Rigidbody>();
		audios=gameObject.GetComponent<AudioSource>();
		rcastLength=(gameObject.GetComponent<Collider>().bounds.size.y)/2.0f;
		nombre=gameObject.name;
		nombre=nombre.Substring(1);
		joyX="Joy"+nombre+"X";
		joyY="Joy"+nombre+"Y";
	}

	// Update is called once per frame
	void Update () {
		getSuelo();
		if (mover) {
		  vel.z=Input.GetAxis("Vertical")*Time.deltaTime*velocidad;//MOVIMIENTO VERTICAL
		  //vel.z=Input.GetAxis(joyY)*Time.deltaTime*velocidad;
		  if (vel.z !=0.0) {
				if (vel.z>0.0) {
					transform.Rotate(0,Input.GetAxis("Horizontal")*velocidad*Time.deltaTime,0);//ROTAR
					// transform.Rotate(0,Input.GetAxis(joyX)*velocidad*Time.deltaTime,0);
				}
			  else {
			    transform.Rotate(0,-Input.GetAxis("Horizontal")*velocidad*Time.deltaTime,0);//ROTAR
			    // transform.Rotate(0,-Input.GetAxis(joyX)*velocidad*Time.deltaTime,0);
				}
				if (!playingEngine) {
					playingEngine=true;
					reproducirAudio(runningEngine);
				}
		  }
		  else{
		    //transform.Rotate(0,Input.GetAxis("Horizontal")*velocidad/2*Time.deltaTime,0);//ROTAR
		    transform.Rotate(0,Input.GetAxis(joyX)*velocidad/2*Time.deltaTime,0);
				if (playingEngine) {
					playingEngine=false;
					reproducirAudio(idle);
				}
		  }
		}
		rbPlayer.angularVelocity=Vector3.zero;
		vel.y= rbPlayer.velocity.y;//RE-SET VELOCIDAD EN Y (POST-SALTO)
		rbPlayer.velocity=transform.forward * vel.z + Vector3.up * vel.y;
	}

	void reproducirAudio(AudioClip clip){
			audios.clip=clip;
			audios.Play();
	}

	void respawn(){
		rbPlayer.velocity=Vector3.zero;
		float rango=3.5f;
		transform.position= new Vector3(Random.Range(-rango, rango), 0.255f, Random.Range(-rango, rango));//x=z=-3.5 ~ 3.5 , y=0.255
		transform.Rotate(0.0f,Random.Range(0, 360), 0.0f);
	}

	void getSuelo(){
		bool vector= Physics.Raycast(transform.position, Vector3.down,rcastLength+0.2f,lmask);
		if (vector) {
			mover=true;
		}
		else{
			mover=false;
		}
		if (transform.position.y<-0.2f || Mathf.Abs(transform.position.x)>6.0f) {
			vidas--;
			respawn();
		}
	}
	IEnumerator inmovil()
	{
		mover=false;
		yield return new WaitForSeconds(2f);
		mover=true;
	}

	public void llamar_Inmovilidad(){
		StartCoroutine(inmovil());
	}


	void OnCollisionEnter(Collision c){
		//aplicar el transform(forward) del que pega por la velocidad del golpeado
		if (c.gameObject.name!="Plane") {
			foreach (ContactPoint contact in c.contacts)
			{
				// print(contact.thisCollider.tag + " hit " + contact.otherCollider.tag);
				Vector3 otherVel=c.rigidbody.velocity;
				Debug.Log(c.gameObject.name+";velocidad: "+otherVel.magnitude);
				Vector3 fuerza=Vector3.zero;
				if (contact.thisCollider.tag == "axis0") {
					fuerza=Mathf.Pow(velForce,1)*-transform.forward*0.5f;
				}
				else if (contact.thisCollider.tag== "axis1" && contact.otherCollider.tag== "axis1") {
					fuerza=0*transform.forward;

				}
				else if(contact.thisCollider.tag == "axis1"){
					fuerza=Mathf.Pow(velForce,1)*c.transform.forward;
				}
				rbPlayer.velocity=Vector3.zero;
				rbPlayer.AddForce(fuerza*rechazo+Vector3.forward,ForceMode.Impulse);
				// llamar_Inmovilidad();
				// StartCoroutine(inmovil());

			}
		}
	}

}
