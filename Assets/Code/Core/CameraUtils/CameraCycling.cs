using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Core.CameraUtils
{
    public class CameraCycling : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> cameras;

        private int _index;

        public void Cycle(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                cameras[_index].SetActive(false);
                _index = _index + 1 == cameras.Count ? 0 : _index + 1;
                cameras[_index].SetActive(true);
            }
        }
    }

}