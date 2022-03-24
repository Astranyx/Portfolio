using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private float mouseSens, cameraX, cameraY;

    public Vector3 rotation { get; private set; }
    public GameObject nukeOrb;
    public GameObject petrifyOrb;
    GameObject currentOrb;
    GameObject nukeCurrent;
    GameObject[] enemies;

    public static bool canDet;
    public static bool canPet;
    public static bool canBlnk;

    int nukeMult;
    public static int nukeDamage;

    void Start()
    {
        mouseSens = 1;
        nukeMult = 0;
        canDet = true;
        canBlnk = true;
        canPet = true;

    }

    void Update()
    {
        if (PauseMenu.gameOn)
        {
            cameraX += mouseSens * Input.GetAxis("Mouse X");
            cameraY -= mouseSens * Input.GetAxis("Mouse Y");
            cameraY = cameraY < -90 ? -90 : cameraY;
            cameraY = cameraY > 90 ? 90 : cameraY;

            rotation = new Vector3(0, cameraX, 0);

            Debug.DrawRay(transform.position, transform.rotation * Vector3.forward * 15f);

            transform.eulerAngles = new Vector3(cameraY, cameraX, 0);
        
            if (Input.GetKeyDown(KeyCode.Alpha1) && PlayerStats.currentCharge >= 0 && PlayerStats.canBlink && canBlnk)
            {
                
                RaycastHit hitB;
                
                if(Physics.Raycast(transform.position, transform.rotation * Vector3.forward * 20f, out hitB, 15f))
                {
                    canBlnk = false;
                    transform.parent.position = hitB.point + new Vector3(0f, 2f, 0f);
                    StartCoroutine("resetBlnk");
                    PlayerStats.currentCharge -= 1;
                }                
            }

            if(Input.GetKeyDown(KeyCode.Alpha2) && PlayerStats.currentCharge >= 2 && PlayerStats.canPetrify && canPet)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.rotation * Vector3.forward * 20f, out hit, 30f))
                {
                    canPet = false;
                    currentOrb = Instantiate(petrifyOrb, hit.point, transform.rotation);
                    StartCoroutine("removePetrify");
                    PlayerStats.currentCharge -= 3;
                }
            }

            if(Input.GetKeyDown(KeyCode.Alpha3) && PlayerStats.currentCharge >= 0 && PlayerStats.canNuke && canDet)
            {
                canDet = false;
                nukeCurrent = Instantiate(nukeOrb, transform.position, transform.rotation);                
                StartCoroutine("nukeremoval");
                nukeMult = PlayerStats.currentCharge;
                nukeDamage = nukeMult * 3;
                PlayerStats.currentCharge -= PlayerStats.currentCharge;
                Soundsystem.nukecola = true;
            }
        }

        nukeCurrent.transform.localScale += new Vector3(15f, 15f, 15f) * Time.deltaTime;
    }

    IEnumerator nukeremoval()
    {
        yield return new WaitForSeconds(3f);
        Destroy(nukeCurrent.gameObject);        
        yield return new WaitForSeconds(50f);
        canDet = true;
    }

    IEnumerator removePetrify()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(currentOrb.gameObject);
        yield return new WaitForSeconds(3f);
        canPet = true;
    }

    IEnumerator resetBlnk()
    {
        yield return new WaitForSeconds(1f);
        canBlnk = true;
    }
}