using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        var pos = transform.position;
        transform.position = new Vector3(pos.x, pos.y + 50 * Time.deltaTime, 0);

        if (transform.position.y >= 33f)
            Destroy(gameObject);
    }
}