using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Ball : MonoBehaviour
{
    public int megaBallSpeed = 15;
    public int megaBallHits = 2;
    public float minVelocityInY = 10f;
    public Global global;
    public GameObject ball;
    public float maximumSpeed = 30f;
    public float minimumSpeed = 10;
    private Vector2 _velocityBp;
    private Rigidbody2D _body;
    private Rigidbody2D _paddleBody;

    // Start is called before the first frame update
    private void Start()
    {
         
    }
    private void Awake()
    {
        _body = gameObject.GetComponent<Rigidbody2D>();
        _paddleBody = GameObject.FindGameObjectWithTag("Paddle").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (global.stickyBall)
            transform.position = new Vector3(_paddleBody.position.x, -8.66f, 0);
        if (Input.GetKeyDown("space") && global.stickyBall)
        {
            global.stickyBall = false;
            _body.velocity = Vector2.up;
        }

        if (!(transform.position.y <= -12f)) return;
        if (global.balls == 1)
        {
            global.stickyBall = true;
        }
        else
        {
            global.balls--;
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        // Correct minimum speed
        if (_body.velocity.magnitude < minimumSpeed)
            _body.velocity = _body.velocity.normalized * minimumSpeed;
        //Correct maximum speed
        if (_body.velocity.magnitude > maximumSpeed)
            _body.velocity = _body.velocity.normalized * maximumSpeed;
        if (_body.velocity.magnitude > maximumSpeed && CompareTag("MegaBall"))
            _body.velocity = _body.velocity.normalized * megaBallSpeed;
        // Save velocity and pos of last Fixed update in case I need that info before a simulation (Collision etc..)
        _velocityBp = _body.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Correct trajectory of ball if is getting close to vel=0 in x or y 
        if (_body.velocity.x <= 0.1f)
            _body.velocity = new Vector2(_body.velocity.x + 0.3f * Mathf.Sign(_body.velocity.x), _body.velocity.y);
        if (Mathf.Abs(_body.velocity.y) <= minVelocityInY)
            _body.velocity = new Vector2(_body.velocity.x, _body.velocity.y + 5f * Mathf.Sign(_body.velocity.y));
        // Add 10% to the velocity of the ball
        _body.velocity = _body.velocity * 1.1f;

        if (collision.collider.tag.Equals("Brick") && CompareTag("MegaBall"))
            _body.velocity = _velocityBp;
        if (CompareTag("MegaBall") && collision.collider.tag.Equals("Paddle"))
            megaBallHits--;
        if (megaBallHits <= 0 && CompareTag("MegaBall"))
        {
            var position = transform.position;
            Instantiate(ball, new Vector2(position.x, position.y), Quaternion.identity).GetComponent<Rigidbody2D>().velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
            Destroy(gameObject);
        }
    }
}