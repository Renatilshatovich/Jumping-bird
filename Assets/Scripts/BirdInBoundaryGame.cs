using UnityEngine;

namespace DefaultNamespace
{
    public class BirdInBoundaryGame : MonoBehaviour
    {
        private const string LooseMessage = "Вы проиграли!";
        
        [Header("Game Rules")] 
        [SerializeField] private int _scoreToWin = 20;
        private int _horizontalJumpScore = 3;
        
        [Header("References")]
        [SerializeField] private Bird _bird;
        [SerializeField] private GameObject _upperBoundary;
        [SerializeField] private GameObject _lowerBoundary;
        [SerializeField] private GameObject _rightBoundary;
        [SerializeField] private GameObject _leftBoundary;

        [Header("Boundaries")]
        [SerializeField] private float _upperYLimit = 5;
        [SerializeField] private float _lowerYLimit = -4;
        [SerializeField] private float _rightXLimit = 6;
        [SerializeField] private float _leftXLimit = -6;

        private bool _isRunning;
        private int _totalScore;

        private void Awake() => StartGame();

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F)) 
                StartGame();

            if (!_isRunning)
                return;

            UpdateScore();
            CheckWinCondition();
            
            if (IsOutOfBoundary()) 
                LoseGame();
        }

        private void UpdateScore()
        {
            _totalScore = 
                _bird.VerticalJumps + _bird.HorizontalJumps * _horizontalJumpScore;
        }

        private void CheckWinCondition()
        {
            if (_totalScore >= _scoreToWin)
            {
                _bird.Stop();
                Debug.Log("Вы ПОБЕДИЛИ!");
                _isRunning = false;
            }
        }
        
        private bool IsOutOfBoundary()
        {
            Vector3 position = _bird.transform.position;
            return position.y > _upperYLimit ||
                   position.y < _lowerYLimit ||
                   position.x > _rightXLimit ||
                   position.x < _leftXLimit;
        }

        private void LoseGame()
        {
            _bird.Kill();
            Debug.Log(LooseMessage);
            Debug.Log($"Ваш счёт {_totalScore}");
            _isRunning = false;
        }

        private void StartGame()
        {
            if (_isRunning)
                return;
            
            _bird.RestJumpCounter();
            _bird.gameObject.SetActive(true);
            _bird.transform.position = Vector3.zero;
            _bird.GetComponent<Rigidbody>().velocity = Vector3.zero;
            _bird.GetComponent<Rigidbody>().isKinematic = false;    

            _upperBoundary.transform.position = new Vector3(0, _upperYLimit, 0);
            _lowerBoundary.transform.position = new Vector3(0, _lowerYLimit, 0);
            _rightBoundary.transform.position = new Vector3(_rightXLimit, 1, 0);
            _leftBoundary.transform.position = new Vector3(_leftXLimit, 1, 0);
            
            _isRunning = true;
        }
    }
}