using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    float movVertical, movHorizontal;
    public float velocidad = 1.0f;
    public float altitud = 8.0f;
    public bool isJump = false;
    public Text gemsText;
    public Text lifesText;
    public Text timeText;
    public GameObject startPoint;
    bool pause = false;
    int gems = 0;
    int lifes = 3;
    float totalTime = 120;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!pause){
            CountDown();
        }
        movVertical = Input.GetAxis("Vertical");
        movHorizontal = Input.GetAxis("Horizontal");
        print(movHorizontal);

        Vector3 movimiento = new Vector3(movHorizontal, 0.0f ,movVertical); 

        rb.AddForce(movimiento*velocidad);

        if(Input.GetKey(KeyCode.Space) && (!isJump)){
            Vector3 salto = new Vector3(0,altitud,0);
            rb.AddForce(salto*velocidad);
            isJump = true;
        }
    }

    void OnCollisionEnter(Collision collision){
            print(collision.gameObject.name);
            if (collision.gameObject.name == "Floor" || collision.gameObject.name == "Wood")
            {
                isJump = false;
            }
    }

    void OnTriggerEnter(Collider collider){
            if (collider.gameObject.name == "Gema")
            {
                Destroy(collider.gameObject);
                gems += 1;
                gemsText.text ="0"+gems.ToString();
            }
            if (collider.gameObject.name == "DeadZone")
            {
                transform.position = startPoint.transform.position;
                lifes -= 1;
                lifesText.text = "0" + lifes.ToString();
            }
    }

    void CountDown(){
        totalTime -= Time.deltaTime;
        int min = Mathf.FloorToInt(totalTime/60f);
        int sec = Mathf.FloorToInt(totalTime-(min*60f));
        timeText.text = string.Format("{0:0}:{01:00}",min,sec);
    }

    public void PauseGame(){
        pause = !pause;
        rb.isKinematic = pause;
    }
}
