using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthGlobeMovement : MonoBehaviour
{
    public float xSpeed = 1;
    public float ySpeed = 1;

    private RawImage image;

    // Start is called before the first frame update
    void Start()
    {
        image = transform.Find("Background/Fill/Effect").GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        Rect rect = image.uvRect;
        rect.x -= Time.deltaTime * xSpeed;
        rect.y -= Time.deltaTime * ySpeed;

        if (rect.x <= -1f || rect.x >= 1f)
        {
            rect.x = 0f;
        }

        if (rect.y <= -1f || rect.y >= 1f)
        {
            rect.y = 0f;
        }

        image.uvRect = rect;
    }
}
