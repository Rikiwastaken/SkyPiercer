using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SceneInfo : MonoBehaviour
{
    public bool incombat;
    public List<GameObject> enemylist;
    public GameObject focus;
    public GameObject TextPopUp;
    private GameObject Canvas;

    private void Start()
    {
        Canvas = GameObject.Find("Canvas");
    }

    private void FixedUpdate()
    {
        if(!incombat && focus!=null)
        {
            focus = null;
            foreach (Transform tr in Canvas.transform)
            {
                Destroy(tr.gameObject);
            }
        }
    }


    public void SpawnDamageText(float damage)
    {
        
        Vector3 newposition =  new Vector3(Random.Range(-200f, 200f), 20 + Random.Range(0f, 100f), 0);
        GameObject newtext = Instantiate(TextPopUp, Canvas.transform);
        newtext.transform.position = newposition+ Canvas.transform.position;

        newtext.GetComponent<TextMeshProUGUI>().text = "" + (int)damage;
        Debug.Log(newtext.transform.position);
    }

    public void SpawnDamageText(float damage, Color color)
    {

        Vector3 newposition = new Vector3(Random.Range(-200f, 200f), 20 + Random.Range(0f, 100f), 0);
        GameObject newtext = Instantiate(TextPopUp, Canvas.transform);
        newtext.transform.position = newposition + Canvas.transform.position;
        newtext.GetComponent<TextMeshProUGUI>().color = color;
        newtext.GetComponent<TextMeshProUGUI>().text = "" + (int)damage;
        Debug.Log(newtext.transform.position);
    }

}
