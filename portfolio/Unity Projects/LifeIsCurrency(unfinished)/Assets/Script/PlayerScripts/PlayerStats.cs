using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour {

    public Text currentSoulText;
    public Text chargeCount;
    public Text upgrade;
    public Text shopSouls;
    public Transform cam;

    //Warrior - Damage upgrade
    public static int meleeDamage;

    //Warrior - Cone Size Modifier
    public static float coneSizeMod;

    //Range - Size/Damage
    public static float rangedSize;

    //Range - Attack speed base
    public static float attackRate;

    //Range - Attack speed modifier
    public static float rateMod;

    //Range - Range Distance
    public static float rangeDist;

    //Player - Current soul count
    public static int soulCount;

    //Player - Soul Gained modifier
    public static int soulMod;

    //Charge - Maximum
    public static int chargeTotal;

    //Charge - Charge Rate Modifier
    public static float chargeMod;

    //Ability Unlock
    public static bool canBlink;
    public static bool canPetrify;
    public static bool canNuke;

    //Charge - Current amount of charge
    public static int currentCharge;

    //Amount of ranged damage inflicted
    public static int rangedDamage;

    //Cone Attack Prefab and variable for instantiation
    public GameObject coneAttack;
    GameObject Cone;

    //Ranged Attack
    public GameObject rangedAttack;
    GameObject Ranged;

    //check if can Attack
    bool canAttack;

    float addTimer;

	// Use this for initialization
	void Start ()
    {
        //Set Default valueas
        meleeDamage = 2;
        rangedSize = 30f;
        attackRate = 2.5f;
        rangeDist = 0.5f;
        rateMod = 0f;
        coneSizeMod = 140f;
        soulMod = 0;
        soulCount = 60;

        Time.timeScale = 1;
        PauseMenu.gameOn = true;

        canBlink = false;
        canPetrify = false;
        canNuke = false;

        chargeTotal = 3;
        currentCharge = 0;
        chargeMod = 0;

        rangedDamage = 2;

        canAttack = true;
        addTimer = 0;

        Cone = null;
        Ranged = null;
	}
	
	// Update is called once per frame
	void Update ()
    {
        cam.rotation = cam.rotation;

        if (PauseMenu.gameOn)
        {
            if (Input.GetButton("Fire1") && canAttack)
            {
                StartCoroutine("AttackRoutine");
            }
        }

        if (soulCount <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("Game Over");
        }

        currentSoulText.text = "Souls \n" + soulCount;
        chargeCount.text = "Charges \n" + currentCharge;
        shopSouls.text = "Current Souls \n" + soulCount;
        upgrade.text = "Upgrade Cost \n" + MenuManager.upPrice;

        addTimer += Time.deltaTime;

        if(addTimer >= 4f + chargeMod)
        {
            if (currentCharge != chargeTotal)
            {
                currentCharge += 1;
            }
            addTimer = 0f;
        }
	}

    IEnumerator AttackRoutine()
    {
        Cone = Instantiate(coneAttack, transform.position, transform.rotation * Quaternion.Euler(new Vector3(0,-90,90)));
        Ranged = Instantiate(rangedAttack, transform.position, cam.rotation * Quaternion.Euler(new Vector3(0, -90, 270)));
        Cone.transform.localScale = new Vector3(10, coneSizeMod, coneSizeMod*1.5f);
        Ranged.transform.localScale = new Vector3(rangedSize, rangedSize, rangedSize);
        StartCoroutine("removeRanged");
        canAttack = false;
        yield return new WaitForSeconds(0.3f);
        Destroy(Cone.gameObject);
        yield return new WaitForSeconds(attackRate - rateMod);
        canAttack = true;        
    }

    IEnumerator removeRanged()
    {
        yield return new WaitForSeconds(rangeDist);
        Destroy(Ranged.gameObject);
    }
}
