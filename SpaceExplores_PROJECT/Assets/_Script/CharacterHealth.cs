using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour {
    public float currentHealth { get; set; }
    public float maxHealth { get; set; }
    
   // public Slider healthBar;
   // public Slider waterBar;

    //image content
    public Image HealthImgContent;
    public Image WaterImgContent;

    /// <summary>
    /// Nivel maximo de agua
    /// </summary>
    public float waterMax { get; set; }
    /// <summary>
    /// Nivel atual de agua
    /// </summary>
    public float waterLevel { get; set; }
    float waitTime;

    // Use this for initialization
    void Start () {
        //health 
        maxHealth = 100;
        currentHealth = maxHealth; //nivel de vida começa cheio 
        //healthBar.value = CalculateHealth();
        WaterImgContent.fillAmount = CalculateHealth();

        //water
        waterMax = 100;
        waterLevel = waterMax; // quantidade de agua inicia cheio
        //waterBar.value = CalculateWaterLoss();
        WaterImgContent.fillAmount = CalculateWaterLoss();
        waitTime = 30;
	    }
	
	// Update is called once per frame
	void FixedUpdate() {

        WaterLoss();
       
	}

    /// <summary>
    /// função que aplica os valores do dano na vida do player 
    /// </summary>
    /// <param name="loss">dano</param>
    void HealthDamage(float loss)
    {
        currentHealth -= loss;
        //healthBar.value = CalculateHealth();

        HealthImgContent.fillAmount = CalculateHealth();
        
        if (currentHealth <= 0)
        {
            Debug.Log("you dead");
            //healthBar.fillRect.gameObject.SetActive(false);

        }
    }


    /// <summary>
    /// Calculo de perda de agua.
    /// A cada 30 segundos perde 10 unidades de agua
    /// </summary>
    void WaterLoss()
    {        
        waitTime -= Time.deltaTime;

        if(waitTime<= 0)
        {
            waterLevel -= 10;
            //waterBar.value = CalculateWaterLoss();
            WaterImgContent.fillAmount = CalculateWaterLoss();
            waitTime = 30;

            if (WaterImgContent.fillAmount <= 0)
            {
                HealthDamage(2); // tira dois de vida
               // waterBar.fillRect.gameObject.SetActive(false);
            }
        }        
    }
    
    float CalculateHealth()
    {
        return currentHealth / maxHealth;
    }

    float CalculateWaterLoss()
    {
        return waterLevel / waterMax;
    }

}
