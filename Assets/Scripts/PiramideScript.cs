using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiramideScript : MonoBehaviour
{
    public GameObject cubePrefab;

    public int baseSize = 5;
    public int height = 5;

    void Start() 
    {
        for (int y = 0; y < height; y++) {
            for (int x = 0; x < baseSize - y; x++) {
                Vector3 position = new Vector3(x - ((baseSize - y) * 0.5f) + 0.5f, y, 10.0f);
                GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity);
                cube.transform.localScale = new Vector3(1f - (y * 0.1f), 1f, 1f - (y * 0.5f));
                cube.transform.parent = transform;
            }
        }
    }



}
