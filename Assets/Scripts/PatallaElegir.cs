using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PatallaElegir : MonoBehaviour
{
    public static int cantJugadores = 0;
    public List<GameObject> carritos;

    public List<GameObject> c1;
    public List<GameObject> c2;
    public List<GameObject> c3;
    public List<GameObject> c4;

    private bool[] carSelected;
    private bool[] playerSelecciono;

    public Text p1;
    public Text p2;
    public Text p3;
    public Text p4;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        carSelected = new bool[4];
        playerSelecciono = new bool[4];
        for (int i = 0; i < 4; ++i)
        {
            carSelected[i] = false;
            playerSelecciono[i] = false;
        }
        cantJugadores = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        #region seleccion p1
        if (!playerSelecciono[0])
        {
            if (Input.GetButtonDown("p1_A") && !carSelected[0])
            {
                playerSelecciono[0] = true;
                carSelected[0] = true;
                Selecciones.Instance.carSelected[0] = carritos[0];
                foreach (GameObject gm in c1)
                {
                    if (gm.tag != "1")
                    {
                        gm.SetActive(false);
                    }
                }
                c2[0].SetActive(false);
                c3[0].SetActive(false);
                c4[0].SetActive(false);
            }
            else if (Input.GetButtonDown("p1_B") && !carSelected[1])
            {
                playerSelecciono[0] = true;
                carSelected[1] = true;
                Selecciones.Instance.carSelected[0] = carritos[1];
                foreach (GameObject gm in c2)
                {
                    if (gm.tag != "1")
                    {
                        gm.SetActive(false);
                    }
                }
                c1[0].SetActive(false);
                c3[0].SetActive(false);
                c4[0].SetActive(false);
            }
            else if (Input.GetButtonDown("p1_Y") && !carSelected[2])
            {
                playerSelecciono[0] = true;
                carSelected[2] = true;
                Selecciones.Instance.carSelected[0] = carritos[2];
                foreach (GameObject gm in c3)
                {
                    if (gm.tag != "1")
                    {
                        gm.SetActive(false);
                    }
                }
                c1[0].SetActive(false);
                c2[0].SetActive(false);
                c4[0].SetActive(false);
            }
            else if (Input.GetButtonDown("p1_X") && !carSelected[3])
            {
                playerSelecciono[0] = true;
                carSelected[3] = true;
                Selecciones.Instance.carSelected[0] = carritos[3];
                foreach (GameObject gm in c4)
                {
                    if (gm.tag != "1")
                    {
                        gm.SetActive(false);
                    }
                }
                c1[0].SetActive(false);
                c2[0].SetActive(false);
                c3[0].SetActive(false);
            }
            if (playerSelecciono[0])
            {
                Selecciones.Instance.cantJugadores++;
                Selecciones.Instance.isOnline[0] = true;
                p1.color = Color.green;

            }
        }
        #endregion
        #region seleccion p2
        if (!playerSelecciono[1])
        {
            if (Input.GetButtonDown("p2_A") && !carSelected[0])
            {
                playerSelecciono[1] = true;
                carSelected[0] = true;
                Selecciones.Instance.carSelected[1] = carritos[0];
                foreach (GameObject gm in c1)
                {
                    if (gm.tag != "2")
                    {
                        gm.SetActive(false);
                    }
                }
                c2[1].SetActive(false);
                c3[1].SetActive(false);
                c4[1].SetActive(false);
            }
            else if (Input.GetButtonDown("p2_B") && !carSelected[1])
            {
                playerSelecciono[1] = true;
                carSelected[1] = true;
                Selecciones.Instance.carSelected[1] = carritos[1];
                foreach (GameObject gm in c2)
                {
                    if (gm.tag != "2")
                    {
                        gm.SetActive(false);
                    }
                }
                c1[1].SetActive(false);
                c3[1].SetActive(false);
                c4[1].SetActive(false);
            }
            else if (Input.GetButtonDown("p2_Y") && !carSelected[2])
            {
                playerSelecciono[1] = true;
                carSelected[2] = true;
                Selecciones.Instance.carSelected[1] = carritos[2];
                foreach (GameObject gm in c3)
                {
                    if (gm.tag != "2")
                    {
                        gm.SetActive(false);
                    }
                }
                c1[1].SetActive(false);
                c2[1].SetActive(false);
                c4[1].SetActive(false);
            }
            else if (Input.GetButtonDown("p2_X") && !carSelected[3])
            {
                playerSelecciono[1] = true;
                carSelected[3] = true;
                Selecciones.Instance.carSelected[1] = carritos[3];
                foreach (GameObject gm in c4)
                {
                    if (gm.tag != "2")
                    {
                        gm.SetActive(false);
                    }
                }
                c1[1].SetActive(false);
                c2[1].SetActive(false);
                c3[1].SetActive(false);
            }
            if (playerSelecciono[1])
            {
                Selecciones.Instance.cantJugadores++;
                Selecciones.Instance.isOnline[1] = true;
                p2.color = Color.green;

            }
        }
        #endregion
        #region seleccion p3
        if (!playerSelecciono[2])
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && !carSelected[0])
            {
                playerSelecciono[2] = true;
                carSelected[0] = true;
                Selecciones.Instance.carSelected[2] = carritos[0];
                foreach (GameObject gm in c1)
                {
                    if (gm.tag != "3")
                    {
                        gm.SetActive(false);
                    }
                }
                c2[2].SetActive(false);
                c3[2].SetActive(false);
                c4[2].SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && !carSelected[1])
            {
                playerSelecciono[2] = true;
                carSelected[1] = true;
                Selecciones.Instance.carSelected[2] = carritos[1];
                foreach (GameObject gm in c2)
                {
                    if (gm.tag != "3")
                    {
                        gm.SetActive(false);
                    }
                }
                c1[2].SetActive(false);
                c3[2].SetActive(false);
                c4[2].SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && !carSelected[2])
            {
                playerSelecciono[2] = true;
                carSelected[2] = true;
                Selecciones.Instance.carSelected[2] = carritos[2];
                foreach (GameObject gm in c3)
                {
                    if (gm.tag != "3")
                    {
                        gm.SetActive(false);
                    }
                }
                c1[2].SetActive(false);
                c2[2].SetActive(false);
                c4[2].SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && !carSelected[3])
            {
                playerSelecciono[2] = true;
                carSelected[3] = true;
                Selecciones.Instance.carSelected[2] = carritos[3];
                foreach (GameObject gm in c4)
                {
                    if (gm.tag != "3")
                    {
                        gm.SetActive(false);
                    }
                }
                c1[2].SetActive(false);
                c2[2].SetActive(false);
                c3[2].SetActive(false);
            }
            if (playerSelecciono[2])
            {
                Selecciones.Instance.cantJugadores++;
                Selecciones.Instance.isOnline[2] = true;
                p3.color = Color.green;
            }
        }
        #endregion
        #region seleccion p3
        if (!playerSelecciono[3])
        {
            if (Input.GetKeyDown(KeyCode.A) && !carSelected[0])
            {
                playerSelecciono[3] = true;
                carSelected[0] = true;
                Selecciones.Instance.carSelected[3] = carritos[0];
                foreach (GameObject gm in c1)
                {
                    if (gm.tag != "4")
                    {
                        gm.SetActive(false);
                    }
                }
                c2[3].SetActive(false);
                c3[3].SetActive(false);
                c4[3].SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.S) && !carSelected[1])
            {
                playerSelecciono[3] = true;
                carSelected[1] = true;
                Selecciones.Instance.carSelected[3] = carritos[1];
                foreach (GameObject gm in c2)
                {
                    if (gm.tag != "4")
                    {
                        gm.SetActive(false);
                    }
                }
                c1[3].SetActive(false);
                c3[3].SetActive(false);
                c4[3].SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.D) && !carSelected[2])
            {
                playerSelecciono[3] = true;
                carSelected[2] = true;
                Selecciones.Instance.carSelected[3] = carritos[2];
                foreach (GameObject gm in c3)
                {
                    if (gm.tag != "4")
                    {
                        gm.SetActive(false);
                    }
                }
                c1[3].SetActive(false);
                c2[3].SetActive(false);
                c4[3].SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.W) && !carSelected[3])
            {
                playerSelecciono[3] = true;
                carSelected[3] = true;
                Selecciones.Instance.carSelected[3] = carritos[3];
                foreach (GameObject gm in c4)
                {
                    if (gm.tag != "4")
                    {
                        gm.SetActive(false);
                    }
                }
                c1[3].SetActive(false);
                c2[3].SetActive(false);
                c3[3].SetActive(false);
            }
            if (playerSelecciono[3])
            {
                Selecciones.Instance.cantJugadores++;
                Selecciones.Instance.isOnline[3] = true;
                p4.color = Color.green;
            }
        }
        #endregion

        if(Selecciones.Instance.cantJugadores >= 4 || (Selecciones.Instance.cantJugadores >= 2 && Input.GetKeyDown(KeyCode.Space)))
        {
            SceneManager.LoadScene("test01");
        }
    }
}
