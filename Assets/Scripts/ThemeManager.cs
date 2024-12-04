using System;
using System.Collections;
using System.Collections.Generic;
using Meta.XR.MRUtilityKit;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThemeManager : MonoBehaviour
{
    [Tooltip("Each gameObject in this list must be a Anchor Prefab Spawner")]
    [SerializeField] public List<GameObject> themes;

    public EffectMesh effectMesh;

    /*
     * sets active the theme (AnchorPrefabSpawner GameObject) according to
     * PlayerPrefs, using the theme name as the key and a value of 1 to set as active,
     * other values are set in-active
     */
    private void Awake()
    {
        foreach (GameObject theme in themes)
        {
            int active = PlayerPrefs.GetInt(theme.name);
            {
                if (active == 1)
                {
                    theme.SetActive(true);
                }
                else
                {
                    theme.SetActive(false);
                }
            }
        }
    }
    
    
    /*
     * method for selecting theme, itterates through list of themes (assigned in the inspecter) and
     * activates the gameObject with the given name, un-activating the others
     * also saves the names of the GameObjects as keys in PlayerPrefs with 1 for active or 0 for in-active
     * Then reloads the scene, this should reset the program with the newly selected theme, because of
     * the Awake method above.
     */
    public void SelectTheme(string themeName)
    {
        foreach (GameObject theme in themes)
        {
            if (theme.name == themeName)
            {
                theme.SetActive(true);
                PlayerPrefs.SetInt(theme.name, 1);
            }
            else
            {
                theme.SetActive(false);
                PlayerPrefs.SetInt(theme.name, 0);
            }
        }
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}
