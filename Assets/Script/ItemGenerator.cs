using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemGenerator : MonoBehaviour
{

    public GameObject carPrefab;
    public GameObject coinPrefab;
    public GameObject conePrefab;

    private int startPos = -160;
    private int goalPos = 120;
    private float posRange = 3.4f;
    private float unitychanPosZ;
    private int[] itemGenJudge = new int[20];
    private int iIndex = 0;


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        unitychanPosZ = GameObject.Find("unitychan").transform.position.z;

        for (int i = startPos; i < goalPos; i += 15)
        {

            if (i <= unitychanPosZ + 50 && !itemGenJudge.Contains(i))
            {
                itemGenJudge[iIndex] = itemGen(i);
                iIndex++;
            }


        }

        GameObject carBehind = GameObject.Find("CarPrefab(Clone)");
        GameObject coneBehind = GameObject.Find("TrafficConePrefab(Clone)");
        GameObject coinBehind = GameObject.Find("CoinPrefab(Clone)");
        GameObject camera = GameObject.Find("Main Camera");


        if (carBehind.transform.position.z < camera.transform.position.z)
        {
            Destroy(carBehind);
            Debug.Log("destoyCar");
        }
        if (coneBehind.transform.position.z < camera.transform.position.z)
        {
            Destroy(coneBehind);
            Debug.Log("destoyCone");

        }
        if (coinBehind.transform.position.z < camera.transform.position.z)
        {
            Destroy(coinBehind);
            Debug.Log("destoyCoin");

        }

    }

    public int itemGen(int distanceZ)
    {

        int num = Random.Range(1, 11);
        if (num <= 2)
        {

            //cone*5
            for (float j = -1; j <= 1; j += 0.4f)
            {

                GameObject cone = Instantiate(conePrefab) as GameObject;
                cone.transform.position = new Vector3(posRange * j, cone.transform.position.y, distanceZ);
            }
        }
        else
        {
            //randomItem


            for (int j = -1; j <= 1; j++)
            {
                int item = Random.Range(1, 11);
                int offsetz = Random.Range(-5, 6);

                if (1 <= item && item <= 6)
                {

                    GameObject car = Instantiate(carPrefab) as GameObject;
                    car.transform.position = new Vector3(posRange * j, car.transform.position.y, distanceZ + offsetz);

                }
                else if (7 <= item && item <= 9)
                {

                    GameObject coin = Instantiate(coinPrefab) as GameObject;
                    coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, distanceZ + offsetz);
                }
            }

        }
        return distanceZ;

    }





}
