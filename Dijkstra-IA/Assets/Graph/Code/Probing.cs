using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blakes.Graph
{
    public class Probing : MonoBehaviour
    {
        #region Variables

        public GameObject nodePrefab;
        public int numberOfNodes = 10;
        public float distanceX = 2f;
        public float distanceY = 2f;
        public Vector3 startPosition = Vector3.zero;

        #endregion

        #region UnityMethods

        void Start()
        {
            GenerateNodes();
        }

        #endregion

        #region LocalMethods

        void GenerateNodes()
        {
            for (int i = 0; i < numberOfNodes; i++)
            {
                for (int j = 0; j < numberOfNodes; j++)
                {
                    Vector3 nodePosition = startPosition + new Vector3(i * distanceX, 0, j * distanceY);
                    Instantiate(nodePrefab, nodePosition, Quaternion.identity);
                }
            }
        }

        #endregion
    }
}