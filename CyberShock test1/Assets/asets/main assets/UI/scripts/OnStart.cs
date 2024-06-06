using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnStart : MonoBehaviour
{
    public Graphic m_graphic;
    public Button m_button;
    public void OnClick()
    {
        if(StaticObject.playableMapData)
        {
            SceneManager.LoadScene("Gameplay");
            MapValues.scorePoints = 0;
        }
    }
    void Start()
    {
        m_graphic = gameObject.GetComponent<Graphic>();
    }
    void Update()
    {
        if(!StaticObject.playableMapData)
        {
            m_graphic.color = Color.gray;
            m_button.interactable = false;
        }else
        {
            m_graphic.color = Color.white;
            m_button.interactable = true;
        }
    }
}