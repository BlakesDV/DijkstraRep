using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blakes.Graph
{
    public class Node : MonoBehaviour
    {
        //0 to any connections
        [SerializeField] protected List<Connection> connections;
    }
}
