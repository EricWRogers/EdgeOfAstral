using UnityEngine;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{

    public int GameInteger { get; set; }
    public string GameString { get; set; }
    public bool GameBool { get; set; }
    public float GameSpawn { get; set; }
    /*[SerializeField]
    private Text textInteger;
    [SerializeField]
    private Text textString;

    public void GenerateNewData()
    {
        GameInteger = Random.Range(1, 1000);
        GameString = System.Convert.ToBase64String(System.BitConverter.GetBytes(GameInteger));
        ShowData();
    }

    public void ShowData()
    {
        textInteger.text = GameInteger.ToString();
        textString.text = GameString;
    }*/
}
