using UnityEngine;
using System.Collections;

public class Paths : MonoBehaviour
{
    public static Paths instance;
    private void Awake()
    {
        instance = this;
    }
}
