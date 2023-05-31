using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class StartMenuButtonPress : MonoBehaviour, IPointerDownHandler
{
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("start game"); 
        SceneManager.LoadScene("PractiseRange");
    }
}
