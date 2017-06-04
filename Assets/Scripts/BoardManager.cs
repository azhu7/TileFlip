using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public int columns = 6;
    public int rows = 6;
    public GameObject floorTile;
    public GameObject outerWallTile;
    private Transform boardHolder;
    private List<Vector3> gridPositions = new List<Vector3>();

    void InitializeList()
    {
        gridPositions.Clear();
        for (int x = 1; x < columns - 1; ++x)
        {
            for (int y = 1; y < rows - 1; ++y)
            {
                gridPositions.Add(new Vector3(x, y));
            }
        }
    }

    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;
        for (int x = -1; x < columns + 1; ++x)
        {
            for (int y = -1; y < rows + 1; ++y)
            {
                // Place inner wall tile if within board
                GameObject toInstantiate = floorTile;

                // Place outer wall tile if on edge
                if (x == -1 || x == columns || y == -1 || y == rows)
                    toInstantiate = outerWallTile;

                GameObject instance =
                    Instantiate(toInstantiate, new Vector3(x, y), Quaternion.identity) as GameObject;

                instance.transform.SetParent(boardHolder);
            }
        }
    }

    public void SetupScene(int level)
    {
        BoardSetup();
        InitializeList();
    }
}
