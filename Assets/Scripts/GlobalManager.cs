using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    // Start is called before the first frame update
    [field: Header("Global Variables Manager")]
    [field: SerializeField]
    public Global global { get; private set; }


    public static GlobalManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null) Debug.Log("There is more than one GlobalManager instance in the scene");
        instance = this;
    }
}