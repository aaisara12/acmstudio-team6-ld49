using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFly : MonoBehaviour
{
    private float speed;
    public Vector3[] positions;
    private Vector3 startPos;
    [SerializeField] float attackTimer;
    public float countDown;
    private bool startTimer;
    private bool attack;
    private bool idle;
    private int index;

    public Transform player;
    // temporary position for enemy attack
    private Vector3 pos;

    void Start()
    {
        countDown = attackTimer;
        startTimer = true;
        attack = false;
        idle = true;
        player = GameObject.Find("Player").transform;
        startPos = transform.position;
        positions[0] = transform.position;
        positions[1] = transform.position;
        positions[1].y = transform.position.y - 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (idle)
        {
            speed = 1;
            Fly();
        }

        if (startTimer == true)
        {
            countDown -= Time.deltaTime;
        }

        if (countDown <= 0)
        {
            pos = player.position;
            countDown = attackTimer;
            speed = 10;
            startTimer = false;
            attack = true;
            idle = false;
        }

        if (!startTimer && attack)
        {
            transform.position = Vector2.MoveTowards(transform.position, pos, Time.deltaTime * speed);
        }

        if (!startTimer && !attack)
        {
            transform.position = Vector2.MoveTowards(transform.position, startPos, Time.deltaTime * speed);
        }

        if (transform.position == startPos && !startTimer)
        {
            startTimer = true;
            idle = true;
        }

        if (transform.position == pos && attack)
        {
            attack = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            // add damage to player
            attack = false;
        }
    }

    private void Fly()
    {
        transform.position = Vector2.MoveTowards(transform.position, positions[index], Time.deltaTime * speed);
        if (transform.position == positions[index])
        {
            if (index == positions.Length - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
        }
    }
}
