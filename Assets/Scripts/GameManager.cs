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
    private int[] dy = new int[] { 0, 0, -1, 1 };

    private Tile[,] tiles;

    private void SpawnNewTile()
    {
        tiles[0, 0] = Instantiate(tilePrefab);
        tiles[1, 0] = Instantiate(tilePrefab);
        tiles[2, 0] = Instantiate(tilePrefab);
        tiles[3, 0] = Instantiate(tilePrefab);

    }

    private void InitializeGame()
    {
        tiles = new Tile[n, n];
        SpawnNewTile();
    }

    private void MoveTiles(int k)
    {
        Tile[,] newTiles = new Tile[n, n];
        bool dirX = dx[k] > 0;
        bool dirY = dy[k] > 0;
        for(int i = 0; i < n; i++)
        {
            int j = (dirX) ? n - 1 : 0;
            int lastValidPosition = (dirX) ? n : -1;
            while((dirX) ? j >= 0 : j < n)
            {
                int step = (dirX) ? -1 : 1;
                if (tiles[i, j] != null)
                {
                    tiles[i, j].GetComponent<MovementController>().MoveTowards(new Vector2(lastValidPosition + step, i));
                    newTiles[i, lastValidPosition + step] = tiles[i, j];
                    lastValidPosition = j;
                }
                j += step;
            }
        }
        tiles = newTiles;
        //SpawnNewTile();
    }

    void Start()
    {
        InitializeGame();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            MoveTiles(2);
        if (Input.GetKeyDown(KeyCode.DownArrow))
            MoveTiles(3);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            MoveTiles(0);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            MoveTiles(1);

    }
}
