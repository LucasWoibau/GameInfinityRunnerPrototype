using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    public GameObject[] obstacles;
    public Vector2 numberOfObstacles;

    public List<GameObject> newObstacles;

    void Start()
    {
        int newNumberOfObstacles = (int)Random.Range(numberOfObstacles.x, numberOfObstacles.y);

        for (int i = 0; i < newNumberOfObstacles; i++)
        {
            newObstacles.Add(Instantiate(obstacles[Random.Range(0, obstacles.Length)], transform));
			newObstacles[i].SetActive(false);
        }

        PositionateObstacle();
    }
    
    void PositionateObstacle()
    {
        for (int i = 0; i < newObstacles.Count; i++)
        {
            float posZMin = (179.36f / newObstacles.Count) + (179.36f / newObstacles.Count) * i;
            float posZMax = (179.36f / newObstacles.Count) + (179.36f / newObstacles.Count) * i + 1;
            newObstacles[i].transform.localPosition = new Vector3(0, 0, Random.Range(posZMin, posZMax));
            newObstacles[i].SetActive(true);
        }
    }
}
