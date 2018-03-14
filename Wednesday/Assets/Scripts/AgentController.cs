using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flocking
{
    public class AgentController : MonoBehaviour
    {
        public int _agentAmount;
        public float _spawnRadius;
        public float _agentSpeed;
        public float _agentRotationSpeed;
        public float _flockingDistance;
        public LayerMask _physicsLayer;
        public Agent _agentPrefab;

        // Use this for initialization
        void Start()
        {
            for (int i = 0; i < _agentAmount; i++)
            {
                Spawn();
            }
        }

        // Update is called once per frame
        void Update()
        {
            float horizontalMovement = Input.GetAxis("Horizontal");
            float verticalMovement = Input.GetAxis("Vertical");
            Vector3 movementVector = new Vector3(horizontalMovement, 0f, verticalMovement);
            if (Input.GetKey(KeyCode.R))
            {
                movementVector.y += 1f;
            }
            if (Input.GetKey(KeyCode.F))
            {
                movementVector.y -= 1f;
            }
            transform.Translate(movementVector * Time.deltaTime * 10f);
        }

        //    Spawn()
        //      - Instantiate the agent prefab
        //          - The position of which should be within "spawn radius"
        //      - Give it _small_ amount of random rotation for variation
        //      - Find the prefab's AgentBehaviour script:
        //          - Set its reference to AgentController to<this>
        //          - ie: make sure the AgentBehaviour script knows where AgentController is!
        public void Spawn()
        {
            Agent newAgent = Instantiate(_agentPrefab,
                transform.position + (Random.insideUnitSphere * _spawnRadius),
                Quaternion.identity,
                transform);
            
            newAgent.transform.Rotate(new Vector3(Random.Range(-45f, -45f),
                Random.Range(-45f, 45f),
                Random.Range(-45f, 45f)));

            newAgent._agentController = this;
        }

        public void SpawnMoreAgents()
        {
            for (int i = 0; i < _agentAmount; i++)
            {
                Spawn();
            }
        }
    }
}