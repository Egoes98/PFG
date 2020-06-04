using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottleMinigameLogic : MonoBehaviour
{
    bool solved;
    bool inMinigame;
    bool checking;

    [Header("References")]
    public GameObject bottles;
    public GameObject vase;
    public ObjectInteraction oI;
    public ObjectInteraction oIM;
    public GameObject player;
    public GameObject logic;
    public Material m_Material;
    public ObjectsData oD;

    [Header("AudioReferences")]
    public AudioSource correct;
    public AudioSource incorrect;

    [Header("OrderData")]
    public string correctOrder;
    string input;

    void Start()
    {
        this.GetComponent<BoxCollider>().enabled = false;
        bottles.SetActive(false);
        solved = false;
        inMinigame = false;
        checking = false;
        input = "";
        m_Material.color = Color.white;
    }

    public void Interact()
    {
        if (solved) return;
        if (!inMinigame)
        {
            EnterMiniGame();
        }
    }

    void EnterMiniGame()
    {
        inMinigame = true;
        logic.SetActive(true);
        player.SetActive(false);
        oIM.enabled = false;
        Cursor.lockState = CursorLockMode.None;

    }
    void ExitMinigame()
    {
        inMinigame = false;
        logic.SetActive(false);
        player.SetActive(true);
        oIM.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    public void ActivateMinigame()
    {
        bottles.SetActive(true);
        oI.enabled = false;
        bottles.SetActive(true);
        this.GetComponent<BoxCollider>().enabled = true;
        EnterMiniGame();
    }

    void Check()
    {
        if (input.CompareTo(correctOrder) == 0)
        {
            solved = true;
            correct.Play();
            oD.Found();
            Destroy(vase);
            ExitMinigame();
        }
        else
        {
            checking = false;
            incorrect.Play();
            m_Material.color = Color.white;
            input = "";
        }
    }

    public void ButtonClicked(string c)
    {
        if (checking) return;
        input = input + c;
        SetColor();
        if (input.Length == 3) checking = true;

    }

    void SetColor()
    {
        switch (input)
        {
            case "b":
                m_Material.color = Color.blue;
                break;
            case "g":
                m_Material.color = Color.green;
                break;
            case "r":
                m_Material.color = Color.red;
                break;
            case "bg":
                m_Material.color = new Color(0f, 1f, 1f);
                break;
            case "br":
                m_Material.color = new Color(1f, 0f, 1f);
                break;
            case "bgr":
                m_Material.color = new Color(0.3f, 0.4f, 0.6f);
                Check();
                break;
            case "brg":
                m_Material.color = new Color(0.3f, 0.4f, 0.6f);
                Check();
                break;
            case "gr":
                m_Material.color = new Color(1f, 1f, 0f);
                break;
            case "gb":
                m_Material.color = new Color(0f, 1f, 1f);
                break;
            case "gbr":
                m_Material.color = new Color(0.3f, 0.4f, 0.6f);
                Check();
                break;
            case "grb":
                m_Material.color = new Color(0.3f, 0.4f, 0.6f);
                Check();
                break;
            case "rb":
                m_Material.color = new Color(1f, 0f, 1f);
                break;
            case "rg":
                m_Material.color = new Color(1f, 1f, 0f);
                break;
            case "rgb":
                m_Material.color = new Color(0f, 0f, 0f);
                Check();
                break;
            case "rbg":
                m_Material.color = new Color(0.3f, 0.4f, 0.6f);
                Check();
                break;
        }
    }

    public void Update()
    {
        if (inMinigame)
        {
            if (Input.GetMouseButtonDown(1))
            {
                ExitMinigame();
            }
        }
    }
}
