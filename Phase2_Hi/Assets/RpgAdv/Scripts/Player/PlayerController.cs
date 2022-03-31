using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace RpgAdv
{

    public class PlayerController : MonoBehaviour, IAttackAnimListener
    {
        public static PlayerController Instance
        {
            get
            {
                return s_Instance;
            }
        }

        public MeleeWeapon meleeWeapon;
        public float speed;
        public float maxForwardSpeed;
        public float rotationSpeed;

        private static PlayerController s_Instance;
        private PlayerInput playerInput;
        private CharacterController charController;
        private Animator animator;
        private CameraController mainCameraController;
        private Vector3 movement1;
        private Quaternion targetRotation1;

        private float desiredForwardSpeed;
        private float forwardSpeed;
        private float verticalSpeed;
        
        public float maxRotationSpeed = 1200;
        public float minRotationSpeed = 800;
        public float gravity = 20.0f;
        

        private readonly int HashForwardSpeed = Animator.StringToHash("ForwardSpeed");
        private readonly int HashMeleeAttack = Animator.StringToHash("MeleeAttack");
        //private Quaternion rotation1;
        
        const float acceleration = 20;
        const float deacceleration = 535;
        private void Awake()
        {
            charController = GetComponent<CharacterController>();
            mainCameraController = Camera.main.GetComponent<CameraController>();
            animator = GetComponent<Animator>();
            playerInput = GetComponent<PlayerInput>();

            s_Instance = this;

            meleeWeapon.SetOwner(gameObject);
        }


        // Update is called once per frame
        void FixedUpdate()
        {
           ComputeForwardMovement();
           ComputeVerticalMovement();
           ComputeRotation();

           if (playerInput.isMoveInput)
           {
               float rotationSpeed = Mathf.Lerp(maxRotationSpeed, minRotationSpeed, forwardSpeed / desiredForwardSpeed);
               targetRotation1 = Quaternion.RotateTowards(transform.rotation, targetRotation1, rotationSpeed * Time.deltaTime); 
               transform.rotation = targetRotation1;
           }

           animator.ResetTrigger(HashMeleeAttack);
           if (playerInput.IsAttack)
           {
               animator.SetTrigger(HashMeleeAttack);
               
           }
           // OLD CAMERA CODE
            /* Vector3 dir = Vector3.zero;
            dir.x = Input.GetAxis("Horizontal");
            dir.z = Input.GetAxis("Vertical");

            if (dir == Vector3.zero)
            {
                return;
            }

            Vector3 camDirection = cam.transform.rotation * dir;
            Vector3 targetDirection = new Vector3(camDirection.x, 0, camDirection.z);

            if (dir.z >= 0)
            {
                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    Quaternion.LookRotation(targetDirection),
                    0.09f);
            }
            rb.MovePosition(rb.position + targetDirection.normalized * speed * Time.fixedDeltaTime);*/
        }

        private void ComputeForwardMovement()
        {
            Vector3 moveInput = playerInput.MoveInput.normalized;

            desiredForwardSpeed = moveInput.magnitude * maxForwardSpeed;

            float acceleration = playerInput.isMoveInput ? PlayerController.acceleration : deacceleration;

            forwardSpeed = Mathf.MoveTowards(
                forwardSpeed,
                desiredForwardSpeed, 
                Time.deltaTime*acceleration);
            
            animator.SetFloat(HashForwardSpeed, forwardSpeed);
        }

        private void OnAnimatorMove()
        {
            Vector3 movement = animator.deltaPosition;
            movement += verticalSpeed * Vector3.up * Time.fixedDeltaTime;
            charController.Move(movement);
        }

        public void MeleeAttackStart()
        {
            meleeWeapon.BeginAttack();
        }

        public void MeleeAttackEnd()
        {
            meleeWeapon.EndAttack();
        }

        private void ComputeVerticalMovement()
        {
            verticalSpeed = -gravity;
        }

        private void ComputeRotation()
        {
            Vector3 moveInput = playerInput.MoveInput.normalized;

           Vector3 cameraDirection = Quaternion.Euler(0,mainCameraController.PlayerCam.m_XAxis.Value,0)* Vector3.forward;

           Quaternion targetRotation;
           
           if (Mathf.Approximately(Vector3.Dot(moveInput,Vector3.forward),-1.0f))
           {
               targetRotation = Quaternion.LookRotation(-cameraDirection);
           }
           else
           {
               Quaternion momentRotation = Quaternion.FromToRotation(Vector3.forward, moveInput);
               targetRotation = Quaternion.LookRotation(momentRotation * cameraDirection);
           }

           targetRotation1 = targetRotation;
        }
    }
}
