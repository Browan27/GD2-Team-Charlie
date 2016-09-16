using UnityEngine;
using System.Collections;

public class AudioScript : MonoBehaviour {

    // Use this for initialization
    static AudioScript instance;

    void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }
}
