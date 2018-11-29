using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBoundaries : MonoBehaviour
{
    private float ColliderSize = 10;


    // Use this for initialization
    void Start()
    {
        GenerateBoundaries();
    }


    public void GenerateBoundaries()
    {
        foreach (var collider in GetComponents<BoxCollider2D>())
        {
            Destroy(collider);
        }

        var bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        var bottomRight = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth, 0));
        var topLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, Camera.main.pixelHeight));
        var topRight = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight));

        var left = gameObject.AddComponent<BoxCollider2D>();
        left.size = new Vector2(ColliderSize, topLeft.y - bottomLeft.y + ColliderSize);
        left.offset = new Vector2(topLeft.x - ColliderSize/2, 0);

        var right = gameObject.AddComponent<BoxCollider2D>();
        right.size = new Vector2(ColliderSize, topRight.y - bottomRight.y + ColliderSize);
        right.offset = new Vector2(topRight.x + ColliderSize/2, 0);

        var top = gameObject.AddComponent<BoxCollider2D>();
        top.size = new Vector2(topRight.x - topLeft.x + ColliderSize, ColliderSize);
        top.offset = new Vector2(0, topLeft.y + ColliderSize / 2);

        var bottom = gameObject.AddComponent<BoxCollider2D>();
        bottom.size = new Vector2(bottomRight.x - bottomLeft.x + ColliderSize, ColliderSize);
        bottom.offset = new Vector2(0, bottomLeft.y - ColliderSize / 2);
    }
}
