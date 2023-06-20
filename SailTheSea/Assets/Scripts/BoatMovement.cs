using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Rigidbody2D rb;
    public Animator animator;
    private bool canAnimate = false;

    [SerializeField] private AudioSource tarcza;
    [SerializeField] private AudioSource dash;

    // Shield
    [SerializeField]
    private GameObject shield;
    private bool canActivateShield = true;
    public bool isShieldActive = false;
    private float shieldDuration = 5f;
    private float shieldCooldown = 6f;
    // Mruganie tarczy
     [SerializeField]
    private Renderer shieldRenderer;    
    private float shieldBlinkDuration = 2f;
    private float shieldBlinkInterval = 0.15f;
    private Coroutine shieldBlinkCoroutine;
    public bool isShieldBlinking = false;
    
    // Mruganie statku 
    [SerializeField]
    private Renderer shipRenderer;
    private Coroutine shipBlinkCoroutine;
    public bool isShipBlinking = false;


    // Dashing
    private bool canDash = true;
    private bool isDashing;
    private float dashingTime = 0.5f;
    private float dashingCooldown = 10f;

    // Slider
    public Slider dashCooldownSlider;
    private float dashCooldownTimer = 0f;

    public Slider shieldCooldownSlider;
    private float shieldCooldownTimer = 0f;
    private bool isCooldownInProgress = false;
    private float cooldownFillSpeed = 1f;

    [SerializeField] private TrailRenderer tr;

    Vector2 movement;     
    


    void Start()
    {
        dashCooldownSlider.value = 1f;
        shieldCooldownSlider.value = 1f;
        moveSpeed = 2f;
        shieldRenderer = shield.GetComponent<Renderer>();
        shipRenderer = GetComponent<Renderer>();
        canAnimate = false;
        Invoke(nameof(EnableAnimation), 5f);
    }
    void EnableAnimation()
   {
        canAnimate = true;
   }

    void Update()
    {
        if (!canAnimate)
    {
        return;
    }
        CheckShield();

        if (isDashing)
        {
            return;
        }


        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        if (!PauseMenu.isPaused)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.magnitude);
        }

        if (!PauseMenu.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && canDash == true)
            {
                dash.Play();
                dashCooldownTimer = dashingCooldown;
                dashCooldownSlider.value = 0f;
                StartCoroutine(Dash());
            }
        }
        if (dashCooldownTimer > 0f)
        {
            dashCooldownTimer -= Time.deltaTime;
            dashCooldownSlider.value = 1f - (dashCooldownTimer / dashingCooldown);
        }
        if (isCooldownInProgress)
        {
            if (shieldCooldownTimer > 0f)
            {
                shieldCooldownTimer -= Time.deltaTime;
                shieldCooldownSlider.value = shieldCooldownTimer / shieldCooldown;
            }
            else
            {
                isCooldownInProgress = false;
                shieldCooldownTimer = 0f;
                shieldCooldownSlider.value = 0f;
            }
        }
    }

    private void CheckShield()
    {
        if (!PauseMenu.isPaused)
        {
            if (Input.GetKey(KeyCode.R) && canActivateShield && !isShieldActive &&!isShipBlinking)
            {
                tarcza.Play();
                StartCoroutine(ActivateShield());
            }
        }
    }

    private IEnumerator ActivateShield()
    {
        canActivateShield = false;
        shield.SetActive(true);
        isShieldActive = true;
        shieldBlinkCoroutine = StartCoroutine(ShieldBlinkCoroutine());
        

        yield return new WaitForSeconds(shieldDuration);

        shield.SetActive(false);
        isShieldActive = false;

        isCooldownInProgress = true;
        shieldCooldownTimer = shieldCooldown;
        shieldCooldownSlider.value = 0f;

        float timer = 0f;
        while (timer < shieldCooldown)
        {
            timer += Time.deltaTime;
            shieldCooldownSlider.value = timer / shieldCooldown;
            yield return null;
        }

        isCooldownInProgress = false;
        shieldCooldownTimer = 0f;
        shieldCooldownSlider.value = 1f;

        canActivateShield = true;
        if (shieldBlinkCoroutine != null)
        {
            StopCoroutine(shieldBlinkCoroutine);
            shieldRenderer.enabled = true; 
        }
    }
    public void DisableShield()
{
    if (isShieldActive)
    {
        StopCoroutine(ActivateShield());
        shield.SetActive(false);
        isShieldActive = false;
    }
}
 private IEnumerator ShieldBlinkCoroutine()
    {
        isShieldBlinking = true;
        float timer = 0f;

        while (timer < shieldDuration - shieldBlinkDuration)
        {
            yield return null;
            timer += Time.deltaTime;
        }
        
        while (timer < shieldDuration)
        {
            shieldRenderer.enabled = !shieldRenderer.enabled;
            yield return new WaitForSeconds(shieldBlinkInterval);
            timer += shieldBlinkInterval;
        }
        shieldRenderer.enabled = true;
        isShieldBlinking = false;
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
    public IEnumerator StartShipBlinkCoroutine()
{
    yield return StartCoroutine(ShipBlinkCoroutine());
}

private IEnumerator ShipBlinkCoroutine()
{
    isShipBlinking = true;
    float timer = 0f;

    while (timer < 3f)
    {
        shipRenderer.enabled = !shipRenderer.enabled;
        yield return new WaitForSeconds(0.2f);
        timer += 0.2f;
    }

    shipRenderer.enabled = true;
    isShipBlinking = false;
}
}
