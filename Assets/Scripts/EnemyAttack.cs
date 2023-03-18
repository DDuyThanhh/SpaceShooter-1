using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] LazerGun laser;
    Vector3 hitPosition;

    private void Update()
    {
        if (!FindTarget())
            return;

        Infront();
        HaveLineOfSightRayCast();
        if (Infront() && HaveLineOfSightRayCast())
        {
            FireLaser();
        }
    }

    bool Infront()
    {
        Vector3 directionToTarget = transform.position - target.position;
        float angle = Vector3.Angle(transform.forward, directionToTarget);

        if (Mathf.Abs(angle) > 90 && Mathf.Abs(angle) < 270)
        {
            //Debug.DrawLine(transform.position, target.position, Color.red);
            return true;
        }
        //Debug.DrawLine(transform.position, target.position, Color.blue);
        return false;
    }

    bool HaveLineOfSightRayCast()
    {
        RaycastHit hit;
        Vector3 direction = target.position - laser.transform.position;
        if (Physics.Raycast(laser.transform.position, direction, out hit, laser.Distance))
        {
            if (hit.collider != null)
            {
                Debug.DrawRay(laser.transform.position, direction, Color.green);
                hitPosition = hit.point;
                return true;
            }
        }
        return false;
    }

    void FireLaser()
    {
        laser.FireLaser(hitPosition, target);
    }

    bool FindTarget()
    {
        if (target == null)
        {
            GameObject temp = GameObject.FindGameObjectWithTag("Player");
            if (temp != null)
            {
                target = temp.transform;
            }
        }

        if (target == null)
            return false;

        return true;
    }
}