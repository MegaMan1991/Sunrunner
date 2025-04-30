using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharicter : MonoBehaviour
{
    public float blood = 0;
   private  StateMachineMB mb;
    private PlayerMovment pm;
    private Dash da;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mb = GetComponent<StateMachineMB>();
        pm = GetComponent<PlayerMovment>();
       
        blood += 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.aKey.isPressed)
        {
            StartDash();
        }
        else 
        {
            mb.ChangeStates(null);
        }

    }
    public void StartDash() 
    {
        if(da == null)
            da = new Dash(this, pm);
        mb.ChangeStates(da);

    }
}
