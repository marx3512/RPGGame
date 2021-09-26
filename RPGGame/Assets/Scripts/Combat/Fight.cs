using UnityEngine;
using RPG.Movement;

namespace RPG.Combat
{
    public class Fight : MonoBehaviour
    {   
        [SerializeField] private float weaponRange = 2f;

        Transform target;

        private void Update() {
            if(target == null) return;
            bool isInrange = Vector3.Distance(transform.position,target.position) < weaponRange;
            if( target != null && !isInrange ) GetComponent<Move>().MoveTo(target.position);
            else {
                GetComponent<Move>().Stop();
                Debug.Log("Stop");
            }
        }

        public void Attack(CombatTarget combatTarget){
            target = combatTarget.transform;
        }
    }    
}
