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
		// mov = new Vector3(Random.Range(0, 2f), 0, Random.Range(0, 2f));
		// Debug.Log(mov);
		// rb.AddForce(mov * speed);
	}

}
