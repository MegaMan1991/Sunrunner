using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour
{
    Vector2 movment;
    public float _moveSpeed = 1;
    public  float _flyTime = 5;
    private Rigidbody2D _rb;
    private float count = 0;


    public void inputPlayer(InputAction.CallbackContext _context)
    {
        movment = _context.ReadValue<Vector2>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        count = _flyTime;
    }

    // Update is called once per frame
    void Update()
    {
        float x = -movment.x;
        float y = movment.y;
        count += Time.deltaTime;
        if (count > _flyTime || count < 1) 
        {
            y = 0;
        }

        _rb.MovePosition(_rb.position + (new Vector2(x, y).normalized * _moveSpeed));
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (this.transform.position.y > collision.transform.position.y && _flyTime != float.MaxValue) 
        {
            count = (count < _flyTime ? 1 : 0);
        }
    }
}
