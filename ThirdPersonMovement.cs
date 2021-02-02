using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ThirdPersonMovement : MonoBehaviour
{
    
    public CharacterController controller;
    public Transform cam;
    public new Rigidbody rigidbody;
    public Animator anim;    
    public float life;
    public float speed;
    public float gravity;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Vector3 initialPosition; // = new Vector3(55.42f, 1.206f, -277.65f);
    int gems = 6;

    public GameObject textGems;
    public Text textGemsCount;
    public GameObject winUI;



    public void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        textGems.SetActive(false);

        winUI.SetActive(false);
        initialPosition = transform.position;
    }


    public void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moverDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            if (!controller.isGrounded)
                moverDir.y -= gravity * Time.deltaTime;
            else
                moverDir.y = 0;

            controller.Move(moverDir.normalized * speed * Time.deltaTime);

            RunAimation();
        }        
    }       

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Gem"))
        {
            collider.gameObject.SetActive(false);
            textGems.SetActive(true);
            gems--;            
            textGemsCount.text = gems.ToString();

            Debug.Log("Gem found. Left:" + gems);

            if (gems <= 0)
            {
                Debug.Log("You found all gems. You won!");
                Time.timeScale = 0f;
                winUI.SetActive(true);
                textGems.SetActive(false);
                
                if (gems == 0)
                {
                    textGemsCount.text = "";
                }
            }
        }
    }


    public void RunAimation()
    {
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool backwardPressed = Input.GetKey(KeyCode.S);
        bool leftPressed = Input.GetKey(KeyCode.A);
        bool rightPressed = Input.GetKey(KeyCode.D);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        if ((forwardPressed || backwardPressed || leftPressed || rightPressed) && !runPressed)
        {
            speed = 6f;
            anim.SetInteger("Anim", 1); // Walk
        }
        else
        if (runPressed && (forwardPressed || backwardPressed || leftPressed || rightPressed))
        {
            speed = 12f;
            anim.SetInteger("Anim", 2); // Run 
        }
        else
        if  (!forwardPressed && !backwardPressed && !leftPressed && !rightPressed && !runPressed)
            anim.SetInteger("Anim", 0); // Idle
    }
}
