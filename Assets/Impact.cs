using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact : MonoBehaviour
{
    public float duration = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, duration);
    }
}
