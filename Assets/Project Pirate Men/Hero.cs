using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPirateMen 
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private float _speed = 1f;
        [SerializeField] private float _jumpPower = 1f;
        [SerializeField] private LayerMask _groundLayer;

        [SerializeField] private float _groundCheckRadius = .5f;
        [SerializeField] private Vector3 _groundCheckPositionDelta;


        private Rigidbody2D _rigidbody;
        private Vector2 _direction;

        public int _coins { get; private set; }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = new Vector2(_direction.x * _speed, _rigidbody.velocity.y);

            var isJumping = _direction.y > 0;
            if (isJumping && IsGrounded())
            {
                _rigidbody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = IsGrounded() ? Color.green : Color.red;
            Gizmos.DrawSphere(transform.position + _groundCheckPositionDelta, _groundCheckRadius);
        }

        private bool IsGrounded()
        {
            var hit = Physics2D.CircleCast(transform.position + _groundCheckPositionDelta, _groundCheckRadius, Vector2.down, 0f, _groundLayer);
            return hit.collider != null;
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        public void SaySomething()
        {
            Debug.Log("Say something");
        }

        public void AddCoins(int coins)
        {
            _coins += coins;
            Debug.Log($"{coins} coins added. total coins: {_coins}");
        }
    }
}

