using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Global Variables")]
public class Global : ScriptableObject
{
    public int balls;
    public bool stickyBall;
    public bool largePaddle;
    public bool smallPaddle;
    public bool barrier;
    public float paddleTimer;
    public float barrierTimer;
    public int score;
    public Vector3 paddleVelocity;

    public void OnEnable()
    {
        balls = 1;
        stickyBall = true;
        largePaddle = false;
        smallPaddle = false;
        barrier = false;
        paddleTimer = 0f;
        barrierTimer = 0f;
        score = 0;
        paddleVelocity = new Vector3(0, 0, 0);
    }
}