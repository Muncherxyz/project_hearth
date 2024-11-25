using System.Collections;
using System.Collections.Generic;
using Meta.XR.MRUtilityKit;
using UnityEngine;

public class ThemeManager : MonoBehaviour
{
    [Tooltip("Each gameObject in this list should have a Anchor Prefab Spawner")]
    [SerializeField] public List<GameObject> themes;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    
    /*
     * method for selecting theme, itterates through list of themes (assigned in the inspecter) and
     * activates the gameObject with the given name, un-activating the others
     */
    public void SelectTheme(string themeName)
    {
        foreach (GameObject theme in themes)
        {
            if (theme.name == themeName)
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
