using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingRange
{
    public class PlayerMovement : MonoBehaviour
    {
        public FixedJoystick joyStick;
        public CharacterController controller;
        public float speed = 10f;
        public float gravity = -9.81f;
        public float jumpHeight = 3f;

        public Transform groundCheck;
        public float groundDistance = 0.4f;
        public LayerMask groundMask;

        private bool grounded;
        Vector3 velo;

      

        void Start()
        {

        }

        void Update()
        {
            grounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (grounded && velo.y < 0)
            {
                velo.y = -2f;
            }

            float x = joyStick.Horizontal;
            float z = joyStick.Vertical;

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

           /* if (Input.GetButtonDown("Jump") && grounded)
            {
                velo.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                grounded = false;
            }
*/


            velo.y += gravity * Time.deltaTime;

            controller.Move(velo * Time.deltaTime);

        }

        public void Jump()
        {
            if (grounded)
            {
                velo.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                grounded = false;
            }


        }


    }
}
