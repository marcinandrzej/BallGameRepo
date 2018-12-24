using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftRight : MonoBehaviour {

    [SerializeField]
    private float moveDuration;
    private float currentTime;
    [SerializeField]
    private float speed;

    // Use this for initialization
    void Start ()
    {
        currentTime = 0;

    }
	
	// Update is called once per frame
	void Update ()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= moveDuration)
        {
            speed = -speed;
            currentTime = 0;
        }
        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
	}
}
