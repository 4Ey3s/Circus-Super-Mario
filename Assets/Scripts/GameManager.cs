using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{  
    public static GameManager manager;

    private void Awake()
    {
        if (manager == null)
        {
            DontDestroyOnLoad(gameObject);
            manager = this;

        }
        else
        {
            Destroy(gameObject);
        }

    }
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
       
    }

    
    
}
