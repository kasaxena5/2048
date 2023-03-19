using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    [SerializeField]
    private int state = 0;

    public bool isValid = true;

    public int i;
    public int j;

    private void Start()
    {
        SetState(3);
    }

    public void SetState(int newState)
    {
        state = newState;
        this.GetComponent<SpriteRenderer>().color = state switch
        {
            0 => new Color(1.0f, 0.9f, 0.9f),
            1 => new Color(1,0f, 0.8f, 0.8f),
            2 => new Color(1.0f, 0.7f, 0.7f),
            3 => new Color(1.0f, 0.6f, 0.6f),
            4 => new Color(1.0f, 0.5f, 0.5f),
            5 => new Color(1.0f, 0.4f, 0.4f),
            6 => new Color(1.0f, 0.3f, 0.3f),
            7 => new Color(1.0f, 0.2f, 0.2f),
            8 => new Color(1.0f, 0.1f, 0.1f),
            9 => new Color(1.0f, 0f, 0.0f),
            _ => Color.white,
        };
    }

    public int GetState()
    {
        return state;
    }
}
