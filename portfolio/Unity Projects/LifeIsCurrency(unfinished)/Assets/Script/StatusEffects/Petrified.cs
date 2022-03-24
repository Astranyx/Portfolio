using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Petrified : MonoBehaviour
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
        Soundsystem.Petrified = true;
    }

    IEnumerator Dot()
    {
       
        yield return new WaitForSeconds(Delay);

        while (appliedTimes < ApplyDamageNTimes)
        {
            PlayerMovement.moveSpeed /= 2 ;
            yield return new WaitForSeconds(ApplyEveryNSeconds);
            appliedTimes++;
        }
        PlayerMovement.moveSpeed = 5;
        Destroy(this.gameObject);
    }
}

