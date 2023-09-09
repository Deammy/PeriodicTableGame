using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalCheck : MonoBehaviour
{
    public string IsMetal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Box")){
            int Number = collision.gameObject.GetComponent<SafeElementN>().X;
            if(ElementAll.Element[Number].Metal == IsMetal){
                CheckWin.Counting++;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Box")){
            int Number = collision.gameObject.GetComponent<SafeElementN>().X;
            if(ElementAll.Element[Number].Metal == IsMetal){
                CheckWin.Counting--;
            }
        }
    }
}
