using UnityEngine;

public class PUManager : MonoBehaviour
{
    // Start is called before the first frame update
    [field: Header("PowerUp types")]
    [field: SerializeField]
    public GameObject multiball { get; private set; }
    [field: SerializeField] public GameObject largepaddle { get; private set; }
    [field: SerializeField] public GameObject smallPaddle { get; private set; }
    [field: SerializeField] public GameObject megaball { get; private set; }
    [field: SerializeField] public GameObject barrier { get; private set; }


    public static PUManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null) Debug.Log("There is more than one PUManager instance in the scene");
        instance = this;
    }
}