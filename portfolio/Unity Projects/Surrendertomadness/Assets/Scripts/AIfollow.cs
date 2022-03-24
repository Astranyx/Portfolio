using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AIfollow : MonoBehaviour
{
    NavMeshAgent aiAgent;
    public Transform player;
	// Use this for initialization
	void Start ()
    {
        aiAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        aiAgent.SetDestination(player.position);
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
