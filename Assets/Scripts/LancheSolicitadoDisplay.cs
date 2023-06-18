using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LancheSolicitadoDisplay : MonoBehaviour
{
    [SerializeField] private Transform[] ingredientesPosition;

    public Receita[] receita;
    public TextMeshProUGUI nomeReceita;
    public string tagReceitaSolicitada;
    public GameObject[] prefabIngrediente;
    
    private List<GameObject> currentIngredientes = new List<GameObject>();
    private int nReceitaSorteada;

    public void InstanciaLanche()
    {
        nReceitaSorteada = SorteiaReceita();
        nomeReceita.text = receita[nReceitaSorteada].nome;

        for (int i = 0; i < 5; i++)
        {
            prefabIngrediente[i] = receita[nReceitaSorteada].prefabIngrediente[i];
            GameObject x = Instantiate(prefabIngrediente[i], ingredientesPosition[i].position, Quaternion.identity, ingredientesPosition[i]);
            currentIngredientes.Add(x);
        }

        for (int i = 1; i < 4; i++)
        {
            prefabIngrediente[i] = receita[nReceitaSorteada].prefabIngrediente[i];
            GameObject x = Instantiate(prefabIngrediente[i], ingredientesPosition[i + 4].position, Quaternion.identity, ingredientesPosition[i + 4]);
            currentIngredientes.Add(x);
        }
        tagReceitaSolicitada = receita[nReceitaSorteada].getTagReceitaSolicitada();
    }

    public void RemoveLanche()
    {
        for (int i = 0; i < currentIngredientes.Count; i++)
        {
            Destroy(currentIngredientes[i].gameObject);
        }

        tagReceitaSolicitada = receita[nReceitaSorteada].getTagReceitaSolicitada();
    }

    public int SorteiaReceita()
    {
        int i;
        i = Random.Range(0, 6);
        return i;
    }
}
