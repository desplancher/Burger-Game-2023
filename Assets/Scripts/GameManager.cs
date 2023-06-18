using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] ingredientesSprite;
    [SerializeField] private Transform[] ingredientesPosition;

    public GameObject PainelStart;
    public GameObject PainelEnd;
    public LancheSolicitadoDisplay lancheSolicitado;
    public TextMeshProUGUI nomeLancheSolicitado;
    public TextMeshProUGUI txtTempoPainelStart;
    public Text txtPontuacao;
    public Text txtTempo;
    public TextMeshProUGUI txtPontuacaoEnd;
    
    private int pontuacao;
    private float tempo = 120f;
    private int tempoPainelStart = 3;
    private string tagReceitaCriada;
    private int ingredientesCount = 0;
    private List<GameObject> currentIngredientes = new List<GameObject>();

    void Start()
    {
        StartCoroutine(ContadorParaStart());
    }

    public void IstantiateIngredientes(int i)
    {
        GameObject x = Instantiate(ingredientesSprite[i], ingredientesPosition[ingredientesCount].position, Quaternion.identity, ingredientesPosition[ingredientesCount]);
        currentIngredientes.Add(x);
        ingredientesCount++;
        tagReceitaCriada = tagReceitaCriada + ingredientesSprite[i].tag;
        Debug.Log(tagReceitaCriada);
    }

    public void LimparIngredientes()
    {
        for (int i = 0; i<currentIngredientes.Count; i++)
        {
            Destroy(currentIngredientes[i].gameObject);
            tagReceitaCriada = null;
        }
        ingredientesCount = 0;
    }

    public void StartGame()
    {
        StartCoroutine(ContadorParaEnd());
        pontuacao = 0;
        lancheSolicitado.InstanciaLanche();
        RemoverPainel();
    } 

    public void RemoverPainel()
    {
        Destroy(PainelStart.gameObject, tempoPainelStart);
    }

    public void EntregarPedido()
    {
        if (lancheSolicitado.tagReceitaSolicitada == tagReceitaCriada)
        {
            LimparIngredientes();
            lancheSolicitado.RemoveLanche();
            lancheSolicitado.InstanciaLanche();
            pontuacao = pontuacao + 10;
            txtPontuacao.text = pontuacao.ToString();
        }
        else
        {
            LimparIngredientes();
            pontuacao = pontuacao - 15;
            txtPontuacao.text = pontuacao.ToString();   
        }
    }
    
    IEnumerator ContadorParaStart()
    {
        while (tempoPainelStart > 0)
        {
            txtTempoPainelStart.text = tempoPainelStart.ToString(); 
            yield return new WaitForSeconds(1f);
            tempoPainelStart--;
        }

        txtTempoPainelStart.text = "Vai!";
        yield return new WaitForSeconds(1f);
        RemoverPainel();
        StartGame();
    }

    IEnumerator ContadorParaEnd()
    {
        while (tempo > 0)
        {
            txtTempo.text = tempo.ToString();
            yield return new WaitForSeconds(1f);
            tempo--;
        }

        txtTempo.text = "0";
        txtPontuacaoEnd.text = pontuacao.ToString();
        PainelEnd.SetActive(true);
    }
}
