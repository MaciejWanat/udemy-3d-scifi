using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour {

    [SerializeField]
    private float _sensitivity = 1.0f;
     
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        RotateX();
	}

    void RotateX()
    {
        float mouseX = Input.GetAxis("Mouse X");

        Vector3 newRotation = transform.localEulerAngles;
        newRotation.y = transform.localEulerAngles.y + (_sensitivity * mouseX);

        transform.localEulerAngles = newRotation;
    }
}
