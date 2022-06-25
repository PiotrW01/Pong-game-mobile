using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 v2;
    Vector2 lastvelocity;
    public int speed = 10;
    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float x = Random.Range(-0.9f, 0.9f);
        float y = Random.Range(-0.9f, 0.9f);

        v2 = new Vector2(x, y);
        rb.velocity = v2.normalized * speed;

    }

    //0.02 * 300
    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude < 4.9f)
        {
            rb.velocity = rb.velocity.normalized * 5.0f;
        }
        if (rb.velocity.magnitude > 5.1f)
        {
            rb.velocity = rb.velocity.normalized * 5.0f;

        }
        if (rb.velocity.x == 0f)
        {
            rb.velocity += Vector2.right * 2;
        }
        if (rb.velocity.y == 0f)
        {
            rb.velocity += Vector2.up * 2;
        }

        if (Mathf.Abs(rb.velocity.x) < 0.7f)
        {
            rb.velocity += new Vector2(0.2f, 0);
        }

        if (Mathf.Abs(rb.velocity.y) < 0.7f)
        {
            rb.velocity += new Vector2(0, 0.2f);
        }

        lastvelocity = rb.velocity;
        Debug.Log(rb.velocity);
        Debug.Log(rb.velocity.magnitude);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var spid = lastvelocity.magnitude;
        rb.velocity = Vector2.Reflect(lastvelocity.normalized, collision.contacts[0].normal) * Mathf.Max(spid, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Destroy(gameObject);
        GameObject.Find("PlayerPlatform").SetActive(false);
        gameOver.SetActive(true);
    }
}
