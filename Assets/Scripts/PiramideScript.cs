using UnityEngine;

public class PiramideScript : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // Array of obstacle prefabs to be randomly selected
    public int numRowsMin = 2; // Minimum number of rows in the pyramid
    public int numRowsMax = 5; // Maximum number of rows in the pyramid
    public int numObstaclesPerRowMin = 2; // Minimum number of obstacles per row in the pyramid
    public int numObstaclesPerRowMax = 5; // Maximum number of obstacles per row in the pyramid
    public float obstacleSpacing = 1.0f; // Spacing between obstacles in a row
    public float rowSpacing = 1.5f; // Spacing between rows of obstacles

    public Vector3 initialPosition = new Vector3(1.75f, -1.1f, 12.3f); // Initial position of the obstacles
    public Quaternion initialRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f); // Initial rotation of the obstacles

    void Start()
    {
        GenerateObstaclePyramids();
    }

    void GenerateObstaclePyramids()
    {
        for (int i = 0; i < 9; i++)
        {
            int numRows = Random.Range(numRowsMin, numRowsMax + 1);
            int numObstaclesPerRow = Random.Range(numObstaclesPerRowMin, numObstaclesPerRowMax + 1);

            float zPos = initialPosition.z + i * 20.0f;

            for (int row = 0; row < numRows; row++)
            {
                float rowOffset = row * rowSpacing;
                int numObstaclesInRow = numObstaclesPerRow - row;

                for (int j = 0; j < numObstaclesInRow; j++)
                {
                    float xPos = j * obstacleSpacing - numObstaclesInRow * obstacleSpacing * 0.5f;
                    float yPos = rowOffset;

                    Vector3 position = new Vector3(initialPosition.x + xPos, initialPosition.y + yPos, zPos);
                    Quaternion rotation = initialRotation;

                    int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
                    GameObject obstacle = Instantiate(obstaclePrefabs[obstacleIndex], position, rotation, transform);
                    Rigidbody rb = obstacle.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.isKinematic = false; // Set "Is Kinematic" to true
                    }
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Vehicle"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                foreach (Transform child in transform)
                {
                    Rigidbody childRb = child.GetComponent<Rigidbody>();
                    if (childRb != null)
                    {
                        childRb.isKinematic = false; // Set "Is Kinematic" to false for the child obstacles
                        childRb.useGravity = true; // Enable gravity for the child obstacles
                    }
                }
            }
        }
    }
}



