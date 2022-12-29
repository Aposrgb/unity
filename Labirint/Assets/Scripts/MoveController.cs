using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEngine.XR.Interaction.Toolkit.InputHelpers;

public class MoveController : MonoBehaviour
{
    public static MoveController controller;
    public float speed = 4;
    public CharacterController characterController;
    Vector3 move;
    private Vector3 originalCenter;
    private float originalHeight;
    public Camera camera;
    private Vector3 cameraPos;
    bool crouching = false;
    bool sprint = false;
    bool jump = false;
    public float jumpAmount = 35;
    public float MaxDistance = 5;
    public GameObject button1;
    bool isClick1 = false;
    public GameObject button2;
    public GameObject button3;
    public float gravity = 1;
    bool isClick2 = false;
    bool isClick3 = false;
    public GameObject kopya;
    public GameObject stena;
    public GameObject stena2;
    public GameObject kopya2;
    public GameObject endstena;
    public bool isMoveKey;

    void Start()
    {
        controller = this;
        originalCenter = characterController.center;    
        originalHeight = characterController.height;
        cameraPos = camera.transform.localPosition;
    }

    void Update()
    {
        if (isMoveKey) {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            move = (transform.right * h + transform.forward * v);
            characterController.Move(move * speed * Time.deltaTime);
        }
        if (!Input.GetKey("c") && crouching)
        {
            camera.transform.localPosition = cameraPos;
            characterController.height = originalHeight;
            characterController.center = originalCenter;
            speed = 4;
            crouching = false;
        }
        if (Input.GetKeyDown("c")) 
        {
            camera.transform.localPosition = new Vector3(cameraPos.x, 0.25f, cameraPos.z);
            characterController.height = 0.5f;
            characterController.center = new Vector3(0f, -0.5f, 0f);
            speed = 1.5F;
            crouching = true;
        }
        if (!Input.GetKey(KeyCode.LeftShift) && sprint)
        {
            speed = 4;
            sprint = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && !crouching) {
            speed = 10;
            sprint = true;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {

            RaycastHit hit;

            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, MaxDistance)) {
                if (hit.collider.tag == "button1")
                {
                    Pressed1();
                }
                if (hit.collider.tag == "button2")
                {
                    Pressed2();
                }
                if (hit.collider.tag == "button3")
                {
                    Pressed3();
                }
            }
        }
    }

    public void buttonEvent()
    {
        RaycastHit hit;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, MaxDistance))
        {
            if (hit.collider.tag == "button1")
            {
                Pressed1();
            }
            if (hit.collider.tag == "button2")
            {
                Pressed2();
            }
            if (hit.collider.tag == "button3")
            {
                Pressed3();
            }
        }
    }
    
    void Pressed1()
    {
        Vector3 v = button1.transform.localPosition;
        Vector3 vs = stena.transform.localPosition;
        if (isClick1)
        {
            isClick1 = false;
            stena.transform.localPosition = new Vector3(vs.x, -2.73f);
            button1.transform.localPosition = new Vector3(v.x - 0.04f, v.y, v.z);
        }
        else
        {
            isClick1 = true;
            stena.transform.localPosition = new Vector3(vs.x, -8);
            button1.transform.localPosition = new Vector3(v.x + 0.04f, v.y, v.z);
        }
    }

    void Pressed2()
    {
        Vector3 v = button2.transform.localPosition;
        if (isClick2)
        {
            isClick2 = false;
            kopya.transform.localPosition = new Vector3(kopya.transform.localPosition.x, -7.2f, kopya.transform.localPosition.z);
            button2.transform.localPosition = new Vector3(v.x - 0.04f, v.y, v.z);
        }
        else
        {
            isClick2 = true;
            button2.transform.localPosition = new Vector3(v.x + 0.04f, v.y, v.z);
            kopya.transform.localPosition = new Vector3(kopya.transform.localPosition.x, -9, kopya.transform.localPosition.z);
        }
    }

    void Pressed3()
    {
        Vector3 v = button3.transform.localPosition;
        if (isClick3)
        {
            isClick3 = false;
        }
        else
        {
            isClick3 = true;
            Vector3 vs = stena.transform.localPosition;
            stena.transform.localPosition = new Vector3(vs.x, -8);

            button3.transform.localPosition = new Vector3(2.62f, v.y, v.z);
            v = kopya2.transform.localPosition;
            kopya2.transform.localPosition = new Vector3(v.x, -12.5f, v.z);
            v = stena2.transform.localPosition;
            stena2.transform.localPosition = new Vector3(v.x, -7, v.z);
            v = endstena.transform.localPosition;
            endstena.transform.localPosition = new Vector3(v.x, v.y - 2, v.z);
        }
    }
}
