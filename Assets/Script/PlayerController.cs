using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    public ParticleSystem ParticleSystem;
    public ParticleSystem dirParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    public float jumpForce;
    public float GravityModifier;
    public bool isonGround = true;
    public bool GameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= GravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isonGround && !GameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isonGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isonGround = true;
            dirParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver = true;
            Debug.Log("GameOver!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            ParticleSystem.Play();
            dirParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
























