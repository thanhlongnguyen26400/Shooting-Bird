using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float xSpeed;
    public float minYspeed;
    public float maxYspeed;
    public GameObject deathVfx;
    public int timeDestroy;

    Rigidbody2D m_rb;

    bool m_moveStart;
    bool m_isDead;

    public bool IsDead { get => m_isDead; set => m_isDead = value; }

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        RandommovingDir();
        Flip();
        Destroy(gameObject, timeDestroy);
    }
    private void Update()
    {
        m_rb.velocity = m_moveStart ? 
            new Vector2(xSpeed, Random.Range(minYspeed, maxYspeed))
            : new Vector2(-xSpeed, Random.Range(minYspeed, maxYspeed));
    }

    public void RandommovingDir()
    {
        m_moveStart = transform.position.x < 0 ? true : false;
    }

    void Flip()
    {
        if (!m_moveStart)
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    public void BirdDie()
    {
        m_isDead = true;
        Destroy(gameObject);

        Debug.Log(">>> bird die :" + gameObject.name);
        if (deathVfx)
            Instantiate(deathVfx, transform.position, Quaternion.identity);

    }
}
