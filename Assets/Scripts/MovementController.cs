using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Tile))]
public class MovementController : MonoBehaviour
{
    private bool isMoving = false;
    private Tile tile;

    [SerializeField]
    private float lerpDuration = 3;

    private Vector2 valueToLerp;

    private void Awake()
    {
        tile = GetComponent<Tile>();
    }

    public void MoveTowards(Vector2 newPos)
    {
        if(!isMoving)
        {
            StopAllCoroutines();
            isMoving = true;
            StartCoroutine(Lerp(newPos));
        }

    }

    IEnumerator Lerp(Vector2 newPosition)
    {
        float timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            valueToLerp = Vector2.Lerp(tile.transform.position, newPosition, timeElapsed / (lerpDuration * Time.deltaTime));
            tile.transform.position = valueToLerp;
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        isMoving = false;
        valueToLerp = newPosition;
        tile.transform.position = newPosition;
    }
}
