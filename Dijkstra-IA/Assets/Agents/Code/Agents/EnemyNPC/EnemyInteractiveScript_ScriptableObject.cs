using Blakes.FiniteStateMachine.Agents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blakes.FiniteStateMachine
{
    [CreateAssetMenu(menuName = "Finite State Machine/New Enemy Interactive Script")]
    public class EnemyInteractiveScript_ScriptableObject : ScriptableObject
    {
        //[Header("Base configuration")]
        //[SerializeField] public GameObject prefabOfTheEnemy;
        //[Header("Spawn transform")]
        //[SerializeField] public Vector3 positionToSpawn;
        //[SerializeField] public Vector3 rotationToSpawn;
        //[Header("Cone of vision")]
        //[SerializeField] public GameObject prefabOfASliceOfTheCone;
        //[SerializeField] public int coneVisionAngle;
        //[SerializeField] public float coneVisionDistance;
        [Header("Runtime Patrol Behaviour")]
        [SerializeField] public List<PatrolScript> patrolScript;
    }
}