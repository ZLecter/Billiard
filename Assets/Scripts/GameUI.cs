using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour {

	bool toogler;

	private void OnGUI() {
		toogler = GUI.Toggle(new Rect(10, 10, 150, 100), toogler, "Balls Velocity?");

		int yPos = 25;
		if(toogler){
			foreach(Ball b in Controller.instance.balls){
				float prom = Mathf.Sqrt( (b.rb.velocity.x * b.rb.velocity.x) + (b.rb.velocity.z * b.rb.velocity.z));
				GUI.Label(new Rect(15, yPos, 300, 200), b.name + ": " + prom);
				yPos += 20;
			}
		}

	}

}
