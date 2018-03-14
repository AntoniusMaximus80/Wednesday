using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//    - Should expose variables:
//    - AgentController

namespace Flocking {
    public class Agent : MonoBehaviour
    {
        public AgentController _agentController { set; get; }

        private Transform _currentTransform;

        // Use this for initialization
        void Start() {

        }

        //Update()
        //- Store Current Position and Current rotation
        //- Velocity = Controller.Velocity
        //- Create 3 vectors:
        //    - separation = vector3.zero
        //    - alignment = controller's forward vector
        //    - cohesion = controller's Position
        //- Look for agents:
        //    - Physics.OverlapSphere(currentPosition, Neighbour Distance, Physics Layer to Search);
        //    - For each agent:
        //        - separation += GetSeparationVector(agent.transform)
        //        - alignment += agent's forward vector
        //        - cohesion += agent's position
        //- float average = 1.0f / number of agents found by the Physics.OverlapSphere check previously
        //- alignment *= avgerage
        //- cohesion *= average
        //- cohesion = (cohesion - currentPosition).normalized;
        //}


        void Update() {
            _currentTransform = transform;

            Vector3 seperation = Vector3.zero;
            Vector3 alignment = _agentController.transform.forward;
            Vector3 cohesion = _agentController.transform.position;

            Collider[] agentColliders = Physics.OverlapSphere(transform.position,
                _agentController._spawnRadius, _agentController._physicsLayer);

            foreach(Collider collider in agentColliders)
            {
                if (collider == GetComponent<Collider>()) continue;
                seperation += GetSeperationVector(collider.transform);
                alignment += collider.transform.forward;
                cohesion += collider.transform.position;
            }

            float average = 1f / agentColliders.Length;

            alignment *= average;
            cohesion *= average;
            cohesion = (cohesion - _currentTransform.position).normalized;

            //- new direction = separation + alignment + cohesion;
            Vector3 newDirection = seperation + alignment + cohesion;

            //- new rotation = Quaternion.FromToRotation(Vector3.forward, direction.normalized);
            Quaternion newRotation = Quaternion.FromToRotation(Vector3.forward, newDirection.normalized);

            //- if (rotation != currentRotation) {
            //    transform.rotation = Quaternion.Slerp(rotation, currentRotation, Mathf.Exp(-4.0f * Time.deltaTime));
            if (newRotation != _currentTransform.rotation)
            {
                transform.rotation = Quaternion.Slerp(newRotation, _currentTransform.rotation, Mathf.Exp(-12.0f * Time.deltaTime));
            }

            //- new Agent position = currentPosition + transform forward* (Velocity* Time.deltaTime);
            transform.position = _currentTransform.position + transform.forward * (_agentController._agentSpeed * Time.deltaTime);
        }

        //Vector3 GetSeparationVector(Transform target)
        //        {
        //            var diff = transform.position - target.transform.position;
        //            var diffLen = diff.magnitude;
        //            var scaler = Mathf.Clamp01(1.0f - diffLen / controller.neighborDist);
        //            return diff * (scaler / diffLen);
        //        }

        //        Start()
        //- Empty

        private Vector3 GetSeperationVector(Transform target)
        {
            var diff = transform.position - target.transform.position;
            var diffLen = diff.magnitude;
            var scaler = Mathf.Clamp01(1.0f - diffLen / _agentController._spawnRadius);
            return diff * (scaler / diffLen);
        }
    }
}