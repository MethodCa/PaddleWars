using UnityEngine;

public class BrickManager : MonoBehaviour
{
    // Start is called before the first frame update
    [field: Header("Brick types")]
    [field: SerializeField]
    public GameObject Brick { get; private set; }


    public static BrickManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null) Debug.Log("There is more than one BrickManager instance in the scene");
        instance = this;
    }
}