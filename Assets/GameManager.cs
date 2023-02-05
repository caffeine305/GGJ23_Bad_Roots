using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject raiz;
    public GameObject troca;
    public float spawnTime;

    private float trocaX;
    private float trocaZ;

    public Vector3 rootPos;
    private Vector3 trocaPos;
    private Vector3 auxTrocaRot;
    private Quaternion trocaRot;

    public Transform raizTransform;
    public Transform trocaTransform;
    public GameObject gameOverBanner;

    public static int totalPoints;
    public static GameManager instanceGameManager;
    public int checkHP;

    void Start()
    {
        totalPoints = 0;
        instanceGameManager = this;
        StartCoroutine(RandomInstanceRootsWithDelay());
        StartCoroutine(RandomInstanceTrucksWithDelay()); 

        //checkHP = HealthManager.instanceHealthManager.actualHP;
    }

    IEnumerator RandomInstanceRootsWithDelay()
    {
        //Aquí iría letrero de inicio de Round

        //Vector3 bannerPos = new Vector3(-1.0f, 0.0f, -3.0f);

        while (HealthManager.instanceHealthManager.actualHP > 0)     // Este while vuelve al juego en modo endless hasta que te coman.
        {
            SetRandomRootPos();
            Instantiate(raiz, raizTransform.position , transform.rotation);

            //Se van a quitar las dos siguientes líneas. Originalmente todo estaba en una sola co-rutina.
            //SetRandomTroca();
            //Instantiate(troca, trocaTransform.position , trocaTransform.rotation);

            checkHP = HealthManager.instanceHealthManager.actualHP;
            yield return new WaitForSeconds(spawnTime * Random.Range(3.0f, 5.0f));
        }

        
        StartCoroutine(GameEnd());
        Debug.Log("Game Over");
    }

    IEnumerator RandomInstanceTrucksWithDelay()
    {
        while (true)     // Este while vuelve al juego en modo endless hasta que te coman.
        {
            SetRandomTroca();
            Instantiate(troca, trocaTransform.position , trocaTransform.rotation);

            yield return new WaitForSeconds(spawnTime * Random.Range(10.0f, 15.0f));
        }
    }

    IEnumerator GameEnd()
    {
            Vector3 posBanner = new Vector3(-1.76f,11.7f,-17.5f);
            Quaternion orient = new Quaternion(0.0f,0.7071068f,0.0f,0.7071068f);


            Instantiate(gameOverBanner,posBanner,orient);
            yield return new WaitForSeconds(4);
            SceneManager.LoadScene("Title");
    }

    /*
    IEnumerator PointsCounter()
    {
        while (true)  
        {
            pointsManager(Growth.points);
            yield return new WaitForSeconds(0.1f);
        }
    }
    */

    public void SetRandomRootPos()
    {
        int aux_X = Mathf.RoundToInt(Random.Range(-14.6f,12.5f) );
        int aux_Z = Mathf.RoundToInt(Random.Range(-12.0f,13.0f) );  

        //float rootX = Random.Range(-14.6f,12.5f);
        //float rootZ = Random.Range(-12.0f,13.0f);

        float rootX = aux_X * 1.0f;
        float rootZ = aux_Z * 1.0f;

        rootPos = new Vector3(rootX, 0.0f, rootZ);  
        raizTransform.position = rootPos; //Un transform para las raíces, Otro transform para la troca
    }

    public void SetRandomTroca()
    {
        int randomTrocaSelection = Random.Range(1,4);

        switch(randomTrocaSelection){
            case 1:
                //TrocaUp
                trocaX = 19.22f;
                trocaZ = 19.5f;
                
                //auxTrocaRot = new Vector3(0.0f,180.0f,0.0f); //[ 0, 1, 0, 0 ]
                
                trocaRot = new Quaternion(0,1,0,0);
            break;
            case 2:
                //TrocaSide
                trocaX = -17.7f;
                trocaZ = 29.0f;
                
                //auxTrocaRot = new Vector3(0.0f,90.0f,0.0f); //[ 0, 0.7071068, 0, 0.7071068 ]
                
                trocaRot = new Quaternion(0.0f,0.7071068f,0.0f,0.7071068f);
            break;
            case 3:
                //TrocaDown
                trocaX = -22.6f;
                trocaZ = -18.7f;

                //auxTrocaRot = new Vector3(0.0f,0.0f,0.0f); //[ 0, 0, 0, 1 ]

                trocaRot = new Quaternion(0,0,0,1);
            break;
        }

        trocaPos = new Vector3(trocaX,0.0f,trocaZ);

        trocaTransform.position = trocaPos; 
        trocaTransform.rotation = trocaRot;
    }

    public void PointsManager(int pointCount)
    {
        totalPoints = totalPoints + pointCount;
        
        if(totalPoints < -1)
            totalPoints = 0;

        Debug.Log("Total Points: "+totalPoints);
    }

}