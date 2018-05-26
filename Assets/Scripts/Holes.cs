using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holes : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if(other.CompareTag("Ball")){
			Debug.Log("Stopped ball");
			Rigidbody rb = other.GetComponent<Rigidbody>();
			rb.velocity = Vector3.zero;
			rb.constraints = RigidbodyConstraints.None;
			other.GetComponent<SphereCollider>().enabled = false;
			Destroy(other.gameObject, 0.5f);
			Controller.instance.balls.Remove(other.GetComponent<Ball>());
		}
	}

}
