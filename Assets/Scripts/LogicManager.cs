using TMPro;
using UnityEngine;

public class LogicManager : MonoBehaviour
{
    public TextMeshProUGUI score;

    public Global global;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        score.text = "Score: " + global.score;
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}