using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleRotate : MonoBehaviour
{
    public float speed = 1f;
    public float radius = 1f;

    private Vector3 startPosition;
    private float angle = 0f;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        speed = (2 * Mathf.PI) / speed;
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = startPosition + new Vector3(Mathf.Sin(Time.time * speed), 0, Mathf.Cos(Time.time * speed));
        angle += speed * Time.deltaTime;
        var x = Mathf.Cos(angle) * radius;
        var z = Mathf.Sin(angle) * radius;
        transform.position = startPosition + new Vector3(x, 0, z);
    }
}
