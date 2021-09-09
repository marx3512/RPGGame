using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    private void Update() {
        
        UpdateAnimator();
    }

    

    public void MoveTo(Vector3 destination)
    {
        this.GetComponent<NavMeshAgent>().destination = destination;
    }

    private void UpdateAnimator(){
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        GetComponent<Animator>().SetFloat("Velocity",speed);
    }
}
