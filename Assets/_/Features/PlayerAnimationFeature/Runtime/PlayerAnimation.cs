using System;
using InputFeature.Runtime;
using PlayerFeature.Runtime;
using UnityEngine;

namespace PlayerAnimationFeature.Runtime
{
    public class PlayerAnimation : MonoBehaviour
    {

        #region Unity API

        private void Awake()
        {
	        _inputManager = GetComponent<InputManager>();
	        _animator = GetComponent<Animator>();
	        _choppingBoardInteraction = GetComponentInChildren<PlayerChoppingBoardInteraction>();
	        _playerInteraction = GetComponentInChildren<PlayerInteraction>();
	        _playerMovements = GetComponent<PlayerMovements>();
        }

        private void Start()
        {
	        _inputManager.m_onMove += OnWalkAnimationEventHandler;
	        _playerInteraction.m_onHoldPickable += OnHoldAnimationEventHandler;
	        _choppingBoardInteraction.m_onCutIngredient += OnCutAnimationEventHandler;
        }

        #endregion
        
    	#region Main Methods

        private void OnWalkAnimationEventHandler(object sender, OnMoveEventArgs e)
        {
	        _animator.SetFloat("walk", _playerMovements.enabled ? e.m_direction.magnitude : 0);
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

        #region Private and Protected Members

        private Animator _animator;
        
        private InputManager _inputManager;
        
        private PlayerInteraction _playerInteraction;
        private PlayerChoppingBoardInteraction _choppingBoardInteraction;

        private PlayerMovements _playerMovements;

        #endregion
    }
}