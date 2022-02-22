using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector3 rawPlayerMousePosition;
    public Vector3 playerMousePosition;

    public Vector2 vhInputVector;

    public bool isMousePressed;
    public bool isSpacePressed;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    
    void Update()
    {
        GetMouseInput();
        GetKeyBoardInput();
    }

    public void GetMouseInput()
    {
        if(!gameManager.isPaused)
        {
            rawPlayerMousePosition = Input.mousePosition;
            playerMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            isMousePressed = Input.GetKey(KeyCode.Mouse0);
        }

    }

    public void GetKeyBoardInput()
    {
        if (!gameManager.isPaused)
        {
            vhInputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
            isSpacePressed = Input.GetKey(KeyCode.Space);
        }
    }
}
