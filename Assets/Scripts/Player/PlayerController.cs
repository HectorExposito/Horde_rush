using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float horizontalMovement = 0;
    private float verticalMovement = 0;

    bool characterFacingRight = true;
    void Update()
    {
        PlayerMovement();
        
    }

    private void PlayerMovement()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");
        
        transform.position += new Vector3(horizontalMovement, verticalMovement, 0) * Time.deltaTime*
            speed * GetComponent<PlayerManager>().speedModifier;

        if (horizontalMovement < -0.1 || horizontalMovement > 0.1 || verticalMovement > 0.1 || verticalMovement < -0.1)
        {
            ChangeAnimation(AnimationParametersList.isWalking, true);
        }
        else
        {
            ChangeAnimation(AnimationParametersList.isWalking, false);
        }

        if (horizontalMovement > 0 && characterFacingRight == false)
        {
            characterFacingRight = true;
            flipPlayer();
        }else if (horizontalMovement < 0 && characterFacingRight == true)
        {
            characterFacingRight = false;
            flipPlayer();
        }
    }

    internal void IncreaseSpeed()
    {
        if (speed < 6)
        {
            Debug.Log(GetComponent<PlayerManager>().speedModifier);
            speed = speed * GetComponent<PlayerManager>().speedModifier;
        }
    }

    private void ChangeAnimation(string parameter, bool state)
    {
        switch (parameter)
        {
            case AnimationParametersList.isWalking:
                GetComponent<Animator>().SetBool(AnimationParametersList.isWalking, state);
                break;
        }

    }

    private void flipPlayer()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
