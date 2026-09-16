using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 screenBounds;

    [SerializeField] private float speed = 5f;
    private float scaleY;
    private float scaleX;
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        // scale to make sure half of the player doesn't go out of bounds
        scaleX = transform.localScale.x / 2;
        scaleY = transform.localScale.y / 2;
    }

    void Update()
    {
        // movement logic
        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Vector3 move = new Vector3(x, y, 0);
        move.Normalize();

        transform.Translate(move * speed * Time.deltaTime);

        ClampToBounds();
    }

    // clamp to inside the camera bounds
    private void ClampToBounds()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, -screenBounds.x + scaleX, screenBounds.x - scaleX);
        viewPos.y = Mathf.Clamp(viewPos.y, -screenBounds.y + scaleY, screenBounds.y - scaleY);
        transform.position = viewPos;
    }
}
