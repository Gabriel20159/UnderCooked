using UnityEngine;
using UnityEngine.InputSystem;

namespace MultiplayerManagerFeature.Runtime
{
    public class MultiplayerManager : MonoBehaviour
    {
        #region Unity API

        private void Awake()
        {
            _spawnPoints = new Transform[_spawnPointParent.childCount];

            for (int i = 0; i < _spawnPoints.Length; i++)
            {
                _spawnPoints[i] = _spawnPointParent.GetChild(i);
            }
        }

        private void Start()
        {
            PlayerInputManager.instance.onPlayerJoined += OnPlayerJoinedEventHandler;
        }

        #endregion

        #region Main Methods
        
        private void OnPlayerJoinedEventHandler(PlayerInput player)
        {
            player.transform.position = _spawnPoints[_spawnCurrentIndex % _spawnPoints.Length].position;
            _spawnCurrentIndex++;
        }

        #endregion

        #region Private and Protected Members

        [SerializeField] private Transform _spawnPointParent;
        
        private Transform[] _spawnPoints;

        private int _spawnCurrentIndex;

        #endregion
    }
}
