using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 screenBounds;
    float horizontal, vertical;
    public float speed;
    float objectWidth, objectHeight;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        spriteRenderer = GetComponent<SpriteRenderer>();
        objectWidth = spriteRenderer.bounds.size.x/2;
        objectHeight = spriteRenderer.bounds.size.y/2;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector3 (horizontal, vertical, 0);
        //transform.Translate(new Vector3(horizontal, vertical) * Time.deltaTime * speed);
    }

    private void LateUpdate()
    {
        Vector3 playerPos = transform.position;

        playerPos.x = Mathf.Clamp(playerPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        playerPos.y = Mathf.Clamp(playerPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = playerPos;
    }
}
