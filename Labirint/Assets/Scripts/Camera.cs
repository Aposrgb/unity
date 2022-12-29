using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public float mouseSens = 300f;
    public Transform player;
    private float rotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;
        float mX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;

        rotation -= mY;
        rotation = Mathf.Clamp(rotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotation, 0f, 0f);
        player.Rotate(Vector3.up * mX);
    }
}
