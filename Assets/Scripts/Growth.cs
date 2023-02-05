using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Growth : MonoBehaviour
{

    private int sideA;
    private int sideB; 

    private TextMesh rootSizeDisplay;
    private string rootSizeString;
    public int rootSize;
    public static int points;

    public float delayTime;
    public float repeatRate; 

    //Instancia del GameManager para emplear GM.pointsmanager()


    void Start()
    {
        sideA = Random.Range(1,4);
        sideB = Random.Range(1,4);

        delayTime = Random.Range(1.0f,2.0f);
        repeatRate = Random.Range(3.0f,5.0f);

        rootSizeDisplay = GetComponentInParent<TextMesh>();

        rootSize = sideA * sideB;
         
        VisualRootSize();

        //Debug.Log("Initial Root Size is: " + rootSize);
        InvokeRepeating("GrowingRoot", delayTime, repeatRate);

    }

    void GrowingRoot()
    {
        sideA = sideA + Random.Range(1,4);
        sideB = sideB + Random.Range(1,4);

        rootSize = sideA * sideB;

        VisualRootSize();

        //Debug.Log("Root Size is: " + rootSize);

    }

    void VisualRootSize()
    {
        Vector3 scale = transform.localScale;
         
        scale.x = sideA * 0.25f;
        scale.y = rootSize * 0.25f;
        scale.z = sideB * 0.25f;

        transform.localScale = scale;

        rootSizeString = rootSize.ToString();
        rootSizeDisplay.text = rootSizeString;  
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Podador")
        {
            if(sideA > 1 && sideB > 1)
            {
                /*if(sideA > sideB)
                {
                    sideA = sideA - 1;
                    rootSize = sideA * sideB;
                }else if(sideB > sideA)
                {
                    sideB = sideB - 1;
                    rootSize = sideA * sideB;
                }
                */
                if(rootSize > 1){
                    rootSize = rootSize - 1;

                    if(sideB > sideA) 
                        sideB = Mathf.RoundToInt(rootSize/sideA);
                    else
                        sideA = Mathf.RoundToInt(rootSize/sideB);

                    rootSize = sideA * sideB;     
                    
                }else{
                    rootSize = 1;
                    sideA = 1;
                    sideB = 1;
                }

            //Debug.Log("Root Size decreased to:" + rootSize);
            //Debug.Log("Side a is: "+sideA);
            //Debug.Log("Side b is: "+sideB);
            }
            VisualRootSize();
 
        }


        if(other.tag == "Cortador")
        {
            float sqroot = Mathf.Sqrt(rootSize);
            int intRoot = Mathf.RoundToInt(sqroot);

            int testSquare = sideA * sideA;

            if( testSquare == rootSize )
            {
                points = intRoot;
                Debug.Log("Puntos: "+points);
                GameManager.instanceGameManager.PointsManager(points);
            }
            else{
                //Debug.Log("Raiz Incompleta :(");
                points = -intRoot;
                Debug.Log("Puntos: "+ points);
                GameManager.instanceGameManager.PointsManager(points);
            }

            Destroy(transform.root.gameObject);
        }
        
        if(other.tag == "Bullet")
        {
            if(sideA > 1 && sideB > 1)
            {
                if(rootSize > 4){
                    rootSize = rootSize - 4;

                    if(sideB > sideA) 
                        sideB = Mathf.RoundToInt(rootSize/sideA);
                    else
                        sideA = Mathf.RoundToInt(rootSize/sideB);

                    rootSize = sideA * sideB;     
                    
                }else{
                    rootSize = 1;
                    sideA = 1;
                    sideB = 1;
                }

            //Debug.Log("Root Size decreased to:" + rootSize);
            //Debug.Log("Side a is: "+sideA);
            //Debug.Log("Side b is: "+sideB);
            }
            VisualRootSize();
        }
    
    }

}
