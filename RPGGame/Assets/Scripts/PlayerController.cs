﻿using UnityEngine;
using RPG.Movement;
using RPG.Combat;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        private void Update()
        {
            if(InteractWithTarget()) return;
            if(InteractWithMovement()) return;
            //Debug.Log("Nothing to do");
        }

        private bool InteractWithTarget()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits){
                CombatTarget target = hit.transform.GetComponent<CombatTarget>(); 
                if (target == null) continue;

                if(Input.GetMouseButtonDown(0)) GetComponent<Fight>().Attack(target);
                return true;
                
            }
            return false;
        }

        private bool InteractWithMovement()
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
            if (hasHit) {
                if(Input.GetMouseButton(0)) GetComponent<Move>().MoveTo(hit.point);
                return true;
            }
            return false;
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}
