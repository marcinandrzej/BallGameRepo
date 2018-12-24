using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Transform ballTransform;

	// Use this for initialization
	void Start ()
    {
        ballTransform = GameObject.FindWithTag("Player").transform;		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3(ballTransform.position.x, ballTransform.position.y + 1.5f, ballTransform.position.z - 3);
        transform.LookAt(ballTransform.position);
	}
}
