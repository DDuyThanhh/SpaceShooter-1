using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 defaultDistance = new Vector3(0f, 2f, -10f);
    [SerializeField] float distanceDamp = 10f;

    public Vector3 velocity = Vector3.one;
    Transform trans;

    private void Awake()
    {
        trans = GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        if (!FindTarget())
            return;

        SmoothFollow();
    }

    void SmoothFollow()
    {
        if(target == null) return;

        Vector3 toPos = target.position + (target.rotation * defaultDistance);
        Vector3 curPos = Vector3.SmoothDamp(trans.position, toPos, ref velocity, distanceDamp);
        trans.position = curPos;

        trans.LookAt(target, target.up);
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
