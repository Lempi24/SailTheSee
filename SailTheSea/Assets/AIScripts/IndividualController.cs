using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class IndividualController : MonoBehaviour
{
    //Pocz¹tkowa pozycja i rotacja obiektu
    private Vector2 startPosition, startRotation;

    public int NumberOfTries = 1;
    Rigidbody2D rb;

    [Range(-1f, 1f)]
    public float up, turn;

    public float timeSinceStart = 0f;

    //Jak dobrze idzie AI
    [Header("Fitness")]
    public float overallFitness;
    public float avgTimeMultiplier = 1.4f;
    public float sensorMultiplier = 0.1f;

    private Vector2 lastPosition;
    private float totalTimeSurvived;

    //Dystans do Obstacles
    private float aSensor, bSensor, cSensor;

    private void Awake()
    {
        startPosition = transform.position;
    }

    public void Reset()
    {
        //Jesli AI umrze to restart
        timeSinceStart = 0f;
        totalTimeSurvived = 0f;
        lastPosition = startPosition;
        overallFitness = 0f ;
        transform.position = startPosition;
        NumberOfTries++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Reset();
        }
    }

    private void FixedUpdate()
    {
        InputSensors();
        lastPosition = transform.position;

        BoatMove(turn, up);
        timeSinceStart += Time.deltaTime;
        CalculateFitness();

    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void CalculateFitness()
    {
        totalTimeSurvived += Time.deltaTime;
        overallFitness = (totalTimeSurvived * avgTimeMultiplier)+(((aSensor+bSensor+cSensor)/3)*sensorMultiplier);

        if(timeSinceStart > 8f && overallFitness < 40f)
        {
            Reset();
        }
        if(overallFitness >= 1000f)
        {
            Reset();
        }
    }

    private void InputSensors()
    {
        Vector2 w = (transform.up);
        Vector2 d = (transform.up - transform.right);
        Vector2 a = (-transform.right);
        Vector2 s = (-transform.up);

        Ray r = new Ray(transform.position, w);
        RaycastHit hit;

        if (Physics.Raycast(r, out hit) )
        {
            aSensor = hit.distance / 5f;
            Debug.DrawLine(r.origin, hit.point, Color.red);
            print("A: " + aSensor);
        }
        r.direction = d;

        if(Physics.Raycast(r,out hit) )
        {
            bSensor = hit.distance / 5f;
            Debug.DrawLine(r.origin, hit.point, Color.red);
            print("B: " + bSensor);
        }

        r.direction = a;

        if (Physics.Raycast(r,out hit) )
        {
            cSensor = hit.distance / 5f;
            Debug.DrawLine(r.origin, hit.point, Color.red);
            print("C: " + cSensor);
        }
    }

    private Vector3 inputAI;
    public void BoatMove(float horizontal, float vertical)
    {
        inputAI = new Vector2(horizontal * 0.1f, vertical * 0.1f);
        inputAI = transform.TransformDirection(inputAI);
        transform.position += inputAI;
    }
}
