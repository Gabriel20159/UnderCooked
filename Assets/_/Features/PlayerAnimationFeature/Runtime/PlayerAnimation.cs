using System;
using InputFeature.Runtime;
using InteractableFeature.Runtime;
using PlayerFeature.Runtime;
using UnityEngine;

namespace PlayerAnimationFeature.Runtime
{
    public class PlayerAnimation : MonoBehaviour
    {
    	#region Public Members

		

    	#endregion


    	#region Unity API

        private void Start()
        {
	        InputManager.m_instance.m_onMove += OnWalkAnimationEventHandler;
	        _playerInteraction.m_onHoldPickable += OnHoldAnimationEventHandler;
	        _playerInteraction.m_onCutIngredient += OnCutAnimationEventHandler;

        }

        #endregion


    	#region Main Methods

        private void OnWalkAnimationEventHandler(object sender, OnMoveEventArgs e)
        {
	        _animator.SetFloat("walk", e.m_direction.magnitude);
        }
        
        private void OnCutAnimationEventHandler(object sender, EventArgs e)
        {
	        _animator.SetTrigger("Cut");
        }

        private void OnHoldAnimationEventHandler(object sender, bool e)
        {
			_animator.SetBool("isHold", e);   
        }

        private void OnVictoryAnimationEventHandler(object sender, EventArgs e)
        {
	        _animator.SetBool("isVictory", true);
        }

    	#endregion


    	#region Utils



    	#endregion


    	#region Private and Protected Members

        [SerializeField] private Animator _animator;
        [SerializeField] private PlayerDash _playerDash;
        [SerializeField] private PlayerInteraction _playerInteraction;

        #endregion
    }
}