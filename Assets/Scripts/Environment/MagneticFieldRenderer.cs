using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticFieldRenderer : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] GameObject crossPrefab;
    [SerializeField] GameObject dotPrefab;
    [SerializeField] FloatReference fieldStrength;

    [Header("Configs")]
    [SerializeField] int n;
    [SerializeField] int m;
    [SerializeField] float scaleFactor;

    GameObject[,] crosses;
    GameObject[,] dots;

    void Awake()
    {
        crosses = new GameObject[n, m];
        dots = new GameObject[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                crosses[i, j] = Instantiate(crossPrefab);
                dots[i, j] = Instantiate(dotPrefab);

                crosses[i, j].transform.position = new Vector3(-m / 2 + j, -n/2 + i, 0);
                dots[i, j].transform.position = new Vector3(-m / 2 + j, -n / 2 + i, 0);
            }
        }
    }

    void Update()
    {
        float scaleValue = fieldStrength.value * scaleFactor;
        for (int i = 0; i < n; i++)
        {
            for(int j = 0; j < m; j++)
            {
                for (int k = 0; k < 2; k++)
                {
                    if (fieldStrength.value > 0)
                    {
                        dots[i, j].SetActive(false);
                        crosses[i, j].SetActive(true);

                        GameObject child = crosses[i, j].transform.GetChild(k).gameObject;
                        Vector3 scale = child.transform.localScale;
                        scale.x = scaleValue;
                        child.transform.localScale = scale;
                    }
                    else
                    {
                        dots[i, j].SetActive(true);
                        crosses[i, j].SetActive(false);

                        Vector3 scale = dots[i, j].transform.localScale;
                        scale.x = scaleValue;
                        scale.y = scaleValue;
                        scale.z = scaleValue;

                        dots[i, j].transform.localScale = scale;

                    }
                }
            }
        }
        
    }
}
