using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    [SerializeField]
    private PerformTest PerformTest = default;
    [SerializeField]
    private Map Map = default;

    private const int mapSize = Map.mapSize;

    private List<int[]> startMaps = new List<int[]>();
    private List<int[]> expectedMaps = new List<int[]>();

    private void Awake()
    {
        Random.InitState(1);
    }

    private void Start()
    {
        startMaps.Add(new int[mapSize * mapSize] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0 });
        expectedMaps.Add(new int[mapSize * mapSize] { 0, 0, 0, 4, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 4, 2 });
        startMaps.Add(new int[mapSize * mapSize] { 2, 2, 2, 2, 4, 4, 4, 4, 0, 0, 0, 0, 2, 4, 2, 4 });
        expectedMaps.Add(new int[mapSize * mapSize] { 0, 0, 0, 2, 0, 0, 0, 4, 0, 16, 4, 8, 4, 0, 2, 8 });
        startMaps.Add(new int[mapSize * mapSize] { 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0 });
        expectedMaps.Add(new int[mapSize * mapSize] { 0, 0, 0, 4, 0, 0, 0, 0, 0, 2, 0, 8, 0, 0, 0, 4 });
        startMaps.Add(new int[mapSize * mapSize] { 512, 256, 2, 2, 4, 8, 256, 4, 8, 16, 32, 4, 512, 128, 8, 16 });
        expectedMaps.Add(new int[mapSize * mapSize] { 4, 512, 256, 8, 4, 8, 256, 8, 8, 16, 32, 16, 512, 128, 8, 4 });
        startMaps.Add(new int[mapSize * mapSize] { 16, 512, 4, 8, 4, 16, 256, 8, 8, 16, 32, 16, 256, 128, 2, 8 });
        expectedMaps.Add(new int[mapSize * mapSize] { 16, 512, 4, 2, 4, 32, 256, 32, 8, 128, 32, 8, 4, 256, 2, 8 });
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Test(startMaps[0], expectedMaps[0], 1);
            Test(startMaps[1], expectedMaps[1], 2);
            Test(startMaps[2], expectedMaps[2], 3);
            Test(startMaps[3], expectedMaps[3], 4);
            Test(startMaps[4], expectedMaps[4], 5);
            Debug.Log("Do PlayerMove.MoveUp() to check GameOver");
        }
        
    }

    private void Test(int[] startArray, int[] expectedArray, int testIndex)
    {
        if (PerformTest.Test(startArray, expectedArray))
        {
            Debug.Log($"Test {testIndex}: postitive");
        }
        else
        {
            Debug.Log($"Test {testIndex}: negative");
        }
    }
}
