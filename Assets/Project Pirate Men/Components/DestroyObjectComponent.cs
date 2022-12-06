using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPirateMen.Component
{
    public class DestroyObjectComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _objectToDestroy;

         public void DestoyObject()
        {
            Destroy(_objectToDestroy);
        }
    }
}
