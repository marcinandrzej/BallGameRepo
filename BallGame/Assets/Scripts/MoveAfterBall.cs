using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAfterBall : MonoBehaviour
{
    private Transform ballTransform;

	// Use this for initialization
	void Start ()
    {
        ballTransform = GameObject.FindWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Vector3 vec = new Vector3(0.0f, 0.0f, ballTransform.position.z - transform.position.z);
        transform.Translate(vec * Time.deltaTime);
	}
}
