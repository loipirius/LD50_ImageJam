using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public BoxCollider2D myCollider;
    public Rigidbody2D rb;
    private float width;
    [SerializeField]
    private float scrollspeed = -5f;

    private Vector2 scroller;
    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        width = myCollider.size.x;
        myCollider.enabled = false;
        scroller = new Vector2(scrollspeed, 0);
        rb.velocity = scroller;
    }

    void Update()
    {
        if (transform.position.x < -width)
        {
            Vector2 resetPosition = new Vector2(width * 2f, 0);
            transform.position = (Vector2) transform.position + resetPosition;
            ResetObstacle();
        }

        scrollspeed -= Time.deltaTime * 0.5f;
        scroller = new Vector2(scrollspeed,0);
        rb.velocity = scroller;
    }

    void ResetObstacle()
    {
        transform.GetChild(0).localPosition = new Vector3(Random.Range(-5,5), -1.75f, 0);
    }
}
