using TMPro;
using UnityEngine;

public class ZoneChange : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI zoneText;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Plaza"))
        {
            zoneText.text = "Plaza";
            zoneText.color = new Color(0, 0, 0, 1);
        }
        else if(other.gameObject.CompareTag("Mecanico"))
        {
            zoneText.text = "Plaza - Mecanico";
            zoneText.color = new Color(0, 0, 0, 1);
        }
        else if(other.gameObject.CompareTag("Panadero"))
        {
            zoneText.text = "Plaza - Panadero";
            zoneText.color = new Color(0, 0, 0, 1);
        }
        else if (other.gameObject.CompareTag("Floristeria"))
        {
            zoneText.text = "Plaza - Floristeria";
            zoneText.color = new Color(0, 0, 0, 1);
        }
        else if (other.gameObject.CompareTag("Tren"))
        {
            zoneText.text = "Estación de Tren";
            zoneText.color = new Color(0, 0, 0, 1);
        }
        else if (other.gameObject.CompareTag("Pozo"))
        {
            zoneText.text = "Pozo";
            zoneText.color = new Color(0, 0, 0, 1);
        }
        else if (other.gameObject.CompareTag("Iglesia"))
        {
            zoneText.text = "Iglesia";
            zoneText.color = new Color(0, 0, 0, 1);
        }
        else if (other.gameObject.CompareTag("Playa"))
        {
            zoneText.text = "Playa";
            zoneText.color = new Color(0, 0, 0, 1);
        }
        else if (other.gameObject.CompareTag("Granja"))
        {
            zoneText.text = "Granja";
            zoneText.color = new Color(0, 0, 0, 1);
        }
        else if (other.gameObject.CompareTag("Barranco"))
        {
            zoneText.text = "Barranco Libertad";
            zoneText.color = new Color(0, 0, 0, 1);
        }
    }
}

