using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectPirateMen
{
    public class HeroInputReader : MonoBehaviour
    {
        [SerializeField] private Hero _hero; 

        void Start()
        {
            _hero = FindObjectOfType<Hero>();
        }
        
        public void OnMovement(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();
            _hero.SetDirection(direction);
        }

        public void OnSaySomething(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                _hero.SaySomething();
            }
        }
        
    }
}

