using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float turnSpeed;
    [SerializeField] float pitchSpeed;
    [SerializeField] float rollSpeed;
    public Thruster[] thurster;
    Transform trans;

    private void Awake()
    {
        trans = GetComponent<Transform>();
    }

    void Update()
    {
        Turn();
        Move();
    }

    void Turn()
    {
        float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float pitch = pitchSpeed * Time.deltaTime * Input.GetAxis("Pitch");
        float roll = rollSpeed * Time.deltaTime * Input.GetAxis("Roll");
        trans.Rotate(pitch, yaw, -roll);
    }

    void Move()
    {

        if (Input.GetAxis("Vertical") > 0)
        {
            trans.position += trans.forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");
            foreach (Thruster t in thurster)
            {
                t.Activeta();

                t.Intensity(1f);
            }
        }
        else
        {
            foreach (Thruster t in thurster)
                t.Activeta(false);
        }
    }
}
