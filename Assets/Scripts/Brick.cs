using System;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public Global global;
    [SerializeField] private BrickType brickType;
    [Space(2)] [Header("Other Sprites")] public Sprite brickDead;
    private int _lives;
    
    // Start is called before the first frame update
    private void Start()
    {
        switch (brickType)
        {
            case BrickType.Normal1Up:
                _lives = 1;
                break;

            case BrickType.Normal2Up:
                _lives = 2;
                break;
            case BrickType.Normal3Up:
                _lives = 3;
                break;
            default:
                _lives = 0;
                break;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.y <= -12f)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball") || collision.collider.CompareTag("MegaBall") ||
            collision.collider.CompareTag("Bullet") ||
            collision.collider.CompareTag("LaserBeam"))
        {
            var body = gameObject.GetComponent<Rigidbody2D>();
            switch (brickType)
            {
                case BrickType.Normal1Up:
                case BrickType.Normal2Up:
                case BrickType.Normal3Up:
                    global.score++;
                    if (_lives > 1 && !collision.gameObject.CompareTag("MegaBall"))
                    {
                        _lives--;
                        var tmp = gameObject.GetComponent<SpriteRenderer>().color;
                        tmp.a /= 2;
                        gameObject.GetComponent<SpriteRenderer>().color = tmp;
                    }
                    else
                    {
                        DestroyBrick(collision);
                    }

                    break;
                case BrickType.MultiBallPu:
                    DestroyBrick(collision);
                    _ = Instantiate(PUManager.instance.multiball,
                        new Vector3(transform.position.x, transform.position.y, 0),
                        PUManager.instance.multiball.transform.rotation);
                    break;

                case BrickType.LargePaddlePu:
                    DestroyBrick(collision);
                    _ = Instantiate(PUManager.instance.largepaddle,
                        new Vector3(transform.position.x, transform.position.y, 0),
                        PUManager.instance.largepaddle.transform.rotation);
                    break;

                case BrickType.MegaBallPu:
                    DestroyBrick(collision);
                    Instantiate(PUManager.instance.megaball, new Vector3(transform.position.x, transform.position.y, 0),
                        PUManager.instance.megaball.transform.rotation);
                    break;

                case BrickType.SmallPaddlePu:
                    DestroyBrick(collision);
                    Instantiate(PUManager.instance.smallPaddle,
                        new Vector3(transform.position.x, transform.position.y, 0),
                        PUManager.instance.smallPaddle.transform.rotation);
                    break;

                case BrickType.Barrier:
                    DestroyBrick(collision);
                    Instantiate(PUManager.instance.barrier,
                        new Vector3(transform.position.x, transform.position.y, 0),
                        PUManager.instance.barrier.transform.rotation);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        if (collision.collider.CompareTag("Bullet")) Destroy(collision.collider.gameObject);
    }

    private void DestroyBrick(Collision2D collision)
    {
        var body = gameObject.GetComponent<Rigidbody2D>();
        global.score++;
        gameObject.GetComponent<SpriteRenderer>().sprite = brickDead;
        body.bodyType = RigidbodyType2D.Dynamic;
        gameObject.layer = 8;
        body.AddForceAtPosition(collision.relativeVelocity, collision.transform.position);
    }

    private enum BrickType
    {
        Normal1Up,
        Normal2Up,
        Normal3Up,
        MultiBallPu,
        LargePaddlePu,
        MegaBallPu,
        SmallPaddlePu,
        Barrier
    }
}