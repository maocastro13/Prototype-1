using UnityEngine;

public class PiramideScript : MonoBehaviour
{
    public GameObject obstaclePrefab; // The prefab of the obstacle to be stacked
    public int numRows = 3; // Number of rows in the pyramid
    public int numObstaclesPerRow = 3; // Number of obstacles per row in the pyramid
    public float obstacleSpacing = 1.0f; // Spacing between obstacles in a row
    public float rowSpacing = 1.5f; // Spacing between rows of obstacles

    void Start()
    {
        GenerateObstaclePyramids();
    }

    void GenerateObstaclePyramids()
    {
        for (int row = 0; row < numRows; row++)
        {
            float rowOffset = row * rowSpacing;
            int numObstaclesInRow = numObstaclesPerRow - row;

            for (int i = 0; i < numObstaclesInRow; i++)
            {
                float xPos = i * obstacleSpacing - numObstaclesInRow * obstacleSpacing * 0.5f;
                float zPos = rowOffset;

                Instantiate(obstaclePrefab, new Vector3(xPos, 0.0f, zPos), Quaternion.identity, transform);
            }
        }
    }
}
