using UnityEngine;

public class BallMenu : MonoBehaviour
{
    //SerializedFileds
    [SerializeField] Paddle paddle1;
    [SerializeField] float velX = 0f, velY = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomVelFactor = 0.0f;

    //Variables
    Vector2 distBallToPaddle;
    bool hasStarted = false;


    //Cached Components
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody = GetComponent<Rigidbody2D>();
        myRigidBody.velocity = new Vector2(velX, velY);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioClip clip = ballSounds[0];
        myAudioSource.PlayOneShot(clip);


    }
}
