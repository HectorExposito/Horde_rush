using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HabilitiesSelection : MonoBehaviour
{
    const int NUMBER_OF_HABILITIES = 6;//Quantity of habilities in the game
    int[,] habilitiesActivated;//[NumberOfHability][Level]
    int[] hability;//0->Wand 1->Shuriken 2->PoisonPotion 3->IcePotion 4->Spear 5->Beam 6->PlayerWeapon
    LinkedList<int> habilitiesAlreadyChosen;//Habilities that are already chosen so they aren't shown twice on the selection panel

    int hability1Number;
    int hability2Number;
    int hability3Number;

    string hability1Tag;
    string hability2Tag;
    string hability3Tag;

    public GameObject hability1;
    public GameObject hability2;
    public GameObject hability3;

    public GameObject[] habilitiesInfo;
    void Awake()
    {
        habilitiesActivated = new int[4,2];
        hability = new int[NUMBER_OF_HABILITIES];
        habilitiesAlreadyChosen = new LinkedList<int>();
        //Fill habilitiesActivated with -1, which means it's empty
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                habilitiesActivated[i,j] = -1;
            }
        }
        //Fill hability and habilitiesToChoose with the number that correspond with each hability of the game
        for (int i = 0; i < NUMBER_OF_HABILITIES; i++)
        {
            hability[i]= i;
        }
    }

    public void chooseHabilities()
    {
        bool habilityAbleToChoose;//Show if the hability generated can be chosen or not
        //We see if all the habilities that can be activated are already activated
        if (habilitiesActivated[3,0]==-1)
        {
            Debug.Log("Entra arribaa");
            do
            {
                habilityAbleToChoose = false;

                int numberOfHability = Random.Range(0,NUMBER_OF_HABILITIES);
                //If the habilitiesAlreadyChosen doesn't contain the hability generated, we see if it's able to be chosen 
                if (!habilitiesAlreadyChosen.Contains(hability[numberOfHability]))
                {
                    int counter=0;
                    for (int i = 0; i < 4; i++)
                    {
                        //If the hability is already activated we see if it's already at the maximum level
                        if (habilitiesActivated[i, 0] == hability[numberOfHability])
                        {
                            if (habilitiesActivated[i, 1] < 5)
                            {
                                habilityAbleToChoose = true;
                            }
                        }
                        else
                        {
                            counter++;
                        }
                    }
                    //If the counter is 4 it means that the hability selected is not already activated so it can be chosen
                    if (counter == 4)
                    {
                        habilityAbleToChoose = true;
                    }
                }
                //The hability selected is added to habilitiesAlreadyChosen
                if (habilityAbleToChoose)
                {
                    habilitiesAlreadyChosen.AddLast(hability[numberOfHability]);
                }
            } while (habilitiesAlreadyChosen.Count<3);
        }
        else
        {
            int numberOfHabilitiesToUpgrade=0;//The number of habilities that can be upgraded

            for (int i = 0; i < 4; i++)
            {
                if (habilitiesActivated[i,1]<5)
                {
                    numberOfHabilitiesToUpgrade++;
                }
            }
            do
            {
                int numberOfHability = Random.Range(0, 4);
                if (habilitiesActivated[numberOfHability,1]<5)
                {
                    habilitiesAlreadyChosen.AddLast(habilitiesActivated[numberOfHability, 0]);
                }
            } while (habilitiesAlreadyChosen.Count != numberOfHabilitiesToUpgrade);
        }

        showHabilities();
    }

    private void showHabilities()
    {
        //Activate as number of panels as habilities are chosen
        switch (habilitiesAlreadyChosen.Count)
        {
            case 1:
                hability1.SetActive(true);
                hability1Number = habilitiesAlreadyChosen.First.Value;
                hability1Panel(habilitiesAlreadyChosen.First.Value);
                habilitiesAlreadyChosen.RemoveFirst();

                hability2.SetActive(false);

                hability3.SetActive(false);
                break;
            case 2:
                hability1.SetActive(true);
                hability1Number = habilitiesAlreadyChosen.First.Value;
                hability1Panel(habilitiesAlreadyChosen.First.Value);
                habilitiesAlreadyChosen.RemoveFirst();

                hability2.SetActive(true);
                hability2Number = habilitiesAlreadyChosen.First.Value;
                hability2Panel(habilitiesAlreadyChosen.First.Value);
                habilitiesAlreadyChosen.RemoveFirst();

                habilitiesAlreadyChosen.RemoveFirst();
                hability3.SetActive(false);
                break;
            case 3:
                hability1.SetActive(true);
                hability1Number = habilitiesAlreadyChosen.First.Value;
                hability1Panel(habilitiesAlreadyChosen.First.Value);
                habilitiesAlreadyChosen.RemoveFirst();

                hability2.SetActive(true);
                hability2Number = habilitiesAlreadyChosen.First.Value;
                hability2Panel(habilitiesAlreadyChosen.First.Value);
                habilitiesAlreadyChosen.RemoveFirst();

                hability3.SetActive(true);
                hability3Number = habilitiesAlreadyChosen.First.Value;
                hability3Panel(habilitiesAlreadyChosen.First.Value);
                habilitiesAlreadyChosen.RemoveFirst();
                break;
        }

    }
    private void hability1Panel(int hability)
    {
        //First, we get all the children of the panel
        Component[] c = hability1.GetComponentsInChildren<Component>();
        //Get the image of the hability
        GameObject icon=null;
        bool found=false;
        int i=0;
        do
        {
            i++;
            if (c[i].CompareTag(Tags.habilityIcon))
            {
                icon = c[i].gameObject;
                found = true;
            }
        } while (!found);

        icon.GetComponent<Image>().sprite = habilitiesInfo[hability].GetComponent<SpriteRenderer>().sprite;
        //Get the name of the hability
        GameObject name = null;
        found = false;
        i = 0;
        do
        {
            i++;
            if (c[i].CompareTag(Tags.habilityName))
            {
                
                name = c[i].gameObject;
                found = true;
            }
        } while (!found);
        hability1Tag = habilitiesInfo[hability].GetComponent<Habilities>().GetName();
        name.GetComponent<TMP_Text>().text = hability1Tag;
        //Get the description
        GameObject description = null;
        found = false;
        i = 0;
        do
        {
            i++;
            if (c[i].CompareTag(Tags.habilityDescription))
            {
                
                description = c[i].gameObject;
                found = true;
            }
        } while (!found);
        description.GetComponent<TMP_Text>().text = habilitiesInfo[hability].GetComponent<Habilities>().GetDescription(hability);
    }
    private void hability2Panel(int hability)
    {
        Component[] c = hability2.GetComponentsInChildren<Component>();
        GameObject icon = null;
        bool found = false;
        int i = 0;
        do
        {
            i++;
            if (c[i].CompareTag(Tags.habilityIcon))
            {
                icon = c[i].gameObject;
                found = true;
            }
        } while (!found);

        icon.GetComponent<Image>().sprite = habilitiesInfo[hability].GetComponent<SpriteRenderer>().sprite;

        GameObject name = null;
        found = false;
        i = 0;
        do
        {
            i++;
            if (c[i].CompareTag(Tags.habilityName))
            {
                name = c[i].gameObject;
                found = true;
            }
        } while (!found);
        hability2Tag = habilitiesInfo[hability].GetComponent<Habilities>().GetName();
        name.GetComponent<TMP_Text>().text = hability2Tag;

        GameObject description = null;
        found = false;
        i = 0;
        do
        {
            i++;
            if (c[i].CompareTag(Tags.habilityDescription))
            {
                description = c[i].gameObject;
                found = true;
            }
        } while (!found);
        description.GetComponent<TMP_Text>().text = habilitiesInfo[hability].GetComponent<Habilities>().GetDescription(hability);
    }

    private void hability3Panel(int hability)
    {
        Component[] c = hability3.GetComponentsInChildren<Component>();
        GameObject icon = null;
        bool found = false;
        int i = 0;
        do
        {
            i++;
            if (c[i].CompareTag(Tags.habilityIcon))
            {
                icon = c[i].gameObject;
                found = true;
            }
        } while (!found);

        icon.GetComponent<Image>().sprite = habilitiesInfo[hability].GetComponent<SpriteRenderer>().sprite;

        GameObject name = null;
        found = false;
        i = 0;
        do
        {
            i++;
            if (c[i].CompareTag(Tags.habilityName))
            {
                name = c[i].gameObject;
                found = true;
            }
        } while (!found);
        hability3Tag = habilitiesInfo[hability].GetComponent<Habilities>().GetName();
        name.GetComponent<TMP_Text>().text = hability3Tag;

        GameObject description = null;
        found = false;
        i = 0;
        do
        {
            i++;
            if (c[i].CompareTag(Tags.habilityDescription))
            {
                description = c[i].gameObject;
                found = true;
            }
        } while (!found);
        description.GetComponent<TMP_Text>().text = habilitiesInfo[hability].GetComponent<Habilities>().GetDescription(hability);
    }

    public void hability1Button()
    {
        bool found = false;
        int i = 0;
        do
        {
            if (habilitiesActivated[i, 0] == -1)
            {
                habilitiesActivated[i, 0] = hability1Number;
                if (habilitiesActivated[i, 1] == -1)
                {
                    habilitiesActivated[i, 1] = 1;
                }
                else
                {
                    habilitiesActivated[i, 1]++;
                }
                found = true;
            }
            i++;
        } while (!found);
            
        FindObjectOfType<PlayerManager>().ActivateHability(hability1Tag);
        FindObjectOfType<LevelManager>().unpauseGame();
        this.gameObject.SetActive(false);
    }
    public void hability2Button()
    {
        bool found = false;
        int i = 0;
        do
        {
            if (habilitiesActivated[i, 0] == -1)
            {
                habilitiesActivated[i, 0] = hability2Number;
                if (habilitiesActivated[i, 1] == -1)
                {
                    habilitiesActivated[i, 1] = 1;
                }
                else
                {
                    habilitiesActivated[i, 1]++;
                }
                found = true;
            }
            i++;
        } while (!found);

        FindObjectOfType<PlayerManager>().ActivateHability(hability2Tag);
        FindObjectOfType<LevelManager>().unpauseGame();
        this.gameObject.SetActive(false);
    }
    public void hability3Button()
    {
        bool found = false;
        int i = 0;
        do
        {
            if (habilitiesActivated[i, 0] == -1)
            {
                habilitiesActivated[i, 0] = hability3Number;
                if (habilitiesActivated[i, 1] == -1)
                {
                    habilitiesActivated[i, 1] = 1;
                }
                else
                {
                    habilitiesActivated[i, 1]++;
                }
                found = true;
            }
            i++;
        } while (!found);

        FindObjectOfType<PlayerManager>().ActivateHability(hability3Tag);
        FindObjectOfType<LevelManager>().unpauseGame();
        this.gameObject.SetActive(false);
    }
}
