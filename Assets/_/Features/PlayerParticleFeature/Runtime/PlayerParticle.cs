using System;
using PlayerFeature.Runtime;
using UnityEngine;

namespace PlayerParticleFeature.Runtime
{
    public class PlayerParticle : MonoBehaviour
    {
    	#region Public Members



    	#endregion


    	#region Unity API

        private void Start()
        {
	        _playerDash.m_onPlayerDash += OnDashParticleEventHandler;
        }

        #endregion


    	#region Main Methods
        
        private void OnDashParticleEventHandler(object sender, EventArgs e)
        {
	        _dashParticle.Play();
        }

    	#endregion


    	#region Utils



    	#endregion


    	#region Private and Protected Members
        
        [SerializeField] private ParticleSystem _dashParticle;
        [SerializeField] private PlayerDash _playerDash;

        #endregion
    }
}