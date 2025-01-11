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


    public void SpawnDamageText(float damage, GameObject target)
    {
        
        Vector3 newposition =  new Vector3(Random.Range(0f, 10f), 20 + Random.Range(0f, 10f), Random.Range(0f, 10f));
        GameObject newtext = Instantiate(TextPopUp, Canvas.transform);
        newtext.transform.position = newposition+ Canvas.transform.position;

        newtext.GetComponent<TextMeshProUGUI>().text = "" + (int)damage;
    }

}
