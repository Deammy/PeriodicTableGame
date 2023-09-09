using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelInteract : MonoBehaviour
{
    public int Level;
    public float FadeTiming;
    private bool InRange;
    private bool ControlWaitForMinutes = true;
    public UnityEvent InteractClick;
    public GameObject TextSign;
    public Light light;
    SpriteRenderer rend;
    SpriteRenderer Stand;
    float f = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rend = TextSign.GetComponent<SpriteRenderer>();
        Color c = rend.material.color;
        if(PlayerPrefs.GetInt("CurrentLevel",0) < Level-1){
            Stand = GetComponent<SpriteRenderer>();
            Stand.material.color = GetComponent<LockLevelColor>().LockColor;
            light.enabled = false;
        }
        c.a = 0f;
        rend.material.color = c;
    }
    void Update()
    {
        if(InRange){
            if(Input.GetKeyDown(KeyCode.E) && PlayerPrefs.GetInt("CurrentLevel",0) >= Level-1){
                InteractClick.Invoke();
            }
            if(ControlWaitForMinutes && PlayerPrefs.GetInt("CurrentLevel",0) >= Level-1){
                StartCoroutine(FadeInObject());
            }
        }
        else{
            if(ControlWaitForMinutes){
                StartCoroutine(FadeOutObject());
            }
        }
        if(Input.GetKeyDown(KeyCode.P)){
            RestartPref();
        }
    }
    public void SceneLoad(string Name){
        SceneManager.LoadScene(Name);
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            InRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            InRange = false;
        }
    }
    IEnumerator FadeInObject(){
        while(f < 1f){
            ControlWaitForMinutes = false;
            f = f + 0.05f;
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            light.intensity += 0.05f;
            yield return new WaitForSeconds(FadeTiming);
            ControlWaitForMinutes = true;
        }
    }
    IEnumerator FadeOutObject(){
        while(f > 0f){
            ControlWaitForMinutes = false;
            f = f - 0.05f;
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            light.intensity -= 0.05f;
            yield return new WaitForSeconds(FadeTiming);
            ControlWaitForMinutes = true;
        }
    }
    void RestartPref(){
        PlayerPrefs.SetInt("CurrentLevel",0);
    }
}
