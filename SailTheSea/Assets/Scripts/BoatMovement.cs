using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Rigidbody2D rb;
    public Animator animator;

    //Shield
    [SerializeField]
    private GameObject shield;
    private bool canActivateShield = true;
    public bool isShieldActive = false;
    private float shieldDuration = 5f;
    private float shieldCooldown = 6f;

    
    //Dashing
    private bool canDash = true;
    private bool isDashing;
    private float dashingTime = 0.5f;
    private float dashingCooldown = 10f;

    [SerializeField] private TrailRenderer tr;

    Vector2 movement; 
   
    void Update()
    {
        CheckShield(); 

        if (isDashing) 
        {
            return;
        }
        
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

       
        if(!PauseMenu.isPaused)
        {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.magnitude);
        }
        
        if(!PauseMenu.isPaused)
        {
        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash == true)
        {
            StartCoroutine(Dash());
        }
    }
    }
            
           private void CheckShield()
    {
        
        if(!PauseMenu.isPaused)
        {
        if (Input.GetKey(KeyCode.R) && canActivateShield && !isShieldActive)
        {
            StartCoroutine(ActivateShield());
        }
    }
    }

    private IEnumerator ActivateShield()
    {
        canActivateShield = false;
        shield.SetActive(true);
        isShieldActive = true;

        yield return new WaitForSeconds(shieldDuration);

        shield.SetActive(false);
        isShieldActive = false;

        yield return new WaitForSeconds(shieldCooldown);
        canActivateShield = true;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        moveSpeed = 4f;
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        moveSpeed = 2f;
        rb.gravityScale = originalGravity;
        isDashing = false;
        tr.emitting = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    } 
}
