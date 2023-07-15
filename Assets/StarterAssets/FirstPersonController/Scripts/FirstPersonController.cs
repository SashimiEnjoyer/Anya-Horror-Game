﻿using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{

	public class FirstPersonController : MonoBehaviour
	{
		[Header("Player")]
		[Tooltip("Move speed of the character in m/s")]
		public float MoveSpeed = 4.0f;
		private float initialMoveSpeed;//new
		[Tooltip("Sprint speed of the character in m/s")]
		public float SprintSpeed = 6.0f;
		[Tooltip("Rotation speed of the character")]
		public float RotationSpeed = 1.0f;
		private float initialRotationSpeed;//new
		[Tooltip("Acceleration and deceleration")]
		public float SpeedChangeRate = 10.0f;
		public bool moveFreeze = false; //new

		[Space(10)]
		[Tooltip("The character uses its own gravity value. The engine default is -9.81f")]
		public float Gravity = -15.0f;

		[Space(10)]
		//[Tooltip("Time required to pass before being able to jump again. Set to 0f to instantly jump again")]
		//public float JumpTimeout = 0.1f;
		[Tooltip("Time required to pass before entering the fall state. Useful for walking down stairs")]
		public float FallTimeout = 0.15f;

		[Header("Player Grounded")]
		[Tooltip("If the character is grounded or not. Not part of the CharacterController built in grounded check")]
		public bool Grounded = true;
		[Tooltip("Useful for rough ground")]
		public float GroundedOffset = -0.14f;
		[Tooltip("The radius of the grounded check. Should match the radius of the CharacterController")]
		public float GroundedRadius = 0.5f;
		[Tooltip("What layers the character uses as ground")]
		public LayerMask GroundLayers;

		[Header("Cinemachine")]
		[Tooltip("The follow target set in the Cinemachine Virtual Camera that the camera will follow")]
		public GameObject CinemachineCameraTarget;
		[Tooltip("How far in degrees can you move the camera up")]
		public float TopClamp = 90.0f;
		[Tooltip("How far in degrees can you move the camera down")]
		public float BottomClamp = -90.0f;

		// cinemachine
		private float _cinemachineTargetPitch;

		// player
		private float _speed;
		private float _rotationVelocity;
		private float _verticalVelocity;
		private float _terminalVelocity = 53.0f;

		// timeout deltatime
		//private float _jumpTimeoutDelta;
		private float _fallTimeoutDelta;

		private CharacterController _controller;

		private const float _threshold = 0.01f;

		private void Start()
		{
			_controller = GetComponent<CharacterController>();
			//_input = GetComponent<StarterAssetsInputs>();

			// reset our timeouts on start
			//_jumpTimeoutDelta = JumpTimeout;
			_fallTimeoutDelta = FallTimeout;

			initialMoveSpeed = MoveSpeed; //new
			initialRotationSpeed = RotationSpeed; //new
		}

		private void Update()
		{
			ApplyGravity();
			GroundedCheck();
			Move();

            if (Input.GetKeyDown(KeyCode.Escape) && moveFreeze == true)
            {
				UnfreezeMovement();
            }
        }

		private void LateUpdate()
		{
			CameraRotation();
		}

		private void GroundedCheck()
		{
			// set sphere position, with offset
			Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - GroundedOffset, transform.position.z);
			Grounded = Physics.CheckSphere(spherePosition, GroundedRadius, GroundLayers, QueryTriggerInteraction.Ignore);
		}

		private void CameraRotation()
		{
			// if there is an input
			if (InGameInput.onMouseMove.sqrMagnitude >= _threshold)
			{
				//Don't multiply mouse input by Time.deltaTime
				float deltaTimeMultiplier =  1.0f;
				
				_cinemachineTargetPitch += InGameInput.onMouseMove.y * RotationSpeed * deltaTimeMultiplier;
				_rotationVelocity = InGameInput.onMouseMove.x * RotationSpeed * deltaTimeMultiplier;

				// clamp our pitch rotation
				_cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

				// Update Cinemachine camera target pitch
				CinemachineCameraTarget.transform.localRotation = Quaternion.Euler(_cinemachineTargetPitch, 0.0f, 0.0f);

				// rotate the player left and right
				transform.Rotate(Vector3.up * _rotationVelocity);
			}
		}

		private void Move()
		{
			// set target speed based on move speed, sprint speed and if sprint is pressed
			float targetSpeed = InGameInput.IsDash ? SprintSpeed : MoveSpeed;

			// a simplistic acceleration and deceleration designed to be easy to remove, replace, or iterate upon

			// note: Vector2's == operator uses approximation so is not floating point error prone, and is cheaper than magnitude
			// if there is no input, set the target speed to 0
			if (InGameInput.onMove == Vector2.zero) targetSpeed = 0.0f;

			// a reference to the players current horizontal velocity
			float currentHorizontalSpeed = new Vector3(_controller.velocity.x, 0.0f, _controller.velocity.z).magnitude;

			float speedOffset = 0.1f;
			//float inputMagnitude = _input.analogMovement ? InGameInput.onMove.magnitude : 1f;

			// accelerate or decelerate to target speed
			if (currentHorizontalSpeed < targetSpeed - speedOffset || currentHorizontalSpeed > targetSpeed + speedOffset)
			{
				// creates curved result rather than a linear one giving a more organic speed change
				// note T in Lerp is clamped, so we don't need to clamp our speed
				_speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed, Time.deltaTime * SpeedChangeRate);

				// round speed to 3 decimal places
				_speed = Mathf.Round(_speed * 1000f) / 1000f;
			}
			else
			{
				_speed = targetSpeed;
			}

			// normalise input direction
			Vector3 inputDirection = new Vector3(InGameInput.onMove.x, 0.0f, InGameInput.onMove.y).normalized;

			// note: Vector2's != operator uses approximation so is not floating point error prone, and is cheaper than magnitude
			// if there is a move input rotate player when the player is moving
			if (InGameInput.onMove != Vector2.zero)
			{
				// move
				inputDirection = transform.right * InGameInput.onMove.x + transform.forward * InGameInput.onMove.y;
			}

			// move the player
			_controller.Move(inputDirection.normalized * (_speed * Time.deltaTime) + new Vector3(0.0f, _verticalVelocity, 0.0f) * Time.deltaTime);
		}

		private void ApplyGravity()
		{
			if (Grounded)
			{
				//reset the fall timeout timer
			   _fallTimeoutDelta = FallTimeout;

				//stop our velocity dropping infinitely when grounded
				if (_verticalVelocity < 0.0f)
				{
					_verticalVelocity = -2f;
				}

				////Jump
				//if (_input.jump && _jumpTimeoutDelta <= 0.0f)
				//{
				//	//the square root of H * -2 * G = how much velocity needed to reach desired height
				//   _verticalVelocity = Mathf.Sqrt(JumpHeight * -2f * Gravity);
				//}

				//jump timeout
				//if (_jumpTimeoutDelta >= 0.0f)
				//{
				//	_jumpTimeoutDelta -= Time.deltaTime;
				//}
			}
			else
			{
				//reset the jump timeout timer
			   //_jumpTimeoutDelta = JumpTimeout;

				//fall timeout
				if (_fallTimeoutDelta >= 0.0f)
				{
					_fallTimeoutDelta -= Time.deltaTime;
				}

				//if we are not grounded, do not jump

			   //_input.jump = false;
			}

			// apply gravity over time if under terminal (multiply by delta time twice to linearly speed up over time)
			if (_verticalVelocity < _terminalVelocity)
			{
				_verticalVelocity += Gravity * Time.deltaTime;
			}
		}

		private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
		{
			if (lfAngle < -360f) lfAngle += 360f;
			if (lfAngle > 360f) lfAngle -= 360f;
			return Mathf.Clamp(lfAngle, lfMin, lfMax);
		}

		private void OnDrawGizmosSelected()
		{
			Color transparentGreen = new Color(0.0f, 1.0f, 0.0f, 0.35f);
			Color transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);

			if (Grounded) Gizmos.color = transparentGreen;
			else Gizmos.color = transparentRed;

			// when selected, draw a gizmo in the position of, and matching radius of, the grounded collider
			Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y - GroundedOffset, transform.position.z), GroundedRadius);
		}

		public void FreezeMovement()
		{
			moveFreeze = true;
			MoveSpeed = 0;
			RotationSpeed = 0;
			GetComponent<ItemInteractor>().isInteracting = true;
		}

        public void UnfreezeMovement()
        {
            moveFreeze = false;
            MoveSpeed = initialMoveSpeed;
            RotationSpeed = initialRotationSpeed;
            GetComponent<ItemInteractor>().isInteracting = false;
        }
    }
}