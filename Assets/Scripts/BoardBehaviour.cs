using UnityEngine;
using System.Collections;

public class BoardBehaviour : MonoBehaviour {

    private bool moveDown = false;

	void Start ()
    {
	
	}
	
	void Update ()
    {
	    if(moveDown)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y - 1.0f, transform.position.z), Time.deltaTime * 2.0f);
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject, 1.5f);
        Invoke("SetMoveDown", 2.0f);
    }

    void SetMoveDown()
    {
        moveDown = true;
    }
}
