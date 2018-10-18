using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    public class Repeat : MonoBehaviour
    {
        public SpriteRenderer rend;
        public float moveSpeed = 1f;
        public bool isRepeating = true;

        private float width;

        void Start()
        {
            if (rend)
            {
                //Gets the width from the Sprite Renderer and scales it by transform.
                width = rend.bounds.size.x;
            }
        }


        void Update()
        {
            //Gets position
            Vector3 pos = transform.position;
            //Move position
            pos += Vector3.left * moveSpeed * Time.deltaTime;
            //If position on x axis  is less than or minus width
            if (pos.x < -width && isRepeating)
            {
                //Repeat = move the box to the opposite side of screen
                float offset = (width - 0.1f) * 2;
                Vector3 newPosition = new Vector3(offset, 0, 0);
                pos += newPosition;

            }
            transform.position = pos;
        }
    }
}
