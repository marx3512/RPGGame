using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    

    Ray lastRay;

    private void Update() {
        

        if(Input.GetMouseButtonDown(0)) MoveToCursor();
        Debug.DrawRay(lastRay.origin, lastRay.direction * 100);
    }

    void MoveToCursor(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray,out hit);
        if(hasHit) this.GetComponent<NavMeshAgent>().destination = hit.point;
    }
}
