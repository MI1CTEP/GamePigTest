using UnityEngine;
using UnityEngine.AI;

public class StartNavMesh : MonoBehaviour
{ 
    private void Start()
    {
        GetComponent<NavMeshSurface>().BuildNavMesh();
    }
}
