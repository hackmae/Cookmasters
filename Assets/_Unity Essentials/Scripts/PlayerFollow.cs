using UnityEngine;
public class PlayerFollow : MonoBehaviour
{
    public Transform playerPos;
    UnityEngine.AI.NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    void Update()
    {
        agent.SetDestination(playerPos.position);
    }
}