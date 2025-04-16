using UnityEngine;

public class TapCube : MonoBehaviour
{
    public void DestroyCube()
    {
        Debug.Log("Destroy the cube!");
        //destroy is a common method on all GameObjects
        //'gameObject is a keyword for THIS gameObject
        Destroy(gameObject);
    }
}
