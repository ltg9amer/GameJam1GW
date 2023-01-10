using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdStage : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstacles;
    [SerializeField] private List<Transform> obstaclePositions;

    private void OnEnable()
    {
        for (int i = 0; i < obstaclePositions.Count; i++)
        {
            GameObject obstacle = Instantiate(obstacles[Random.Range(0, obstacles.Count)]);

            obstacle.transform.SetParent(obstaclePositions[i]);

            obstacle.transform.localPosition = Vector3.zero;
        }
    }
}
