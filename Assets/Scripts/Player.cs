using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MovingObject
{
    // public float restartLevelDelay = 1f;
    private bool isMoving = false;

    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        if (!GameManager.instance.playersTurn) return;

        int horizontal = (int)(Input.GetAxisRaw("Horizontal"));
        int vertical = (int)(Input.GetAxisRaw("Vertical"));
        if (horizontal != 0)
        {
            vertical = 0;
        }

        if (horizontal != 0 || vertical != 0)
        {
            Move(horizontal, vertical);
            GameManager.instance.playersTurn = false;
        }
    }
    
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
