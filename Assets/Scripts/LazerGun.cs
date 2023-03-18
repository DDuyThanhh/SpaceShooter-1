using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(Light))]
public class LazerGun : MonoBehaviour
{
    [SerializeField] float laerOffTime;
    [SerializeField] float maxDistance;
    [SerializeField] float fireDelay;

    Light lightLazer;
    LineRenderer lazer;

    bool canFire;

    private void Awake()
    {
        lightLazer = GetComponent<Light>();
        lazer = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        lazer.enabled = false;
        lightLazer.enabled = false;
        canFire = true;
    }

    Vector3 CastRay()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward) * maxDistance;
        if(Physics.Raycast(transform.position, fwd, out hit))
        {
            SpawnExplosion(hit.point, hit.transform);
            if (hit.transform.CompareTag("Pickup"))
                hit.transform.GetComponent<Pickup>().PickupHit();

            return hit.point;
        }

        return transform.position + (transform.forward * maxDistance);
    }

    void SpawnExplosion(Vector3 hitPosition, Transform target)
    {
        Explosion temp = target.GetComponent<Explosion>();
        if (temp != null)
        {
            temp.AddForce(hitPosition, transform);
        }
    }

    public void FireLazer()
    {
        Vector3 pos = CastRay();
        FireLaser(pos);

    }

    public void FireLaser(Vector3 targetPosition, Transform target = null)
    {
        if (canFire)
        {
            if(target != null)
            {
                SpawnExplosion(targetPosition, target);
            }
            lazer.SetPosition(0, transform.position);
            lazer.SetPosition(1, CastRay());
            lazer.enabled = true;
            lightLazer.enabled = true;
            canFire = false;
            Invoke("TurnOffLazer", laerOffTime);
            Invoke("CanFire", fireDelay);
        }
    }

    void TurnOffLazer()
    {
        lazer.enabled = false;
        lightLazer.enabled = false;
    }

    public float Distance
    {
        get { return maxDistance; }
    }

    void CanFire()
    {
        canFire = true;
    }
}
