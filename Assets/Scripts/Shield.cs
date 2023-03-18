using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] int maxHealt;
    [SerializeField] int curHealt;
    [SerializeField] int regenerateAmount;
    [SerializeField] float regenerationRate;

    private void Start()
    {
        curHealt = maxHealt;

        InvokeRepeating("Regenerate", regenerationRate, regenerationRate);
    }

    void Regenerate()
    {
        if (curHealt < maxHealt)
            curHealt += regenerateAmount;

        if (curHealt > maxHealt)
            curHealt = maxHealt;

        EventManager.TakeDamage(curHealt / (float)maxHealt);
    }

    public void TakeDamage(int dmg = 1)
    {
        curHealt -= dmg;

        if (curHealt < 0)
            curHealt = 0;

        EventManager.TakeDamage(curHealt / (float)maxHealt);

        if(curHealt < 1)
        {
            EventManager.PlayerDeath();
            GetComponent<Explosion>().BlowUp();
        }
    }
}
