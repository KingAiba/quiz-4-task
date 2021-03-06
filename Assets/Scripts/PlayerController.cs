using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 10f;
    private PlayerInput playerInput;

    private ProjectileShooter playerShooter;

    private Vector2 screenBounds;
    private float widthExtent;
    private float heightExtent;


    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerShooter = GetComponent<ProjectileShooter>();

        CalcScreenBounds();
    }
 
    void Update()
    {
        movePlayer();
        ShootOnInput();
    }

    private void FixedUpdate()
    {
        
    }

    private void LateUpdate()
    {
        ConstrainPlayerToBounds();
    }

    private void movePlayer()
    {
        Vector2 target = new Vector2(playerInput.playerMousePosition.x, playerInput.playerMousePosition.y);
        target = Vector2.Lerp(target, transform.position, moveSpeed * Time.deltaTime);
        transform.position = target;
    }

    private void ConstrainPlayerToBounds()
    {
        Vector2 newPos = transform.position;

        newPos.x = Mathf.Clamp(newPos.x, screenBounds.x * -1 + widthExtent, screenBounds.x - widthExtent);
        newPos.y = Mathf.Clamp(newPos.y, screenBounds.y * -1 + heightExtent, screenBounds.y - heightExtent);

        transform.position = newPos;
    }

    private void CalcScreenBounds()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        widthExtent = GetComponent<SpriteRenderer>().bounds.extents.x;
        heightExtent = GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    private void ShootOnInput()
    {
        if(playerInput.isMousePressed)
        {
            playerShooter.Shoot();
        }
    }
}
