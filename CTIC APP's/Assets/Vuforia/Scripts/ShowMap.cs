using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowMap : MonoBehaviour
{
    Sprite sprite;
    public static string mapName;
    // Start is called before the first frame update
    void Start()
    {
        if (mapName == "" || mapName == null)
        {
            sprite = Resources.Load<Sprite>("Maps/Normal_Map");
        }
        else
        {
            sprite = Resources.Load<Sprite>(mapName);
        }
        GameObject.Find("Map").GetComponent<Image>().sprite = sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (mapName == "" || mapName == null)
        {
            sprite = Resources.Load<Sprite>("Maps/Normal_Map");
        }
        else
        {
            sprite = Resources.Load<Sprite>(mapName);
        }
        GameObject.Find("Map").GetComponent<Image>().sprite = sprite;
    }

    public void openMap()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
