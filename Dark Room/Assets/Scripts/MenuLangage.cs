using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuLangage : MonoBehaviour
{
    public Text solo, explore, quit, options, multi;
    public Text anti, lang, texture, full, apply, back, opt;
    public GameObject Lfr, Len, Qfr, Qen, Afr, Aen, Vfr, Ven;
    bool FR = true, n = true;

    public void Update()
    {
        FR = FindObjectOfType<SettingsManager>().FR;
        if (FR != n)
            Change();
    }

    public void Change()
    {
        n = FR;

        if (FR)
        {
            solo.text = "Jouer";
            explore.text = "Explorer";
            quit.text = "Quitter le jeu";
            options.text = "Options";
            multi.text = "Multijoueur";

            anti.text = "Anticrenelage";
            texture.text = "Qualite des texture";
            lang.text = "Langue";
            full.text = "Plein ecran";
            apply.text = "Appliquer";
            back.text = "Retour";
            opt.text = "Options";

            Len.SetActive(false);
            Qen.SetActive(false);
            Aen.SetActive(false);
            Ven.SetActive(false);

            Lfr.SetActive(true);
            Qfr.SetActive(true);
            Afr.SetActive(true);
            Vfr.SetActive(true);
        }

        else
        {
            solo.text = "Play";
            explore.text = "Explore";
            quit.text = "Quit game";
            options.text = "Settings";
            multi.text = "Multiplayer";

            anti.text = "Anialiasing";
            texture.text = "Texture Quality";
            lang.text = "Language";
            full.text = "Fullscreen";
            apply.text = "Apply";
            back.text = "Back";
            opt.text = "Settings";

            Lfr.SetActive(false);
            Qfr.SetActive(false);
            Afr.SetActive(false);
            Vfr.SetActive(false);

            Len.SetActive(true);
            Qen.SetActive(true);
            Aen.SetActive(true);
            Ven.SetActive(true);
        }
    }
}
