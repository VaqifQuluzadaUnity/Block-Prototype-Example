using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwipeController : MonoBehaviour
{
    [SerializeField] private float swipeDistance;

    private Vector2 initialMousePos;

    private bool isScreenPressed = false;

    private SwipeDirection currentPlayerSwipeDirection;

    private void Update()
    {
        if(isScreenPressed==false && Input.GetMouseButtonDown(0))
        {
            isScreenPressed = true;

            initialMousePos = Input.mousePosition;
        }

        //
        if(isScreenPressed==true && Input.mousePosition.y >= initialMousePos.y + swipeDistance)
        {
            currentPlayerSwipeDirection = SwipeDirection.UP;

            PlayerController.instance.Swipe(currentPlayerSwipeDirection);

            isScreenPressed = false;

        }
        else if(isScreenPressed == true && Input.mousePosition.y <= initialMousePos.y - swipeDistance)
        {
            currentPlayerSwipeDirection = SwipeDirection.DOWN;

            PlayerController.instance.Swipe(currentPlayerSwipeDirection);

            isScreenPressed = false;

        }


        if (Input.GetMouseButtonUp(0))
        {
            isScreenPressed = false;
        }
    }
}
 


public enum SwipeDirection {LEFT, RIGHT,UP, DOWN};
