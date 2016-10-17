using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BowMovement : MonoBehaviour {

    public Text debugXValue; 

	void Start ()
    {
	
	}
	
	void Update ()
    {
        float accelerationXAmount = Mathf.Round(Input.acceleration.x * 100) / 100;
        float accelerationYAmount = Mathf.Round(Input.acceleration.y * 100) / 100;

        //transform.position = new Vector3(accelerationXAmount, accelerationYAmount, -9.2f);
	}
}
