using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class TogglePixelPerfect : MonoBehaviour
{
    private PixelPerfectCamera perfectCamera;

    // Start is called before the first frame update
    void Start()
    {
        perfectCamera = GetComponent<PixelPerfectCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        // Toggle pixel perfect camera
        if (Input.GetKeyDown(KeyCode.P))
        {
            perfectCamera.enabled = !perfectCamera.enabled;
            Debug.Log("Pixel Perfect Camera: " + perfectCamera.enabled);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
