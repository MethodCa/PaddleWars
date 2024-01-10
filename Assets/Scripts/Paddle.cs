using Unity.VisualScripting;
using UnityEngine;

public class MovePaddle : MonoBehaviour
{
    public float movementSpeed = 5f;
    public GameObject megaBall;
    public GameObject barrier;
    public GameObject bullet;
    public GameObject laserBeam;
    public Global global;
    public GameObject timer;
    public Animator animator;
    private float _bound = 28.7f;
    private Vector3 _previousPosition;
    

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            //  AudioManager.instance.PlayComboHit(c, transform.position);
        }

        // calculate the Velocity of a Kinematic Rigidbody
        var position = transform.position;
        global.paddleVelocity = (position - _previousPosition) / Time.deltaTime;
        _previousPosition = position;

        // Catch the Horizontal input
        var horizontalInput = Input.GetAxis("Horizontal");

        // Move paddle in the horizontal axis, if backspace is pressed will move at 2x speed.
        if (Input.GetKey("space"))
            transform.position += new Vector3(horizontalInput * movementSpeed * 2 * Time.deltaTime, 0, 0);
        else
            transform.position += new Vector3(horizontalInput * movementSpeed * Time.deltaTime, 0, 0);

        if (Input.GetKeyDown(KeyCode.Z))
            Instantiate(bullet, new Vector2(transform.position.x, transform.position.y), Quaternion.Euler(0, 0, 90));
        if (Input.GetKeyDown(KeyCode.X))
            Instantiate(laserBeam, new Vector2(transform.position.x, 3.83f), Quaternion.Euler(0, 0, 90));

        // Avoid paddle to go out of bounds
        if (transform.position.x <= _bound * -1)
        {
            transform.position = new Vector3(_bound * -1, transform.position.y, 0);
        }
        else
        {
            if (transform.position.x >= _bound)
                transform.position = new Vector3(_bound, transform.position.y, 0);
        }

        // Update the time for largePaddle PU
        if (global.largePaddle || global.smallPaddle) global.paddleTimer += Time.deltaTime;
        // Restore paddle if largePaddle PU time is >10secs.
        if (global.paddleTimer > 10)
        {
            animator.SetBool("isLarge", false);
            animator.SetBool("isSmall", false);

            GlobalManager.instance.global.largePaddle = false;
            GlobalManager.instance.global.smallPaddle = false;
            GlobalManager.instance.global.paddleTimer = 0;
            _bound = 28.5f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            var body = collision.rigidbody;
            body.velocity = new Vector2(body.velocity.x + global.paddleVelocity.x / 2, body.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("MultiBall"))
        {
            Destroy(collision.gameObject);
            global.stickyBall = false;
            var balls = GameObject.FindGameObjectsWithTag("Ball");
            foreach (var ball in balls)
            {
                global.balls += 2;
                Instantiate(ball, new Vector2(ball.transform.position.x + 0.7f, ball.transform.position.y),
                        Quaternion.identity).GetComponent<Rigidbody2D>().velocity =
                    ball.GetComponent<Rigidbody2D>().velocity;

                Instantiate(ball, new Vector2(ball.transform.position.x - 0.7f, ball.transform.position.y),
                    Quaternion.identity).GetComponent<Rigidbody2D>().velocity = new Vector3(
                    ball.GetComponent<Rigidbody2D>().velocity.x * -1, ball.GetComponent<Rigidbody2D>().velocity.y);
            }
        }

        if (collision.tag.Equals("LargePaddle"))
            if (!global.largePaddle)
            {
                gameObject.GetComponent<Animator>().SetBool("isLarge", true);
                gameObject.GetComponent<Animator>().SetBool("isSmall", false);
                timer.GetComponent<Animator>().SetBool("isLarge", true);
                timer.GetComponent<Animator>().SetBool("isSmall", false);
                global.largePaddle = true;
                global.smallPaddle = false;
                global.paddleTimer = 0;
                _bound = 27.05f;
                Destroy(collision.gameObject);
            }

        if (collision.CompareTag("SmallPaddle"))
            if (!global.smallPaddle)
            {
                gameObject.GetComponent<Animator>().SetBool("isSmall", true);
                gameObject.GetComponent<Animator>().SetBool("isLarge", false);
                timer.GetComponent<Animator>().SetBool("isSmall", true);
                timer.GetComponent<Animator>().SetBool("isLarge", false);
                global.smallPaddle = true;
                global.largePaddle = false;
                global.paddleTimer = 0;
                _bound = 29.3f;
                Destroy(collision.gameObject);
            }

        if (collision.tag.Equals("MegaBall"))
        {
            global.balls += 1;
            Instantiate(megaBall, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>().velocity =
                Vector2.up;
            Destroy(collision.gameObject);
            
        }

        if (collision.tag.Equals("Barrier"))
        {
            barrier.GetComponent<Animator>().SetBool("On", true);
            global.barrierTimer = 0;
            Destroy(collision.gameObject);
        }
    }
}