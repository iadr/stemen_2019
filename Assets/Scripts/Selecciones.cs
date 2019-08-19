using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selecciones : MonoBehaviour
{
    public static Selecciones Instance;
    public  int cantJugadores;
    public bool[] isOnline;
    public  GameObject[] carSelected;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            RestartSelecciones();
        }
        DontDestroyOnLoad(this);
    }
    public void RestartSelecciones()
    {
        cantJugadores = 0;
        isOnline = new bool[4];
        carSelected = new GameObject[4];
    }
}
