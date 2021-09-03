﻿using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    private void Update() {
        if(Input.GetMouseButtonDown(0)) MoveToCursor();
        UpdateAnimator();
    }

    void MoveToCursor(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray,out hit);
        if(hasHit) this.GetComponent<NavMeshAgent>().destination = hit.point;
    }

    private void UpdateAnimator(){
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        GetComponent<Animator>().SetFloat("Velocity",speed);
    }
}
