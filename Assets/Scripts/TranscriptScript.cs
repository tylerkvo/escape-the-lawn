using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class TranscriptScript : MonoBehaviour
{
    public ScoreScript score;
    public int year;
    public TextMeshProUGUI gpaText;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Score").GetComponent<ScoreScript>();
    }

    // Update is called once per frame
    void Update()
    {
        gpaText.text = "";
        if (year < 5) {
            double gpa = score.gpas[year-1];
            if (gpa > 0) {
                gpaText.text = gpa.ToString("F2");
            }
        }
        else {
            double cumGPA = calculateCumGPA();
            
            if (cumGPA > 0) {
                gpaText.text = cumGPA.ToString("F2");
            }
        }
    }
    double calculateCumGPA() {
        int count = 0;
        double cumGPA = 0;
        foreach (double gpa in score.gpas) {
            if (!(gpa > 0)) {
                break;
            }
            cumGPA += gpa;
            count += 1;
        }
        if (count == 0) {
            return 0;
        }
        return cumGPA/count;
    }
}
