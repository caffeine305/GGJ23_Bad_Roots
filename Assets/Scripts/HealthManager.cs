using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public CharacterController characterController;
    public static HealthManager instanceHealthManager;
    public static int maxHP = 100;
    public int actualHP;
    public Image vida;
    //public Slider healthSlider;

    public bool isDead;
    //bool damaged;
    private Animator playerAnimator;

    void Start()
    {
        actualHP = maxHP;
        isDead = false;

        vida.fillAmount = actualHP;

        //characterController = GetComponent<CharacterController>();

        playerAnimator = GetComponentInChildren<Animator>();
        playerAnimator.SetBool("IsDead",false);

        instanceHealthManager = this;

        //healthSlider.value = actualHP;
        /*
        GameObject LoadWaveObject = GameObject.FindWithTag("GameController");
        if (LoadWaveObject != null)
        {
            loadWave = LoadWaveObject.GetComponent<LoadWave>();
        }

        if (LoadWaveObject == null)
        {
            Debug.Log("No se puede encontrar el Script 'ZombiManager' ");
        }*/
    }

	void Update () 
    {
    if (actualHP < 1 )
        {
            DeathSequence();
        }
    }
      
    /*
    public DamageBehaviour()
    {
        //if (damaged) 
            // Cambia de color
            // conserva por fracción de segundos el cambio de color
        //else 
            //respeta el color
        //damaged = flase;
    }

    public void TakeDamage(int amount)
    {
        //Poner bandera de Damage para activar comportamiento de daño.
        damaged = true;

        //Restar energía una cantidad dictada por amount
        actualHP -= amount;
        Debug.Log(actualHP);

        //reducir el tamaño de la barra de energía
        loadWave.UpdateHealthBar(actualHP);

        //Si la energía llega a cero, Destruir personaje
        if (actualHP <= 0 && !isDead)
        {
            Death();
        }
        else { 

        }

    }*/

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
          int damage = Random.Range(15,20);
          actualHP = actualHP - damage;   

          vida.fillAmount = actualHP/100.0f;
          Debug.Log("Energía: "+ vida.fillAmount);
        }
    }

    public void DeathSequence()
    {
        //indicador de muerte que permita generar comportamiento apropiado.
        isDead = true;
        playerAnimator.SetBool("IsDead",true);
        
        CharacterController characterController = GetComponent<CharacterController>();
        characterController.enabled = false; 
        transform.rotation = new Quaternion(0,0,0,1);
            
        Destroy(this.gameObject,5.0f);
        //Animación de estallido estilo Megaman?
    }
}
