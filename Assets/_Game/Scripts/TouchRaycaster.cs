using UnityEngine;
using UnityEngine.Windows;

public class TouchRaycaster : MonoBehaviour
{
    [SerializeField] private InputHandler _input;
    [SerializeField] private GameObject _touchVisual;

    private void Awake()
    {
        // disable by default 
        _touchVisual.SetActive(false);
    }
    private void OnEnable()
    {
        _input.TouchStarted += OnTouchStarted;
        _input.TouchEnded += OnTouchEnded;

    }
    private void OnDisable()
    {
        _input.TouchStarted -= OnTouchStarted;
        _input.TouchEnded -= OnTouchEnded;
    }

    private void Update()
    {
        if (_input.TouchHeld)
        {
            RepositionVisual(_input.TouchCurrentPosition);
        }
    }

    private void OnTouchStarted(Vector2 position)
    {
        //Debug.Log("TouchRaycast: Started: " +  position);
        //_touchVisual.SetActive(true);
        DetectWorldCollider(position);
    }
    private void DetectWorldCollider (Vector2 position)
    {
        // create ray from camera angle into tap point
        Ray ray = Camera.main.ScreenPointToRay(position);
        // if our ray hits a collider
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Debug.Log("Touched: " + hitInfo.transform.gameObject.name);
            _touchVisual.transform.position = hitInfo.point;
            _touchVisual.SetActive(true);
            //search the collider hit for the Touchable component
            Touchable touchable = 
                hitInfo.collider.gameObject.GetComponent<Touchable>();
            //if so, 'Touch' it
            if(touchable != null)
            {
                touchable.Touch();
            }
        }

    }
    private void OnTouchEnded(Vector2 position)
    {
        //Debug.Log("TouchRaycast: Ended: " + position);
        _touchVisual.SetActive(false);
    }
    private void RepositionVisual(Vector2 position)
    {
        //create ray from camera angle into tap point
        Ray ray = Camera.main.ScreenPointToRay(position);
        // if our ray hits a collider
        if (Physics.Raycast(ray,out RaycastHit hitInfo))
        {
            Debug.Log("Touched: " + hitInfo.transform.gameObject.name);
            _touchVisual.transform.position = hitInfo.point;
            _touchVisual.SetActive(true);
        }
    }
   
}
