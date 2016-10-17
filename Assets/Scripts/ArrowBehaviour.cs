using UnityEngine;
using System.Collections;

public class ArrowBehaviour : MonoBehaviour {

    public Camera cam;

    private float startYMousePos;

    private Vector3 orignalPos;

    private float difference;

    private Rigidbody rb;

    public GameObject gameManager;
    private GameManager managerScript;


    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        orignalPos = transform.position;
        managerScript = gameManager.GetComponent<GameManager>();
	}

    void OnMouseDown()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10.0f;
        mousePos = cam.ScreenToWorldPoint(mousePos);

        startYMousePos = mousePos.y;
    }

    void OnMouseDrag()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10.0f;
        mousePos = cam.ScreenToWorldPoint(mousePos);

        difference = Mathf.Abs(mousePos.y - startYMousePos);
        float newDifference = difference / 2;

        float zValue = orignalPos.z - newDifference;
        float zValueClamped = Mathf.Clamp(zValue, -10.5f, -9.0f);

        Vector3 newPos = new Vector3(transform.position.x, transform.position.y, zValueClamped);
        transform.position = newPos;

        if(mousePos.y > 0.05f)
        {
            transform.position = orignalPos;
        }
    }

    void OnMouseUp()
    {
        transform.position = transform.position + Camera.main.transform.forward * 2;
        rb.isKinematic = false;
        float forceMultiplier = difference * 15f;
        rb.velocity = transform.forward * forceMultiplier;

        
    }

    void OnCollisionEnter(Collision collision)
    {
        rb.isKinematic = true;
        rb.velocity = transform.forward * 0;

        ContactPoint contact = collision.contacts[0];
        Vector3 pos = contact.point;          

        float distance = Vector3.Distance(collision.transform.position, pos);
        Debug.Log(distance);
        float scoreDistance = 100 * (distance * 2);
        float scoreToAdd = 100 - scoreDistance;

        if (distance < 0.1f) scoreToAdd = 100;
        managerScript.addScore(scoreToAdd);
    }

   
}
