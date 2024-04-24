using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public double year1Score = 0.00;
    public double year2Score = 0.00;
    public double year3Score = 0.00;
    public double year4Score = 0.00;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }
}
