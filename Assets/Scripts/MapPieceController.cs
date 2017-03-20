using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPieceController : MonoBehaviour
{
    public float hoverHeight;
    public float hoverSpeed;
    private Rigidbody2D rb2d;
    private float yOrigin;
    private int lastFLoatDirection;
    private bool destroy;
    public LevelController level;

    // Use this for initialization
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        yOrigin = gameObject.transform.position.y;
        lastFLoatDirection = -1;
        level.hasMapPiece = true;
    }

    void FixedUpdate()
    {
        hover();
    }

    void hover()
    {
        if (gameObject.transform.position.y - yOrigin >= hoverHeight)
        {
            rb2d.velocity = new Vector2(0, -hoverSpeed);
            lastFLoatDirection = -1;
        }
        else if (yOrigin - gameObject.transform.position.y >= hoverHeight)
        {
            rb2d.velocity = new Vector2(0, hoverSpeed);
            lastFLoatDirection = 1;
        }
        else
        {
            rb2d.velocity = new Vector2(0, lastFLoatDirection * hoverSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        level.foundMapPiece();
        Destroy(gameObject);
    }
}
