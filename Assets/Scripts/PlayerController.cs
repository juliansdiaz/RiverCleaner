using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables
    [SerializeField] Rigidbody2D playerRB;
    [SerializeField] Animator playerAnimator;
    [SerializeField] ParticleSystem[] collected_Ps;
    [SerializeField] AudioClip sfx_dropItem;
    [SerializeField] AudioClip sfx_collectItem;
    public float playerSpeed = 3.5f;
    private float hmove;
    private float vmove;
    private bool hasRecyclable;
    private bool hasOrganic;
    private bool hasDangerous;
    Vector3 movement;

    void FixedUpdate()
    {
        PlayerMove(); //Call PlayerMove method
    }

    void Update()
    {
        //Increase player speed if Power Up is collected
        if(PowerUp.playerHasPowerUp == false)
        {
            playerSpeed = 3.5f;
        }
    }

    private void PlayerMove()
    {
        //Get player left/right and up/down input
        hmove = Input.GetAxis("Horizontal");
        vmove = Input.GetAxis("Vertical");

        movement = new Vector3(hmove, vmove, 0f).normalized; //Set movement direction as a Vector

        //Move the player in movement vector according to movement parameters
        playerRB.MovePosition(transform.localPosition + movement * playerSpeed * Time.fixedDeltaTime);
        HandleAnimations();
    }

    private void HandleAnimations()
    {
        //Left movement
        if (hmove < 0)
        {
            playerAnimator.SetBool("WalkingLeft", true);
            playerAnimator.SetBool("WalkingRight", false);
            playerAnimator.SetBool("WalkingUp", false);
            playerAnimator.SetBool("WalkingDown", false);
        }
        //Right movement
        else if (hmove > 0)
        {
            playerAnimator.SetBool("WalkingRight", true);
            playerAnimator.SetBool("WalkingLeft", false);
            playerAnimator.SetBool("WalkingUp", false);
            playerAnimator.SetBool("WalkingDown", false);
        }
        //Up movement
        else if (vmove > 0)
        {
            playerAnimator.SetBool("WalkingUp", true);
            playerAnimator.SetBool("WalkingDown", false);
            playerAnimator.SetBool("WalkingLeft", false);
            playerAnimator.SetBool("WalkingRight", false);
        }
        //Down movement
        else if (vmove < 0)
        {
            playerAnimator.SetBool("WalkingDown", true);
            playerAnimator.SetBool("WalkingUp", false);
            playerAnimator.SetBool("WalkingLeft", false);
            playerAnimator.SetBool("WalkingRight", false);
        }
        //Idle
        else
        {
            playerAnimator.SetBool("WalkingLeft", false);
            playerAnimator.SetBool("WalkingRight", false);
            playerAnimator.SetBool("WalkingUp", false);
            playerAnimator.SetBool("WalkingDown", false);
        }
    }

    //Collect items
    void OnTriggerEnter2D(Collider2D collision)
    {
        //collect recyclable item
        if (collision.CompareTag("Recyclable") && hasRecyclable == false)
        {
            AudioManager.Instance.PlaySFX(sfx_collectItem);
            hasRecyclable = true;
            Destroy(collision.gameObject);
        }
        //Collect organic item
        else if (collision.CompareTag("Organic") && hasOrganic == false)
        {
            AudioManager.Instance.PlaySFX(sfx_collectItem);
            hasOrganic = true;
            Destroy(collision.gameObject);
        }
        //Collect dangerous item
        else if (collision.CompareTag("Dangerous") && hasDangerous == false)
        {
            AudioManager.Instance.PlaySFX(sfx_collectItem);
            hasDangerous = true;
            Destroy(collision.gameObject);
        }
    }

    //Leave items in correct trash can
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Drop recyclable
        if (collision.gameObject.CompareTag("RecyclableCan") && hasRecyclable == true)
        {
            collected_Ps[0].Play();
            Debug.Log("Dropped recyclable!");
            AudioManager.Instance.PlaySFX(sfx_dropItem);
            ScoreManager.Instance.contaminationLvl -= 5.0f;
            hasRecyclable = false;
        }
        //Drop organic
        else if (collision.gameObject.CompareTag("OrganicCan") && hasOrganic == true)
        {
            collected_Ps[1].Play();
            Debug.Log("Dropped Organic!");
            AudioManager.Instance.PlaySFX(sfx_dropItem);
            ScoreManager.Instance.contaminationLvl -= 10.0f;
            hasOrganic = false;
        }
        //Drop dangerous
        else if (collision.gameObject.CompareTag("DangerousCan") && hasDangerous == true)
        {
            collected_Ps[2].Play();
            Debug.Log("Dropped Dangerous!");
            AudioManager.Instance.PlaySFX(sfx_dropItem);
            ScoreManager.Instance.contaminationLvl -= 15.0f;
            hasDangerous = false;
        }

        //CollectPowerUp
        if (collision.gameObject.CompareTag("Booster") && PowerUp.playerHasPowerUp == false)
        {
            AudioManager.Instance.PlaySFX(sfx_collectItem);
            PowerUp.playerHasPowerUp = true;
            Destroy(collision.gameObject);
            playerSpeed += 2.0f;
        }
    }
}
