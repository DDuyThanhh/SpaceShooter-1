using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Explosion : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject blowUp;
    [SerializeField] Rigidbody rigid;
    [SerializeField] Shield shield;
    [SerializeField] float laserHit;

    void IveBeenHit(Vector3 pos)
    {
        GameObject go = Instantiate(explosion, pos, Quaternion.identity, transform) as GameObject;
        Destroy(go, 3f);

        if (shield == null)
            return;

        shield.TakeDamage();
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach(ContactPoint contact in collision.contacts)
        {
            IveBeenHit(contact.point);
        }
    }

    public void AddForce(Vector3 hitPosition, Transform hitSource)
    {
        IveBeenHit(hitPosition);
        if (rigid == null)
            return;

        Vector3 forceVector = (hitSource.position - hitPosition).normalized;
        rigid.AddForceAtPosition(forceVector.normalized * laserHit, hitPosition, ForceMode.Impulse);
    }

    public void BlowUp()
    {
        GameObject temp =  Instantiate(blowUp, transform.position, Quaternion.identity) as GameObject;
        Destroy(temp, 1f);
        Destroy(gameObject);
    }
}
