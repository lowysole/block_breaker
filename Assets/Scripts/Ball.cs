using UnityEngine;

public class Ball : MonoBehaviour
{
    //SerializedFileds
    [SerializeField] Paddle paddle1;
    [SerializeField] float velX = 2f, velY = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomVelFactor = 0.2f;

    //Variables
    Vector2 distBallToPaddle;
    bool hasStarted = false;


    //Cached Components
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        distBallToPaddle = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchBall();
        }
    }

    private void LaunchBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myRigidBody.velocity = new Vector2(velX, velY);
            hasStarted = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x,
            paddle1.transform.position.y);
        Vector2 ballPos = new Vector2(paddlePos.x,
            paddlePos.y + distBallToPaddle.y);
        transform.position = ballPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velVariance = new Vector2(
            Random.Range(0, randomVelFactor),
            Random.Range(0, randomVelFactor));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody.velocity += velVariance;
        }
    }
}
