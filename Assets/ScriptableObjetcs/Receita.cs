using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Receita", menuName = "ScriptableObjects/Receita")]
public class Receita : ScriptableObject
{
    public string nome;
    public GameObject[] prefabIngrediente;
    public string tagReceita;

   public string getTagReceitaSolicitada()
    {
        //for (int i = 0; i<4;  i++)
        //{
        tagReceita = prefabIngrediente[0].tag + prefabIngrediente[1].tag + prefabIngrediente[2].tag + prefabIngrediente[3].tag + prefabIngrediente[4].tag;
       // }
        Debug.Log(tagReceita);
        return tagReceita;
    }
}
