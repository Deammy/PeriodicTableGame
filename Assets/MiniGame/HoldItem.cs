using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoldItem : MonoBehaviour
{
    public float mouse;
    public Vector3 mOffset;
    private float mZCoord;
    public float Radius;
    public LayerMask GroundObject;
    public bool Grounding;
    private Vector3 SafeVector;
    void Update(){
        OnMouseDown();
    }
    void OnMouseDown(){
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMousePos();
    }
    private Vector3 GetMousePos(){
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    void OnMouseDrag(){
        transform.position = GetMousePos() + mOffset;
        Grounding = Physics2D.OverlapCircle(transform.position,Radius,GroundObject);
        if(!Grounding){
            transform.position = GetMousePos() + mOffset;
            SafeVector = GetMousePos() + mOffset;
        }
        else{
            transform.position = SafeVector;
        }
    }
}
