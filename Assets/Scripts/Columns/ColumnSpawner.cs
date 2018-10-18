using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    public class ColumnSpawner : MonoBehaviour
    {
        public GameObject prefab;
        public float spawnRate = 3f;
        public int maxPoolSize = 5;
        public float minY = -1f;
        public float maxY = 3.5f;
        public Vector3 standbyPos = new Vector3(-15, -25);
        public float startX = 10f;
        
        private Transform[] columns;
        private int currentColumn = 0;
        private float spawnTimer = 0f;

        void Start()
        {
            SpawnColumns();
        }

        void Update()
        {
            //Increase timer
            spawnTimer += Time.deltaTime;
            //if the game is not over and has spawntimer reached the spawnrate
            if(!GameManager.Instance.isGameOver && spawnTimer >= spawnRate)
            {
                //reset timer
                spawnTimer = 0f;
                //Reposition a column
                RepositionColumn();
            }
        }
        void SpawnColumns()
        {
            //Create a pooling object to store columns
            columns = new Transform[maxPoolSize];
            //Loop through the pool
            for (int i = 0; i < columns.Length; i++)
            {
                //Fill each element with a new column
                //Creates clone of prefab
                GameObject clone = Instantiate(prefab, transform);
                //Clone gets transform of column
                Transform column = clone.transform;
                //Sets position of transform
                column.position = standbyPos;
                //adds column to pool
                columns[i] = column;
            }

        }
        void RepositionColumn()
        {
            //Get random y position
            float randomY = Random.Range(minY, maxY);
            //get current column
            Transform column = columns[currentColumn];
            //Reposition the column
            column.position = new Vector3(startX, randomY);
            //calls next column in list
            currentColumn++;
            //if current column exceeds pool size
            if (currentColumn >= maxPoolSize)
            {
                //sets current column back to zero
                currentColumn = 0;
            }
        }
    }
}
