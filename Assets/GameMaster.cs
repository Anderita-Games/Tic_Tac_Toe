using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class GameMaster : MonoBehaviour
{
     //Needed for Line 39-40
    //SCORING TEXT
    public UnityEngine.UI.Text Player1;
    public UnityEngine.UI.Text Tie;
    public UnityEngine.UI.Text Player2;
    public UnityEngine.UI.Text Player1AS;
    public UnityEngine.UI.Text TieAS;
    public UnityEngine.UI.Text Player2AS;
    //BOX TEXT
    public UnityEngine.UI.Text Box1;
    public UnityEngine.UI.Text Box2;
    public UnityEngine.UI.Text Box3;
    public UnityEngine.UI.Text Box4;
    public UnityEngine.UI.Text Box5;
    public UnityEngine.UI.Text Box6;
    public UnityEngine.UI.Text Box7;
    public UnityEngine.UI.Text Box8;
    public UnityEngine.UI.Text Box9;
    public string CurrentPlayer; //Who's turn is it again?
    public int TimesPressed; //If it is 9 then its gameover
    public virtual void Start()
    {
        PlayerPrefs.DeleteAll();
        this.Wipe();
    }

    public virtual void Update()
    {
        this.Box1.text = PlayerPrefs.GetString("Box 1");
        this.Box2.text = PlayerPrefs.GetString("Box 2");
        this.Box3.text = PlayerPrefs.GetString("Box 3");
        this.Box4.text = PlayerPrefs.GetString("Box 4");
        this.Box5.text = PlayerPrefs.GetString("Box 5");
        this.Box6.text = PlayerPrefs.GetString("Box 6");
        this.Box7.text = PlayerPrefs.GetString("Box 7");
        this.Box8.text = PlayerPrefs.GetString("Box 8");
        this.Box9.text = PlayerPrefs.GetString("Box 9");
        this.Player1.color = Color.gray;
        this.Tie.color = Color.gray;
        this.Player2.color = Color.gray;
        this.Player1AS.color = Color.gray;
        this.TieAS.color = Color.gray;
        this.Player2AS.color = Color.gray;
        if (this.CurrentPlayer == "X")
        {
            this.Player1.color = Color.white;
            this.Player1AS.color = Color.white;
        }
        else
        {
            if (this.CurrentPlayer == "O")
            {
                this.Player2.color = Color.white;
                this.Player2AS.color = Color.white;
            }
            else
            {
                this.Player1.color = Color.white;
                this.Tie.color = Color.white;
                this.Player2.color = Color.white;
                this.Player1AS.color = Color.white;
                this.TieAS.color = Color.white;
                this.Player2AS.color = Color.white;
            }
        }
        if (Input.GetMouseButtonDown(0) && (this.CurrentPlayer == ""))
        {
            this.Wipe();
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                this.Mark();
            }
        }
    }

    public virtual void Mark()
    {
        if ((PlayerPrefs.GetString(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name) == "") && (this.CurrentPlayer != ""))
        {
            PlayerPrefs.SetString(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name, this.CurrentPlayer);
            this.TimesPressed++;
            this.Checker();
            if (this.CurrentPlayer == "X")
            {
                this.CurrentPlayer = "O";
            }
            else
            {
                if (this.CurrentPlayer == "O")
                {
                    this.CurrentPlayer = "X";
                }
            }
        }
    }

    public virtual void Wipe()
    {
        PlayerPrefs.SetString("Box 1", null);
        PlayerPrefs.SetString("Box 2", null);
        PlayerPrefs.SetString("Box 3", null);
        PlayerPrefs.SetString("Box 4", null);
        PlayerPrefs.SetString("Box 5", null);
        PlayerPrefs.SetString("Box 6", null);
        PlayerPrefs.SetString("Box 7", null);
        PlayerPrefs.SetString("Box 8", null);
        PlayerPrefs.SetString("Box 9", null);
        this.TimesPressed = 0;
        int RandoNumber = Random.Range(1, 3);
        if (RandoNumber == 1)
        {
            this.CurrentPlayer = "X";
        }
        else
        {
            if (RandoNumber == 2)
            {
                this.CurrentPlayer = "O";
            }
            else
            {
                Debug.Log("ERROR SELECTING PLAYER"); //FUCK!!!
            }
        }
    }

    public virtual void Checker()
    {
        if (((PlayerPrefs.GetString("Box 1") == PlayerPrefs.GetString("Box 2")) && (PlayerPrefs.GetString("Box 1") == PlayerPrefs.GetString("Box 3"))) && (PlayerPrefs.GetString("Box 1") != ""))
        {
            if (this.CurrentPlayer == "X")
            {
                this.Player1AS.text = (int.Parse(this.Player1AS.text) + 1).ToString();
                Debug.Log("It is the line above that doesnt work!");
            }
            else
            {
                if (this.CurrentPlayer == "O")
                {
                    this.Player2AS.text = (int.Parse(this.Player2AS.text) + 1).ToString();
                }
            }
            this.CurrentPlayer = "";
        }
        else
        {
            if (((PlayerPrefs.GetString("Box 4") == PlayerPrefs.GetString("Box 5")) && (PlayerPrefs.GetString("Box 4") == PlayerPrefs.GetString("Box 6"))) && (PlayerPrefs.GetString("Box 4") != ""))
            {
                if (this.CurrentPlayer == "X")
                {
                    this.Player1AS.text = (int.Parse(this.Player1AS.text) + 1).ToString();
                }
                else
                {
                    if (this.CurrentPlayer == "O")
                    {
                        this.Player2AS.text = (int.Parse(this.Player2AS.text) + 1).ToString();
                    }
                }
                this.CurrentPlayer = "";
            }
            else
            {
                if (((PlayerPrefs.GetString("Box 7") == PlayerPrefs.GetString("Box 8")) && (PlayerPrefs.GetString("Box 7") == PlayerPrefs.GetString("Box 9"))) && (PlayerPrefs.GetString("Box 7") != ""))
                {
                    if (this.CurrentPlayer == "X")
                    {
                        this.Player1AS.text = (int.Parse(this.Player1AS.text) + 1).ToString();
                    }
                    else
                    {
                        if (this.CurrentPlayer == "O")
                        {
                            this.Player2AS.text = (int.Parse(this.Player2AS.text) + 1).ToString();
                        }
                    }
                    this.CurrentPlayer = "";
                }
                else
                {
                    if (((PlayerPrefs.GetString("Box 1") == PlayerPrefs.GetString("Box 4")) && (PlayerPrefs.GetString("Box 1") == PlayerPrefs.GetString("Box 7"))) && (PlayerPrefs.GetString("Box 1") != ""))
                    {
                        if (this.CurrentPlayer == "X")
                        {
                            this.Player1AS.text = (int.Parse(this.Player1AS.text) + 1).ToString();
                        }
                        else
                        {
                            if (this.CurrentPlayer == "O")
                            {
                                this.Player2AS.text = (int.Parse(this.Player2AS.text) + 1).ToString();
                            }
                        }
                        this.CurrentPlayer = "";
                    }
                    else
                    {
                        if (((PlayerPrefs.GetString("Box 2") == PlayerPrefs.GetString("Box 5")) && (PlayerPrefs.GetString("Box 2") == PlayerPrefs.GetString("Box 8"))) && (PlayerPrefs.GetString("Box 2") != ""))
                        {
                            if (this.CurrentPlayer == "X")
                            {
                                this.Player1AS.text = (int.Parse(this.Player1AS.text) + 1).ToString();
                            }
                            else
                            {
                                if (this.CurrentPlayer == "O")
                                {
                                    this.Player2AS.text = (int.Parse(this.Player2AS.text) + 1).ToString();
                                }
                            }
                            this.CurrentPlayer = "";
                        }
                        else
                        {
                            if (((PlayerPrefs.GetString("Box 3") == PlayerPrefs.GetString("Box 6")) && (PlayerPrefs.GetString("Box 3") == PlayerPrefs.GetString("Box 9"))) && (PlayerPrefs.GetString("Box 3") != "")) //4 warbotz to the core 
                            {
                                if (this.CurrentPlayer == "X")
                                {
                                    this.Player1AS.text = (int.Parse(this.Player1AS.text) + 1).ToString();
                                }
                                else
                                {
                                    if (this.CurrentPlayer == "O")
                                    {
                                        this.Player2AS.text = (int.Parse(this.Player2AS.text) + 1).ToString();
                                    }
                                }
                                this.CurrentPlayer = "";
                            }
                            else
                            {
                                if (((PlayerPrefs.GetString("Box 1") == PlayerPrefs.GetString("Box 5")) && (PlayerPrefs.GetString("Box 1") == PlayerPrefs.GetString("Box 9"))) && (PlayerPrefs.GetString("Box 1") != ""))
                                {
                                    if (this.CurrentPlayer == "X")
                                    {
                                        this.Player1AS.text = (int.Parse(this.Player1AS.text) + 1).ToString();
                                    }
                                    else
                                    {
                                        if (this.CurrentPlayer == "O")
                                        {
                                            this.Player2AS.text = (int.Parse(this.Player2AS.text) + 1).ToString();
                                        }
                                    }
                                    this.CurrentPlayer = "";
                                }
                                else
                                {
                                    if (((PlayerPrefs.GetString("Box 3") == PlayerPrefs.GetString("Box 6")) && (PlayerPrefs.GetString("Box 3") == PlayerPrefs.GetString("Box 7"))) && (PlayerPrefs.GetString("Box 3") != ""))
                                    {
                                        if (this.CurrentPlayer == "X")
                                        {
                                            this.Player1AS.text = (int.Parse(this.Player1AS.text) + 1).ToString();
                                        }
                                        else
                                        {
                                            if (this.CurrentPlayer == "O")
                                            {
                                                this.Player2AS.text = (int.Parse(this.Player2AS.text) + 1).ToString();
                                            }
                                        }
                                        this.CurrentPlayer = "";
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        if ((this.TimesPressed == 9) && (this.CurrentPlayer != ""))
        {
            this.CurrentPlayer = "";
            this.TieAS.text = (int.Parse(this.TieAS.text) + 1).ToString();
        }
    }

}