using UnityEngine;

public class Bird : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    
    private Vector2 startPosition;
    [SerializeField] float pushPower;


    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        startPosition = rb.position;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown() {
        spriteRenderer.color = Color.red;
    }

    private void OnMouseUp() {
        Vector2 currentPosition = rb.position;
        Vector2 direction = startPosition - currentPosition;
        direction.Normalize();

        rb.isKinematic = false;
        rb.AddForce(direction * pushPower);

        spriteRenderer.color = Color.white;
    }

    private void OnMouseDrag() {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
    }
}
