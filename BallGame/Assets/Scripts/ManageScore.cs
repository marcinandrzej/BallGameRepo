using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageScore : MonoBehaviour {

    private float score;

    private BallControl ball;

    public Text scoreTxt;
    // Use this for initialization
    void Start ()
    {
        score = 0;

        ball = GameObject.FindWithTag("Player").GetComponent<BallControl>();

    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (!ball.IsDead())
        {
            score += Time.deltaTime;
            scoreTxt.text = ((int)score).ToString();
        }
	}
}
