using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour {

	bool tVel;
	bool tMoving;
	bool tStill;

	private void OnGUI() {
		tVel = GUI.Toggle(new Rect(10, 10, 150, 100), tVel, "Balls Velocity?");
		tMoving = GUI.Toggle(new Rect(200, 10, 150, 100), tMoving, "Balls Moving?");
		tStill = GUI.Toggle(new Rect(400, 10, 150, 100), tStill, "Balls Still?");

		int yPos = 25;
		if(tVel){
			foreach(Ball b in Controller.instance.balls){
				float prom = Mathf.Sqrt( (b.rb.velocity.x * b.rb.velocity.x) + (b.rb.velocity.z * b.rb.velocity.z));
				GUI.Label(new Rect(15, yPos, 300, 200), b.name + ": " + prom);
				yPos += 20;
			}
		}

		yPos = 25;
		if(tMoving){
			foreach(Ball b in Controller.instance.balls){
				if(b.rb.velocity != Vector3.zero){
					GUI.Label(new Rect(205, yPos, 300, 200), b.name);
					yPos += 20;
				}
			}
		}
		
		yPos = 25;
		if(tStill){
			foreach(Ball b in Controller.instance.balls){
				if(b.rb.velocity == Vector3.zero){
					GUI.Label(new Rect(405, yPos, 300, 200), b.name);
					yPos += 20;
				}
			}
		}


	}

}
