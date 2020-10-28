
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private Vector3 _initialPosition;
    private bool _birdWasLaunched;
    private float _timeSittingAround;
    private LevelController _levelController;
    private Animator _animator;

    //private LevelController _levelController;

    [SerializeField] private float _launchPower = 500;

    private void Awake()
    {
        _levelController = GameObject.FindObjectOfType<LevelController> ();
        _initialPosition = transform.position;
        _animator = GetComponent<Animator>();
        //_animator.enabled = false;
         _animator.speed = 0.4f;
    }

    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);
        
        if (_birdWasLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _timeSittingAround += Time.deltaTime;
        }

        if (
            transform.position.y >  10 ||
            transform.position.x >  20 ||
            transform.position.x < -20 ||
            _timeSittingAround   >   3    )
        {
            if (!_levelController.hasWon) {
                string currentSceneName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(currentSceneName);
            }   
        }

    }
  
    private void OnMouseDown()
    {
        GetComponent<LineRenderer>().enabled = true;
        GetComponent<SpriteRenderer>().color = new Color(202f/255f, 114f/255f, 24f/255f);
    }

    private void OnMouseUp()
    {
        _animator.speed = 1;
        GetComponent<LineRenderer>().enabled = false;
        GetComponent<SpriteRenderer>().color = Color.white;

        Vector2 directionToInitialPosition = _initialPosition - transform.position;

        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdWasLaunched = true;
    }

    private void OnMouseDrag()
    {
        _animator.speed = 0.1f;
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (newPosition.x < -11) 
            newPosition.x = -11;
        else if (newPosition.x > -4) 
            newPosition.x = -4f;
        if (newPosition.y < -5.28) 
            newPosition.y = -5.28f;
        else if (newPosition.y >  4) 
            newPosition.y = 4;
            
        {
            transform.position = new Vector3(newPosition.x, newPosition.y);
        }
    }
}
