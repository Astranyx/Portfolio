using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firedot : MonoBehaviour
{

    public float Damage { get; set; }
    public float Seconds { get; set; }
    public float Delay { get; set; }
    public float ApplyDamageNTimes { get; set; }
    public float ApplyEveryNSeconds { get; set; }

    private int appliedTimes = 0;

    void Start()
    {
        StartCoroutine(Dot());
    }

    IEnumerator Dot()
    {
        yield return new WaitForSeconds(Delay);

        while (appliedTimes < ApplyDamageNTimes)
        {
            PlayerStats.soulCount -= 1;
            yield return new WaitForSeconds(ApplyEveryNSeconds);
            appliedTimes++;
        }

        Destroy(this);
    }
}

