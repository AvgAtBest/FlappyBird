using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FlappyBird
{
    public class UINumber : MonoBehaviour
    {
        public int number = 0;
        public Sprite[] numbers; //stores all the digits
        public GameObject scoreTextPrefab; //score prefab text element to create
        public Vector3 standbyPos = new Vector3(-15, 15); //position offscreen for standby
        public int maxDigits = 5; //the amount of digits to store offscreen for reuse

        private GameObject[] scoreTextPool; //gameobject with pool containing the scoreText
        private int[] digits; //digits

        public int Value
        {
            //get value
            get
            {
                //return the value obtained
                return number;
            }
            set
            {
                number = value;
                RefreshText(value);
            }
        }
        void Start()
        {
            SpawnPool();

            //subscribe to scoreAdded function in GameManager
            GameManager.Instance.scoreAdded += RefreshText;

            RefreshText(number);
            //Update score to start on zero
        }


        void Update()
        {

        }
        void RefreshText(int num)
        {
            //convert score into array of digits
            int[] digits = GetDigits(num);
            //loop through digits
            for (int i = 0; i < digits.Length; i++)
            {
                //get value of each digit
                int value = digits[i];
                //gets text element in pool
                GameObject textElement = scoreTextPool[i];
                //gets image element attached to it
                Image img = textElement.GetComponent<Image>();
                //assign sprite to number using value
                img.sprite = numbers[value];
                //activate text element
                textElement.SetActive(true);
            }
            // Loop through all remaining text elements in the pool
            for (int i = digits.Length; i < scoreTextPool.Length; i++)
            {
                // Deactivate that element
                scoreTextPool[i].SetActive(false);
            }
        }
        void SpawnPool()
        {
            //Allocate memory for the score text pool
            scoreTextPool = new GameObject[maxDigits];
            //Loop through all available digits
            for (int i = 0; i < maxDigits; i++)
            {
                //create a new gameObject offscreen
                GameObject clone = Instantiate(scoreTextPrefab, standbyPos, Quaternion.identity);
                //Gets image component attacked to clone
                Image img = clone.GetComponent<Image>();
                //set sprite corresponding number sprite
                img.sprite = numbers[i];
                //attach to self
                clone.transform.SetParent(transform);
                //set name of text to index
                clone.name = i.ToString();
                //Adds it to pool
                scoreTextPool[i] = clone;
            }
        }
        //converts number into a array of single digits
        int[] GetDigits(int number)
        {

            List<int> digits = new List<int>();
            //while numbers is greated than 10
            while (number >= 10)
            {
                //modules by 10 and return remainder
                digits.Add(number % 10);
                //dividal total number by 10
                number /= 10;
            }
            //add last number to digit
            digits.Add(number);
            //flip array around 
            digits.Reverse();
            //return to array
            return digits.ToArray();
        }
    }
}
