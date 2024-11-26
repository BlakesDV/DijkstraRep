using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blakes.Dijkstra
{
    #region PublicEnumForAllClasses

    public enum States
    {
        UNO,
        DOS,
        TRES
    }

    #endregion

    public class RaycastNode : MonoBehaviour
    {


        #region KnobsParameters
        public List<Vector3> startingPoints;

        #endregion

        #region RuntimeVariables

        /*protected Ray _ray;
        protected float _raycastDistance;*/

        #endregion

        #region PublicMethods

        public void RaycastToNode()
        {
            RaycastHit _raycastHit;

            foreach (Vector3 startingPoint in startingPoints)
            {
                Vector3 origin = startingPoint + transform.position;
                Vector3 direction = transform.position - origin;
                float distance = direction.magnitude;
                //Using the layer mask parameter, we seek / search for this specific type of object
                //in this context, we are interested in searching for any feature from the labyrinth
                //to validate if the avatar may pass through this node while path finding
                if (Physics.Raycast(origin, direction, out _raycastHit, distance, LayerMask.GetMask("Layout")))
                {
                    //The raycast has detected something from the labyrinth, so this
                    //node has to be discarded to take part in the graph

                    //We do not have to continue to explore the for, since
                    //as one raycast found something from the labyrinth, this node is already discarde
                    break; //-> it stops the foreach
                    //return; //this ends the method
                }
            }
            //TODO: Pending
        }

        #endregion
    }
}