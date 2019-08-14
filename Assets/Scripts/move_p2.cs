using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_p2 : MonoBehaviour {
	Rigidbody rbPlayer;
	 public float velocidad=20;
	Vector3 vel=new Vector3(0,0,0 );

	// Use this for initialization
	void Start () {
		rbPlayer=gameObject.GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		//vel.z=Input.GetAxis("Vertical")*Time.deltaTime*velocidad;//MOVIMIENTO VERTICAL
		vel.z=Input.GetAxis("Joy2Y")*Time.deltaTime*velocidad;
		if (vel.z >=0) {
			//transform.Rotate(0,Input.GetAxis("Horizontal")*velocidad*Time.deltaTime,0);//ROTAR
			transform.Rotate(0,Input.GetAxis("Joy2X")*velocidad*Time.deltaTime,0);
		}
		else{
			//transform.Rotate(0,-Input.GetAxis("Horizontal")*velocidad*Time.deltaTime,0);//ROTAR
			transform.Rotate(0,-Input.GetAxis("Joy2X")*velocidad*Time.deltaTime,0);
		}
		rbPlayer.angularVelocity=Vector3.zero;

		vel.y= rbPlayer.velocity.y;//RE-SET VELOCIDAD EN Y (POST-SALTO)
		rbPlayer.velocity=transform.forward * vel.z + Vector3.up * vel.y;
		// Debug.Log(vel);

	}
	}
