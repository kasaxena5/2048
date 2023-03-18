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
    private Vector2 originalPosition;

    private void Awake()
    {
        tile = GetComponent<Tile>();
    }

    public void MoveTowards(Vector2 newPos)
    {
        if(!isMoving)
        {
            isMoving = true;
            StartCoroutine(Lerp(newPos));
        }

    }

    IEnumerator Lerp(Vector2 newPosition)
    {
        float timeElapsed = 0;
        originalPosition = tile.transform.position;
        while (timeElapsed < lerpDuration)
        {
            float t = timeElapsed / lerpDuration;
            valueToLerp = Vector2.Lerp(originalPosition, newPosition, t);
            tile.transform.position = valueToLerp;
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        isMoving = false;
        Debug.Log(isMoving);
        valueToLerp = newPosition;
        tile.transform.position = newPosition;
    }
}
