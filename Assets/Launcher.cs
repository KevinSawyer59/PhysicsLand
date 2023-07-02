using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] float initialAngle, initialVelocity, currentGravity, initialDrag;
    public GameObject baseballPrefab;
    [SerializeField] Transform aimer;

    public string SetAngle(float i)
    {
        initialAngle += i;
        if (initialAngle > 90)
        {
            initialAngle = 90;
        }
        else if (initialAngle < 0)
        {
            initialAngle = 0;
        }

        aimer.rotation = Quaternion.Euler( new Vector3(-initialAngle, 0, 0));

        return "Initial Angle: " + initialAngle.ToString() + "°";
    }

    public string SetAngleHard(float i)
    {
        initialAngle = i;
        if (initialAngle > 90)
        {
            initialAngle = 90;
        }
        else if (initialAngle < 0)
        {
            initialAngle = 0;
        }

        aimer.rotation = Quaternion.Euler(new Vector3(-initialAngle, 0, 0));

        return "Initial Angle: " + initialAngle.ToString() + "°";
    }

    public string SetVelocity(float i)
    {
        initialVelocity += i;
        if (initialVelocity > 999)
        {
            initialVelocity = 999;
        }
        else if (initialVelocity < 0.1)
        {
            initialVelocity = 0.1f;
        }

        return "Initial Velocity: " + initialVelocity.ToString() + "m/s";
    }

    public string SetVelocityHard(float i)
    {
        initialVelocity = i;
        if (initialVelocity > 999)
        {
            initialVelocity = 999;
        }
        else if (initialVelocity < 0.1)
        {
            initialVelocity = 0.1f;
        }

        return "Initial Velocity: " + initialVelocity.ToString() + "m/s";
    }

    public string SetGravity(float i)
    {
        currentGravity += i;
        if (currentGravity > 999f)
        {
            currentGravity = 999f;
        }
        else if (currentGravity < -999f)
        {
            currentGravity = -999f;
        }

        Physics.gravity = new Vector3(0, currentGravity,0);

        return "Gravity: " + currentGravity.ToString() + "m/s²";
    }

    public string SetGravityHard(float i)
    {
        currentGravity = i;
        if (currentGravity > 999f)
        {
            currentGravity = 999f;
        }
        else if (currentGravity < -999f)
        {
            currentGravity = -999f;
        }

        Physics.gravity = new Vector3(0, currentGravity, 0);

        return "Gravity: " + currentGravity.ToString() + "m/s²";
    }

    public void LaunchProjectile()
    {
        GameObject ball = Instantiate(baseballPrefab) as GameObject;
        ball.transform.position = aimer.transform.position;

        ball.GetComponent<Rigidbody>().AddForce( initialVelocity * aimer.transform.forward,ForceMode.VelocityChange);
    }

    private void Start()
    {
        currentGravity = Physics.gravity.y;
    }
}
