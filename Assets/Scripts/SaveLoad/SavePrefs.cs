using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SavePrefs : MonoBehaviour
{
    int intToSave;
    float floatToSave;
    string stringToSave = "";
    public Text intString;
    public Text floatString;

    private void Update()
    {
        intString.text = "Int:" + intToSave.ToString();
        floatString.text = ("Float:" + floatToSave.ToString());
        //updates the text to what the current float/int is
    }
    public void IntUp()
    {
        intToSave++;
        //Increases the int by 1

    }
    public void FloatUp()
    {
        floatToSave += 0.1f;
        //increase the float by 0.1
    }
   public void SaveGame()
    {
        PlayerPrefs.SetInt("SavedInteger", intToSave);
        PlayerPrefs.SetFloat("SavedFloat", floatToSave);
        PlayerPrefs.SetString("SavedString", stringToSave);
        PlayerPrefs.Save();
        Debug.Log("Saved Data, hell yeah!");
        //saves the data and provides a sassy message in the console
    }
  public  void LoadGame()
    {
        if (PlayerPrefs.HasKey("SavedInteger"))
        {
            intToSave = PlayerPrefs.GetInt("SavedInteger");
            floatToSave = PlayerPrefs.GetFloat("SavedFloat");
            stringToSave = PlayerPrefs.GetString("SavedString");
            Debug.Log("Game Data Loaded!");
            //loads the saved data
        }
        else
            Debug.LogError("There's no damn save data!");
        //gives an error because there's no data
    }
   public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        intToSave = 0;
        floatToSave = 0.0f;
        stringToSave = "";
        Debug.Log("Data Reset Complete");
        //resets savedata
    }

}
