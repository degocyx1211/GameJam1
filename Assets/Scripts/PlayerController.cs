using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public bool doubleJump = false;
    public float moveSpeed;
    public float jumpForce;
    public float garavityScale = 5f;

    public float rotateSpeed = 5f;

    private Vector3 moveDirection;

    public CharacterController charController;
    // Trae la cámara
    public Camera playerCamera;

    //trae al Player
    public GameObject playerModel;

    public Animator animator;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        JumpPlayer();
        PlayerRotation();

        //Gravedad
        moveDirection.y += Physics.gravity.y * Time.deltaTime * garavityScale;

        SentAnimatorInfo();
    }

    //Movimiento
    void MovePlayer()
    {
        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
        moveDirection.Normalize();
        moveDirection = moveDirection * moveSpeed;
        moveDirection.y = yStore;

        charController.Move(moveDirection * Time.deltaTime);
    }

    void JumpPlayer()
    {
        if (charController.isGrounded)
        {
            moveDirection.y = -1f;

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
                doubleJump = true;
            }
        }
        else if (Input.GetButtonDown("Jump") && doubleJump == true)
        {
            moveDirection.y = jumpForce;
            doubleJump = false;
        }
    }

    void PlayerRotation()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            //El player rota con la cámara
            transform.rotation = Quaternion.Euler(0f, playerCamera.transform.rotation.eulerAngles.y, 0f);

            //El player rotahacia la dirección a donde camina
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));

            //Rota suavemente
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }
    }

    void SentAnimatorInfo()
    {
        //afecta los datos del animator. Le envía datos al parametro Speed
        animator.SetFloat("Speed", Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.z));
        ////Afecta el grounded para saber cuando está en el suelo
        //animator.SetBool("Grounded", charController.isGrounded);
    }


}
