using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_player1 : MonoBehaviour {
	Rigidbody rbPlayer;
	public float velocidad=20;
	public float rechazo;
	public int vidas;
	Vector3 vel=new Vector3(0,0,0);
	RaycastHit hit;
	public LayerMask lmask;
	bool mover;
	// Use this for initialization
	void Start () {
		rbPlayer=gameObject.GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		getSuelo();
		if (mover) {
			vel.z=Input.GetAxis("Vertical")*Time.deltaTime*velocidad;//MOVIMIENTO VERTICAL
			if (vel.z >0.0) {
				transform.Rotate(0,Input.GetAxis("Horizontal")*velocidad*Time.deltaTime,0);//ROTAR
			}
			else if (vel.z<0.0) {
				transform.Rotate(0,-Input.GetAxis("Horizontal")*velocidad*Time.deltaTime,0);//ROTAR
			}
			else{
				transform.Rotate(0,Input.GetAxis("Horizontal")*velocidad/2*Time.deltaTime,0);//ROTAR
			}
		}
		rbPlayer.angularVelocity=Vector3.zero;
		vel.y= rbPlayer.velocity.y;//RE-SET VELOCIDAD EN Y (POST-SALTO)
		rbPlayer.velocity=transform.forward * vel.z + Vector3.up * vel.y;
	}
	void respawn(){
		rbPlayer.velocity=Vector3.zero;
		float rango=3.5f;
		transform.position= new Vector3(Random.Range(-rango, rango), 0.255f, Random.Range(-rango, rango));//x=z=-3.5 ~ 3.5 , y=0.255
		// transform.rotation = Random.rotationUniform;
		transform.Rotate(0.0f,Random.Range(0, 360), 0.0f);
	}

	void getSuelo(){
		bool vector= Physics.Raycast(transform.position, Vector3.down,(4.3f/2f)+0.1f,lmask);
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
				print(contact.thisCollider.name + " hit " + contact.otherCollider.name);
				// Debug.Log("normal:"+contact.normal);
				// Debug.Log("punto_contacto:"+contact.point);
				// Debug.Log("velocidad:"+rbPlayer.velocity);
				// Debug.Log("Forward:"+transform.forward);
			}
			Vector3 otherVel=c.rigidbody.velocity;
			Vector3 fuerza=Mathf.Pow(otherVel.magnitude,2)*transform.forward;
			rbPlayer.AddForce(fuerza*-rechazo,ForceMode.Impulse);
			llamar_Inmovilidad();
		}
	}

}
