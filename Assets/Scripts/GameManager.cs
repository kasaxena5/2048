using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Tile tile;

    // Start is called before the first frame update
    void Start()
    {
        tile.GetComponent<MovementController>().MoveTowards(new Vector2(2, 0));
    }

    // Update is called once per frame
    void Update()
    {
    }
}
