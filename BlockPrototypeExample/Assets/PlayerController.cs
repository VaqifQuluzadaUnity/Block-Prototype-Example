using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] private Animation playerAnimationComponent;

    [SerializeField] private PlayerState currentPlayerState=PlayerState.FLAT_HORIZONTAL;

    [Header("0th element array is horizontalToVertical Animations,1th is verticalToHorizontal")]
    [SerializeField] private AnimationArray[] playerAnimationArray;

    private int currentAnimationClipIndex;

    private AnimationClip currentAnimClip;



    private void Awake()
    {
        instance = this;
    }


    public void Swipe(SwipeDirection currentSwipeDirection)
    {
        if(currentPlayerState==PlayerState.FLAT_HORIZONTAL && currentSwipeDirection == SwipeDirection.UP)
        {
            currentAnimationClipIndex = Random.Range(0,playerAnimationArray[0].animationClipArray.Length);
            currentAnimClip = playerAnimationArray[0].animationClipArray[currentAnimationClipIndex];
            currentPlayerState = PlayerState.FLAT_VERTICAL;
            PlayClip(currentAnimClip);
        }
        else if(currentPlayerState == PlayerState.FLAT_VERTICAL && currentSwipeDirection == SwipeDirection.DOWN)
        {
            currentAnimationClipIndex = Random.Range(0, playerAnimationArray[1].animationClipArray.Length);
            currentAnimClip = playerAnimationArray[1].animationClipArray[currentAnimationClipIndex];
            currentPlayerState = PlayerState.FLAT_HORIZONTAL;
            PlayClip(currentAnimClip);

        }

        
    }
    
    private void PlayClip(AnimationClip currentClip)
    {
        playerAnimationComponent.clip = currentClip;

        playerAnimationComponent.Play();
    }
}

[System.Serializable]
public class AnimationArray
{
    public AnimationClip[] animationClipArray;
}


public enum PlayerState { FLAT_HORIZONTAL, FLAT_VERTICAL}
