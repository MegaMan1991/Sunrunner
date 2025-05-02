using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour
{
    Vector2 movment;
    [SerializeField] float _moveSpeed = 1;
    private Rigidbody2D _rb;

    public void inputPlayer(InputAction.CallbackContext _context)
    {
        movment = _context.ReadValue<Vector2>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.MovePosition(_rb.position + (new Vector2(-movment.x, movment.y).normalized * _moveSpeed));
    }
}
