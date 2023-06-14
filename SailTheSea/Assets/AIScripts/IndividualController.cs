using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(NeuronNet))]

public class IndividualController : MonoBehaviour
{
    //Pocz¹tkowa pozycja i rotacja obiektu
    private Vector2 startPosition, startRotation;
    private NeuronNet network;
    public int NumberOfTries = 1;

    [Range(-1f, 1f)]
    public float up;
    [Range(-1f, 1f)]
    public float turn;

    public float timeSinceStart = 0f;

    //Jak dobrze idzie AI
    [Header("Fitness")]
    public float overallFitness;
    public float avgTimeMultiplier = 0.9f;
    public float sensorMultiplier = 1.2f;

    [Header("NetworkOptions")]
    public int Layers = 2;
    public int Neurons = 15;

    private Vector2 lastPosition;
    private float totalTimeSurvived;

    //Dystans do Obstacles
    private float aSensor, bSensor, cSensor, dSensor, eSensor;

    private ObstacleSpawnerAI obstacleSpawner;

    private void Start()
    {
        obstacleSpawner = FindObjectOfType<ObstacleSpawnerAI>();
    }

    private void Awake()
    {
        startPosition = transform.position;
        network = GetComponent<NeuronNet>();
    }

    public void Reset()
    {
        //Jesli AI umrze to restart
        timeSinceStart = 0f;
        totalTimeSurvived = 0f;
        lastPosition = startPosition;
        overallFitness = 0f;
        transform.position = startPosition;
        NumberOfTries++;

        //Test Code
        network.Initialise(Layers, Neurons);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Reset();
            obstacleSpawner.ResetSpawner();
        }
    }

    private void FixedUpdate()
    {
        InputSensors();
        lastPosition = transform.position;

        (turn, up) = network.RunNetwork(aSensor, bSensor, cSensor, dSensor, eSensor);

        BoatMove(turn, up);
        timeSinceStart += Time.deltaTime;
        CalculateFitness();

    }

    private void CalculateFitness()
    {
        totalTimeSurvived += Time.deltaTime;
        overallFitness = (totalTimeSurvived * avgTimeMultiplier)+((((2*aSensor)+bSensor+cSensor+dSensor+eSensor)/6)*sensorMultiplier);

        if(timeSinceStart > 30f && overallFitness < 40f)
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
        Vector2 a = transform.up;
        Vector2 b = transform.up - transform.right;
        Vector2 c = -transform.right;
        Vector2 d = transform.right + transform.up;
        Vector2 e = transform.right;

        //Pobranie maski warstwy przeszkód które ma wykrywaæ raycast
        LayerMask obstacleLayerMask = LayerMask.GetMask("Obstacles");
        RaycastHit2D hit;

        //Tworzenie lini raycastu zaczynaj¹c od pozycji statku lec¹c w nieskoñczonoœæ "Mathf.Infinity" a¿ do obiektu z mask¹ raycast lub wypadniêcia poza ekran gry
        hit = Physics2D.Raycast(transform.position, a, Mathf.Infinity, obstacleLayerMask);
        if (hit.collider != null)
        {
            aSensor = hit.distance / 20f;
            Debug.DrawLine(transform.position, hit.point, Color.red);

        }

        hit = Physics2D.Raycast(transform.position, b, Mathf.Infinity, obstacleLayerMask);
        if (hit.collider != null)
        {
            bSensor = hit.distance / 20f;
            Debug.DrawLine(transform.position, hit.point, Color.red);

        }

        hit = Physics2D.Raycast(transform.position, c, Mathf.Infinity, obstacleLayerMask);
        if (hit.collider != null)
        {
            cSensor = hit.distance / 20f;
            Debug.DrawLine(transform.position, hit.point, Color.red);

        }

        hit = Physics2D.Raycast(transform.position, d, Mathf.Infinity, obstacleLayerMask);
        if (hit.collider != null)
        {
            dSensor = hit.distance / 20f;
            Debug.DrawLine(transform.position, hit.point, Color.red);

        }

        hit = Physics2D.Raycast(transform.position, e, Mathf.Infinity, obstacleLayerMask);
        if (hit.collider != null)
        {
            eSensor = hit.distance / 20f;
            Debug.DrawLine(transform.position, hit.point, Color.red);

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
