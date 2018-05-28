using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class MainBall : MonoBehaviour {

	Rigidbody rb;
	Vector3 preDir;
	Vector3 dir;
	public bool isMoving;

	public GameObject handler;
	public float rotationStrength = 0.5f;
	public float speed = 5;

	public Slider speedSlider;

	void Start () {
		isMoving = false;
		rb = GetComponent<Rigidbody>();
		dir = new Vector3(-90, 0, 0);
	}
	
	void Update () {

		// Modify speed, value visible on slider
		if(Input.GetKey(KeyCode.UpArrow) && !isMoving){
			speed += rotationStrength;
			speed = Mathf.Clamp(speed, 5, 25);
			speedSlider.value = speed;
		}else if(Input.GetKey(KeyCode.DownArrow) && !isMoving){
			speed -= rotationStrength;
			speed = Mathf.Clamp(speed, 5, 25);
			speedSlider.value = speed;
		}

		// Rotate input for force direction
		if(Input.GetKey(KeyCode.LeftArrow) && !isMoving){
			dir.z -= rotationStrength;
			handler.transform.rotation = Quaternion.Euler(dir);
		}else if(Input.GetKey(KeyCode.RightArrow) && !isMoving){
			dir.z += rotationStrength;
			handler.transform.rotation = Quaternion.Euler(dir);
		}

		// Debug purposes
		if(Input.GetKeyDown(KeyCode.Q)){
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		}

		// Calculate direction
		float angle = handler.transform.rotation.eulerAngles.y * Mathf.Deg2Rad;
		preDir = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
		

		if(Controller.CalcMinVel(rb.velocity)){
			isMoving = false;
			handler.SetActive(true);
			handler.transform.rotation = Quaternion.Euler(dir);
		}
		
		preDir.y = 0;
		if(Input.GetKeyDown(KeyCode.Space) && !isMoving){
			isMoving = true;
			Debug.Log(preDir);
			rb.AddForce(preDir * speed, ForceMode.Impulse);
			handler.SetActive(false);
		}

	}

}
