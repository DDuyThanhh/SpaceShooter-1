using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] LazerGun[] laser;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            foreach (LazerGun l in laser)
            {
                //Vector3 pos = transform.position + (transform.forward * l.Distance);
                l.FireLazer();
            }
        }
    }
}
