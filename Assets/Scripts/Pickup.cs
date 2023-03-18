using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(CapsuleCollider))]
public class Pickup : MonoBehaviour
{
    Transform trans;
    Vector3 randomRotation;

    [SerializeField] float rotationOffset = 100f;
    static int points = 100;

    bool goHit = false;

    private void Awake()
    {
        trans = transform;
    }

    private void Start()
    {
        randomRotation.x = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.y = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.z = Random.Range(-rotationOffset, rotationOffset);
    }

    private void Update()
    {
        trans.Rotate(randomRotation * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
            if (!goHit)
                PickupHit();
    }

    public void PickupHit()
    {
        if (!goHit)
        {
            goHit = true;
            EventManager.ScorePoints(points);
            EventManager.ReSpawnpickup();
            Destroy(gameObject);
        }
    }
}
