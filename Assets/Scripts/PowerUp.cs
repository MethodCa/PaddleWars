using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int speed = 10;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        var pos = transform.position;
        transform.position = new Vector3(pos.x, pos.y - speed * Time.deltaTime, 0);

        if (transform.position.y <= -12f)
            Destroy(gameObject);
    }
}