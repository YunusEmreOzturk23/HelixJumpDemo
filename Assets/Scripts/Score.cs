using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Button button;
    public GameObject splashPrefab;
    private int points = 0;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI loseText;
    public TextMeshProUGUI scoreText;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ScorePlatform"))
        {
            points++;
            scoreText.text = "Skor: " + points.ToString();
            Destroy(other.gameObject);
            Debug.Log(points);
        }
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject splash = Instantiate(splashPrefab, transform.position+new Vector3(0f,-0.2f,0f), transform.rotation);
        splash.transform.SetParent(collision.gameObject.transform);
        if (collision.gameObject.CompareTag("Burning"))
        {
            Debug.Log("Oyunu kaybettin");
            loseText.text = "Oyunu kaybettin";
            Time.timeScale = 0;
            button.gameObject.SetActive(true);
        }
        if (collision.gameObject.CompareTag("FinishRing"))
        {
            Debug.Log("Oyunu kazandýn");
            winText.text = "Oyunu kazandýn";
            Time.timeScale = 0;
            button.gameObject.SetActive(true);
        }
       
    }
}
