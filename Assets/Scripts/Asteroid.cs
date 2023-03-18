using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Explosion))]
public class Asteroid : MonoBehaviour
{
    [SerializeField] float minSize;
    [SerializeField] float maxSize;
    [SerializeField] float rotationOffset = 100f;

    public static float destructionDelay = 1.0f;

    Transform trans;
    Vector3 randomRotation;

    private void Awake()
    {
        trans = GetComponent<Transform>();
    }

    private void Start()
    {
        //Random Size
        Vector3 Scale = Vector3.one;
        Scale.x = Random.Range(minSize, maxSize);
        Scale.y = Random.Range(minSize, maxSize);
        Scale.z = Random.Range(minSize, maxSize);

        trans.localScale = Scale;

        //Random Rotation
        randomRotation.x = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.y = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.z = Random.Range(-rotationOffset, rotationOffset);
    }

    void Update()
    {
        trans.Rotate(randomRotation * Time.deltaTime);
    }

    public void SelfDestruct()
    {
        float timer = Random.Range(0, destructionDelay);

        Invoke("GoBoom", timer);
    }

    public void GoBoom()
    {
        GetComponent<Explosion>().BlowUp();
    }
}
