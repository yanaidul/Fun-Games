using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Obj_Drag : MonoBehaviour
{

    [HideInInspector]public Vector2 Saveposisi;
    [HideInInspector]public bool IsDiAtasObj;
    Transform SaveObj;

    public int ID;
    public Text Tesk;

    [Space]

    public UnityEvent OnDragBenar;

    // Start is called before the first frame update
    void Start()
    {
        Saveposisi = transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown(){

    }

    private void OnMouseUp(){

        if(IsDiAtasObj){
            int ID_Tempat_Drop = SaveObj.GetComponent<Tempat_Drop>().ID;

            if(ID == ID_Tempat_Drop){
                transform.SetParent(SaveObj);
                transform.localPosition = Vector3.zero;
                transform.localScale = new Vector3(1f, 1f, 1f);

                SaveObj.GetComponent<SpriteRenderer>().enabled = false;
                SaveObj.GetComponent<Rigidbody2D>().simulated = false;
                SaveObj.GetComponent<BoxCollider2D>().enabled = false;

                gameObject.GetComponent<BoxCollider2D>().enabled = false;

                OnDragBenar.Invoke();

                GameSystem.instance.DataScore += 100;
            }
            else{
                transform.position = Saveposisi;
                GameSystem.instance.DataDarah--;
            }
        }
        
        else{
            transform.position = Saveposisi;
        }
        
    }

    private void OnMouseDrag(){
        Vector2 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position =  Pos;
    }

    private void OnTriggerStay2D(Collider2D trig){
        if (trig.gameObject.CompareTag("Drop")){
            IsDiAtasObj = true;
            SaveObj = trig.gameObject.transform;
        }
    }
     private void OnTriggerExit2D(Collider2D trig){
        if (trig.gameObject.CompareTag("Drop")){
            IsDiAtasObj = false;
        }
    }
}
