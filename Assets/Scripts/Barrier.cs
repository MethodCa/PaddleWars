using UnityEngine;

public class Barrier : MonoBehaviour
{
    public Global global;
    public Animator animator;
    
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        global.barrierTimer += Time.deltaTime;
        if (global.barrierTimer > 15) 
            animator.SetBool("On", false);
    }
}