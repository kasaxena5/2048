using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Tile tilePrefab;

    [SerializeField]
    private int n = 4;

    private int[] dx = new int[] { 1, -1, 0, 0 };
    private int[] dy = new int[] { 0, 1, -1, 1 };

    private Tile[,] tiles;

    private void SpawnNewTile()
    {
        tiles[0, 0] = Instantiate(tilePrefab);
    }

    private void InitializeGame()
    {
        tiles = new Tile[n, n];
        SpawnNewTile();
    }

    private void MoveTiles(int k)
    {
        Tile[,] newTiles = new Tile[n, n];

        for(int i = 0; i < n; i++)
        {
            int j = n - 1;
            int lastValidPosition = n;
            while(j >= 0)
            {
                if(tiles[i, j] != null)
                {
                    tiles[i, j].GetComponent<MovementController>().MoveTowards(new Vector2(lastValidPosition - 1, i));
                    newTiles[i, lastValidPosition - 1] = tiles[i, j];
                    lastValidPosition = j;
                }
                j--;
            }
        }
        tiles = newTiles;
        SpawnNewTile();
    }

    void Start()
    {
        InitializeGame();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            MoveTiles(0);
        if (Input.GetKeyDown(KeyCode.DownArrow))
            MoveTiles(0);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            MoveTiles(0);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            MoveTiles(0);

    }
}
