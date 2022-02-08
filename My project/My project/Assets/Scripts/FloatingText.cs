
using UnityEngine;

public class FloatingText : MonoBehaviour
{

    public float DestroyTime = 3f;

    void Start()
    {

        Destroy(gameObject, DestroyTime);

    }


}
