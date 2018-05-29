using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour {

	public Rigidbody rb;
	Vector3 mov;
	public float speed = 0;
	
	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	private void Update() {
		Debug.DrawLine(transform.position,
						new Vector3(transform.position.x + rb.velocity.normalized.x,
									0,
									transform.position.z + rb.velocity.normalized.z),
						Color.red);
	}

	private void OnCollisionEnter(Collision other){
		if(other.gameObject.CompareTag("Ball"))
			gameObject.GetComponent<Renderer>().material.SetColor("_FresnelColor" , Color.red);
	}

	private void OnCollisionExit(Collision other) {
		if(other.gameObject.CompareTag("Ball"))
			gameObject.GetComponent<Renderer>().material.SetColor("_FresnelColor" , Color.white);
	}

}
