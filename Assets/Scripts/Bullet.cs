using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        var body = GetComponent<Rigidbody2D>();
        body.velocity = Vector2.up * 100;
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.y <= -12f)
            Destroy(gameObject);
    }
}