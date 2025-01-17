using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GPAScript : MonoBehaviour
{
    public double gpa = 4.00;
    private float time = 0;
    public Text gpaText;
    public bool timerOn;
    public int gracePeriod = 10;
    public ScoreScript score;
    private int level;
    // Start is called before the first frame update
    void Start()
    {
        timerOn = true;
        score = GameObject.Find("Score").GetComponent<ScoreScript>();
        Scene scene = SceneManager.GetActiveScene();
        level = int.Parse(scene.name.Split(' ')[1]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate() {
        
        if (timerOn) {
            time += Time.deltaTime;
            updateGPA();
        }
    }
    public void updateGPA() {
        double minutes = Mathf.FloorToInt(time / 60);
        double seconds = Mathf.FloorToInt(time % 60);
        double timePassed = minutes * 60 + seconds;
        if (timePassed > gracePeriod) {
            gpa = 4.00 - (timePassed - gracePeriod) / 100;
        }
        if (gpa < 2.00) {
            gpa = 2.00;
        }
        score.gpas[level-1] = gpa;
        gpaText.text = string.Format("GPA: {0:F2}", gpa);
    }
}
