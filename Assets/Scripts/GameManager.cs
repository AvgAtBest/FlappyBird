using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    public class GameManager : MonoBehaviour
    {
        #region Singleton
        public static GameManager Instance = null;
        private void Awake()
        {
            Instance = this;
            //if (Instance != null)
            //{
            //    Destroy(this);
            //}
        }
        private void OnDestroy()
        {
            Instance = null;
        }
        #endregion
        //gameover is false
        public bool isGameOver = false;
        //player score
        public int score = 0;
        public float timeScale = 1;
        //Container that functions can subscribe to and call from
        public delegate void IntCallback(int number);
        public IntCallback scoreAdded;
        void Start()
        {

        }

        public void AddScore(int scoreToAdd)
        {
            //if the game is over /Is the game over?
            if (isGameOver)
                return;
            //add score
            score += scoreToAdd;

            //call subscribers
            scoreAdded.Invoke(score);
        }
        public void GameOver()
        {
            timeScale = 0;
            isGameOver = true;
        }
    }
}
