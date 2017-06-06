using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool changeColor = true;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!changeColor)
        {
            changeColor = true;
            return;
        }
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        if (sr.color == Color.magenta)
            sr.color = Color.green;
        else if (sr.color == Color.green)
            sr.color = Color.cyan;
        else
            sr.color = Color.magenta;
        changeColor = false;
    }
}
