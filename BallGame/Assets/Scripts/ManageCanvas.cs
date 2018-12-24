using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageCanvas : MonoBehaviour
{
    public List<Button> buttons;

    private BallControl ball;

    // Use this for initialization
    void Start ()
    {
        ball = GameObject.FindWithTag("Player").GetComponent<BallControl>();

        SetButtonsActive(false);
    }

    void FixedUpdate()
    {
        if (ball.IsDead())
        {
            SetButtonsActive(true);
        }
    }

    public void SetButtonsActive(bool activate)
    {
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(activate);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
