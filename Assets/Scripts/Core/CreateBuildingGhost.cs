using UnityEngine;

public class CreateBuildingGhost : MonoBehaviour
{
    [SerializeField] private GameObject ghost;

    static GameObject _ghost;
    public void Create()
    {
        if(_ghost != null)
        {
            Destroy(_ghost);
        }
        else
        {
            _ghost = Instantiate(ghost, transform.position, Quaternion.identity);
        }  
    }
}
