using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleController : MonoBehaviour
{
    Vector3 groundLevel;
    Vector3 undergroundLevel;
    public GameObject effect;

    bool isOnGround = true;
    float time = 0;


    void Up()
    {
        transform.position = groundLevel;
        this.isOnGround = true;
    }

    void Down()
    {
        transform.position = this.undergroundLevel;
        this.isOnGround = false;
    }

    void Start()
    {
        this.groundLevel = transform.position;
        this.undergroundLevel = this.groundLevel - new Vector3(0, 0.2f, 0);

        Down();
    }

    void Update()
    {
        this.time += Time.deltaTime;

        if (this.time > 2.0f)
        {
            this.time = 0;
            if (this.isOnGround)
            {
                Down();
            }
            else
            {
                Up();
            }
        }
    }

    public void Hit()
    {
        this.time = 0;
        Down();
    }

}
