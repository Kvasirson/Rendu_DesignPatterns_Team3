
using UnityEngine;

public class PlayerTrailPart : MonoBehaviour
{
    InputManager _inputManager;
    [SerializeField]CircleCollider2D _collider;
    [SerializeField] ParticleSystem _trailPart;
    // Start is called before the first frame update
    void Start()
    {
        _inputManager = GetComponent<InputManager>();
        //_collider = GetComponent<Collider2D>();
        //_trailPart = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(_inputManager.GetInput().x)  > 0.1f)
        {

            int factor;
            if(_inputManager.GetInput().x > 0)
            {
                factor = -1;
            }
            else
            {
                factor = 1;
            }
            _trailPart.gameObject.transform.localPosition = new Vector2(_collider.radius * factor, _trailPart.transform.localPosition.y);
        }
        else
        {
            _trailPart.gameObject.transform.localPosition = new Vector2(0, _trailPart.transform.localPosition.y);
        }
    
    }
}
