using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerController : JMC
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float jumpForce = 10f;
    public float gravityModifier;
    public bool isOnGround = true;
    public Text timerText;

    private bool invinReady = true;   
    private bool isInvincible = false;   
    public float invincibilityLength = 5f;   
    public Text invinText;
    public Text eText;
    public GameObject pausePanel;

    public Text scoreText;

    void Start()
    {
        UnityEngine.Cursor.visible = false;
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        if(!_GM1.gameOver)
        timerText.text = (Time.time.ToString("f2"));

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }

        if(Input.GetKeyDown(KeyCode.E) && invinReady && !_GM1.gameOver)
        {
            StartCoroutine("ActivatePower");
        }

        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !_GM1.gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {        

        if (collision.gameObject.CompareTag("Coin"))
        {
            _GM1.score++;
            Destroy(collision.gameObject);
            scoreText.text = ("Score: " + _GM1.score);
        }

        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            if(isInvincible)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                _GM1.gameOver = true;
                playerAnim.SetBool("Death_b", true);
                playerAnim.SetInteger("DeathType_int", 1);
                explosionParticle.Play();
                dirtParticle.Stop();
                playerAudio.PlayOneShot(crashSound, 1.0f);
            }    
            
        }
    }

    IEnumerator ActivatePower()
    {
        invinReady = false;
        eText.enabled = false;
        isInvincible = true;
        invinText.text = ("You are Invincible!!!");
        yield return new WaitForSeconds(invincibilityLength);
        isInvincible = false;
        invinText.text = ("Recharging.....");
        yield return new WaitForSeconds(invincibilityLength);
        invinReady = true;
        invinText.text = ("Invincibility Ready!");
        eText.enabled = true;
        yield return null;
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        UnityEngine.Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        UnityEngine.Cursor.visible = false;
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Prototype1");
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
