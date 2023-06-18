using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ContadorInicio : MonoBehaviour
{
    public int contadorTempo;
    public Text contadorDisplay;
    public GameManager gameManager;

    IEnumerator ContagemParaIniciar()
    {
        while(contadorTempo > 0)
        {
            contadorDisplay.text = contadorTempo.ToString();
            yield return new WaitForSeconds(1f);
            contadorTempo--;
        }

        contadorDisplay.text = "Vai!";
        gameManager.StartGame();
        contadorDisplay.gameObject.SetActive(false);
    }
}
