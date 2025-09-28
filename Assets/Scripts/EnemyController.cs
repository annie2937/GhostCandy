using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float rotationSpeed = 360f; 
    public float rollAmount = 360f; 

    private float startX;
    private bool movingRight = true;  
    private float currentRoll = 0f;

    void Start()
    {
        startX = transform.position.x;
    }

    void Update()
    {
        MoveEnemy();
        RollEnemy(); 
    }

    private void MoveEnemy()
    {
        if (movingRight)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;

            if (transform.position.x >= startX + 20)
            {
                movingRight = false; 
            }
        }
        else
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;

            if (transform.position.x <= startX)
            {
                movingRight = true;
            }
        }
    }

    private void RollEnemy()
    {
        if (movingRight)
        {
            currentRoll -= rotationSpeed * Time.deltaTime; 
        }
        else
        {
            currentRoll += rotationSpeed * Time.deltaTime;
        }

        transform.rotation = Quaternion.Euler(0, 0, currentRoll % rollAmount);
    }
}
