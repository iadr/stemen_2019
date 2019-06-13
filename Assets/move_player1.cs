using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_player1 : MonoBehaviour {
	Rigidbody rbPlayer;
	public float velocidad=20;
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

		// Debug.Log(rbPlayer.angularVelocity);
		vel.y= rbPlayer.velocity.y;//RE-SET VELOCIDAD EN Y (POST-SALTO)
		rbPlayer.velocity=transform.forward * vel.z + Vector3.up * vel.y;
	}

	void getSuelo(){
		bool vector= Physics.Raycast(transform.position, Vector3.down,(4.3f/2f)+0.1f,lmask);
		if (vector) {
			mover=true;
		}
		else{
			mover=false;
		}
	}

}
