using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FlappyBird
{
    public class Player : MonoBehaviour
    {
        public float upForce = 5f;
        public bool isDead = false;
        public Rigidbody2D rigid;

        void Start()
        {

        }


        void Update()
        {
            //If left mouse button is clicked
            if (Input.GetMouseButtonDown(0))
            {
                //Flap function
                Flap();
            }
        }
        //Makes the bird move when called
        void Flap()
        {
            //Is the player not dead?
            if (!isDead)
            {
                //cancel the velocity
                rigid.velocity = Vector2.zero;

                //Give the bird an upward force using impulse
                rigid.AddForce(new Vector2(0, upForce), ForceMode2D.Impulse);
            }
        }
    }
}
