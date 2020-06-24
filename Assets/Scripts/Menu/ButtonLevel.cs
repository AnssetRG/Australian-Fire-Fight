using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonLevel : MonoBehaviour
{
    [SerializeField]
    private Button btnLevel;
    [SerializeField]
    private int Level;

    // Start is called before the first frame update
    void Start()
    {
        btnLevel = GetComponent<Button>();
        btnLevel.onClick.AddListener(() => MenuGeneralController.instance.LoadLevel(Level));
    }
}