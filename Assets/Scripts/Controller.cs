using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	public static Controller instance;
	public List<Ball> balls;
	public static float minVel = 0.67f;

	void Start(){
		instance = this;
	}

	void Update() {
		foreach(Ball b in balls){
			if(CalcMinVel(b.rb.velocity)){
				b.rb.velocity = Vector3.zero;
				b.rb.angularVelocity = Vector3.zero;
			}
		}
	}

	private void OnGUI() {
		int yPos = 10;
		foreach(Ball b in balls){
			float prom = (Mathf.Abs(b.rb.velocity.x) + Mathf.Abs(b.rb.velocity.z))/2;
			GUI.Label(new Rect(10, yPos, 300, 200), b.name + " " + prom);
			yPos += 20;
		}
	}

	public static bool CalcMinVel(Vector3 vel){
			float prom = (Mathf.Abs(vel.x) + Mathf.Abs(vel.z))/2;
			return (prom < minVel);
	}

}
