using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    public FloatingJoystick rightJoystick;
    public GameObject pistolBullet;

    public Vector2 direction;

    private bool firing;

    void Start()
    {
        firing = false;

        pistolBullet = Resources.Load("PistolBullet") as GameObject;

        rightJoystick = GameObject.Find("RightJoystick").GetComponent<FloatingJoystick>();

        direction = new Vector3(1, 0, 0);
    }

    void Update()
    {
        //Vector3 mousePos = Input.mousePosition;
        //mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        //Vector2 direction = new Vector2(mousePos.x - playerPos.x, mousePos.y - playerPos.y);
        //direction = direction.normalized;

        //transform.SetPositionAndRotation(playerPos + direction * 8, Quaternion.identity);
        //transform.up = direction;

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Instantiate(pistolBullet, transform.position, Quaternion.identity);
        //}

        if (System.Math.Abs(rightJoystick.Direction.x) < 0.001 && System.Math.Abs(rightJoystick.Direction.y) < 0.001)
        {
            
        }
        else
        {
            direction = rightJoystick.Direction.normalized;
        }

        transform.SetPositionAndRotation(playerPos + direction * 8, Quaternion.identity);
        transform.up = direction;

        //if (Input.GetTouch)
        //{
        //    Instantiate(pistolBullet, transform.position, Quaternion.identity);
        //}

        for (int i = 0; i < Input.touchCount; ++i)
        {
            Debug.Log(Input.GetTouch(i));
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Instantiate(pistolBullet, transform.position, Quaternion.identity);
            }
        }

    }

}
