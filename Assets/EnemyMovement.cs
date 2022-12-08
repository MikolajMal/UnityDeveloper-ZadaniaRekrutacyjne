using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Vector2 screenBounds;
    public float speed;
    float objectWidth, objectHeight;
    float colliderSize;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        SetStartPosition();

        spriteRenderer = GetComponent<SpriteRenderer>();
        objectWidth = spriteRenderer.bounds.size.x / 2;
        objectHeight = spriteRenderer.bounds.size.y / 2;

        colliderSize = GetComponent<Collider2D>().bounds.size.x;
    }

    void SetStartPosition()
    {
        transform.position = new Vector3(Random.Range(-screenBounds.x, screenBounds.x), Random.Range(-screenBounds.y, screenBounds.y));
    }

    public void MoveEnemy(Vector3 playerPosition)
    {
        float xMovement, yMovement;
        if (transform.position.x > playerPosition.x) xMovement = speed;
        else xMovement = -speed;

        if (transform.position.y > playerPosition.y) yMovement = speed;
        else yMovement = -speed;

        transform.Translate(new Vector3(xMovement, yMovement) * Time.deltaTime);

        if ( Vector3.Distance(transform.position,playerPosition) < colliderSize)
        {
            Debug.Log(Mathf.Abs(transform.position.x - playerPosition.x));
            Debug.Log(Mathf.Abs(transform.position.y - playerPosition.y));
            this.gameObject.tag = "CapturedEnemy";
            spriteRenderer.color = Color.blue;
        }
    }

    private void LateUpdate()
    {
        Vector3 playerPos = transform.position;

        playerPos.x = Mathf.Clamp(playerPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        playerPos.y = Mathf.Clamp(playerPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = playerPos;
    }
}
