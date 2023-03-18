using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    [SerializeField]
    private int state = 1;
    public int i;
    public int j;

    public void SetState(int newState)
    {
        state = newState;
    }

    public int GetState()
    {
        return state;
    }
}
