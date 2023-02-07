using UnityEngine;
using System.Collections;

public class movimiento : MonoBehaviour
{
    //NOT a general movement system, yet is quite perfected for a fixed camera.
    CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    //public float thereshold = 0.0001f;

    private Animator playerAnimator;
    private GameObject cutObject;
    private GameObject trimObject;
    private Transform thisTransform;


    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerAnimator = GetComponentInChildren<Animator>();
        //Animar = gameObject.GetComponentInParent<Animator>(); 

        cutObject = GameObject.FindGameObjectWithTag("Cortador");
        trimObject = GameObject.FindGameObjectWithTag("Podador");

        cutObject.SetActive(false);
        trimObject.SetActive(false);

        thisTransform = this.transform;

    }

    void Update()
    {
        /*
        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes */


            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            
            /* sE SUPONE QUE ESTO TRABA EN UN CUADRO AL PERSONAJE!!
        
            moveDirection = new Vector3(
            Mathf.Clamp(moveDirection.x, -14.5f, 14.5f),
            Mathf.Clamp(moveDirection.y, -0.75f, 1.0f),
            Mathf.Clamp(moveDirection.z, -14.5f, 14.5f)
            );
            */

            moveDirection *= speed;


            if( moveDirection.magnitude > 0.01f )
            {
                playerAnimator.SetBool("IsWalking", true);
                playerAnimator.SetBool("IsCuting",false);
                cutObject.SetActive(false);
    
                playerAnimator.SetBool("IsTrimming",false);
                trimObject.SetActive(false);

            }else{
                playerAnimator.SetBool("IsWalking", false);

                playerAnimator.SetBool("IsCuting",false);
                cutObject.SetActive(false);
    
                playerAnimator.SetBool("IsTrimming",false);
                trimObject.SetActive(false);
            }
        /*
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
            

            if (Input.GetButton("Jump"))
            {
                Animar.SetBool("IsPunching", true);
            }else Animar.SetBool("IsPunching", false);
        }
        */

         // If statement to check player is moving
        if(moveDirection != (new Vector3(0, 0, 0))) 
            {
                // Quaternion to rotate the player
                Quaternion newRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, speed * Time.deltaTime);
            }

        if( Input.GetButton("Fire1"))
        {
            playerAnimator.SetBool("IsCuting",true);
            cutObject.SetActive(true);
    
            playerAnimator.SetBool("IsTrimming",false);
            trimObject.SetActive(false);
        }

        if( Input.GetButton("Fire2") )
        {
            playerAnimator.SetBool("IsTrimming",true);
            trimObject.SetActive(true);

            playerAnimator.SetBool("IsCuting",false);
            cutObject.SetActive(false);
        }



        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
    }
}