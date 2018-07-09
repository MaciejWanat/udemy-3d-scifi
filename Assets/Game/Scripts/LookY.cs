using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour {

    [SerializeField]
    private float _sensitivity = 1.0f;
    
    // Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        RotateY();
    }

    void RotateY()
    {
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 newRotation = transform.localEulerAngles;
        newRotation.x = transform.localEulerAngles.x - (_sensitivity * mouseY);

        newRotation.y = 0;
        newRotation.z = 0;

        transform.localEulerAngles = newRotation;
    }
}
