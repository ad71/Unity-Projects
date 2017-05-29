using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count (int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    public int cols = 8;
    public int rows = 8;
    public Count wallcount = new Count(5, 9);
    public Count foodcount = new Count(1, 5);
    public GameObject exit;
    public GameObject[] floortiles;
    public GameObject[] walltiles;
    public GameObject[] foodtiles;
    public GameObject[] enemytiles;
    public GameObject[] outerwalltiles;

    private Transform boardHolder;
    private List<Vector3> gridPositions = new List<Vector3>();

    void InitializeList()
    {
        gridPositions.Clear();
        for(int x = 1; x < cols - 1; ++x)
        {
            for(int y = 1; y < rows - 1; ++y)
            {
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }

    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;
        for(int x = -1; x < cols +1; ++x)
        {
            for(int y = -1; y < rows + 1; ++y)
            {
                GameObject toInstantiate = floortiles[Random.Range(0, floortiles.Length)];
                if(x == -1 || x == cols || y == -1 || y == rows)
                    toInstantiate = outerwalltiles[Random.Range(0, outerwalltiles.Length)];
                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                //Quaternion.identity sets angle to zero and 'as GameObject' basically casts the expression into a GameObject
                instance.transform.SetParent(boardHolder);
            }
        }
    }

    Vector3 RandomPosition()
    {
        int RandomIndex = Random.Range(0, gridPositions.Count);
        Vector3 randomPosition = gridPositions[RandomIndex];
        gridPositions.RemoveAt(RandomIndex);
        return randomPosition;
    }

    void LayoutObjectAtRandom(GameObject[] tilearray, int minimum, int maximum)
    {
        int ObjectCount = Random.Range(minimum, maximum + 1);
        for(int i = 0; i < ObjectCount; ++i)
        {
            Vector3 randomposition = RandomPosition();
            GameObject tilechoice = tilearray[Random.Range(0, tilearray.Length)];
            Instantiate(tilechoice, randomposition, Quaternion.identity);
        }
    }

    public void SetupScene(int level)
    {
        BoardSetup();
        InitializeList();
        LayoutObjectAtRandom(walltiles, wallcount.minimum, wallcount.maximum);
        LayoutObjectAtRandom(foodtiles, foodcount.minimum, foodcount.maximum);
        int enemycount = (int)Mathf.Log(level, 2f);
        LayoutObjectAtRandom(enemytiles, enemycount, enemycount);
        Instantiate(exit, new Vector3(cols - 1, rows - 1, 0f), Quaternion.identity);
    }
}
