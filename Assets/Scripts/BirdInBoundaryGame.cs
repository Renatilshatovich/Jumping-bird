using UnityEngine;

namespace DefaultNamespace
{
    public class BirdInBoundaryGame : MonoBehaviour
    {
        private const string LooseMessage = "Вы проиграли!";
        [SerializeField] private Bird _bird;

        [SerializeField] private float _upperYLimmit;
        [SerializeField] private float _lowerYLimmit;

        private bool isRunning;
        
        private void Awake() => StartGame();

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F)) 
                StartGame();

            if (isRunning == false)
                return;

            if (IsOutOfBoundary()) 
                LooseGame();
        }

        private bool IsOutOfBoundary() => 
            _bird.transform.position.y > _upperYLimmit || _bird.transform.position.y < _lowerYLimmit;

        private void LooseGame()
        {
            _bird.gameObject.SetActive(false);
            Debug.Log(LooseMessage);
            isRunning = false;
        }

        private void StartGame()
        {
            _bird.gameObject.SetActive(true);
            _bird.transform.position = new Vector3(0, 0, 0);
            _bird.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            isRunning = true;
        }
    }
}