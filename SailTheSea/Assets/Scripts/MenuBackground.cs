using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBackground : MonoBehaviour
{
    [Range(-1f, 1f)]
    public float scrollSpeed = 0.5f;
    private float offset;
    private RawImage backgroundImage;

    // Start is called before the first frame update
    void Start()
    {
        backgroundImage = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        offset += (Time.deltaTime * scrollSpeed) / 10f;
        backgroundImage.uvRect = new Rect(offset, 0, 1, 1);
    }
}