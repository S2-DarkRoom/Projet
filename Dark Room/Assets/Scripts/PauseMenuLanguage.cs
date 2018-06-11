using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuLanguage : MonoBehaviour
{
    public Text resume, menu, options, quit;
    public Text anti, lang, texture, full, apply, back, opt;
    public Dropdown L, A, V, Q;
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
            resume.text = "Reprendre";
            menu.text = "Menu Principal";
            quit.text = "Quitter le jeu";
            options.text = "Options";

            anti.text = "Anticrenelage";
            texture.text = "Qualite des texture";
            lang.text = "Langue";
            full.text = "Plein ecran";
            apply.text = "Appliquer";
            back.text = "Retour";
            opt.text = "Options";

            L.captionText.text = "Anglais";
            L.options[0].text = "Anglais";
            L.options[1].text = "Français";

            Q.captionText.text = "Haute";
            Q.options[0].text = "Haute";
            Q.options[1].text = "Moyenne";
            Q.options[2].text = "Basse";

            A.captionText.text = "Aucun";
            A.options[0].text = "Aucun";
            A.options[1].text = "Moyen";
            A.options[2].text = "Haut";

            V.captionText.text = "Ne pas synchroniser";
            V.options[0].text = "Ne pas synchroniser";
            V.options[1].text = "Synchroniser tous les V Blank";
            V.options[2].text = "Synchroniser toutes les secondes V Blank";
        }

        else
        {
            resume.text = "Resume";
            menu.text = "Main menu";
            quit.text = "Quit game";
            options.text = "Settings";

            anti.text = "Anialiasing";
            texture.text = "Texture Quality";
            lang.text = "Language";
            full.text = "Fullscreen";
            apply.text = "Apply";
            back.text = "Back";
            opt.text = "Settings";

            L.captionText.text = "English";
            L.options[0].text = "English";
            L.options[1].text = "French";

            Q.captionText.text = "High";
            Q.options[0].text = "High";
            Q.options[1].text = "Medium";
            Q.options[2].text = "Low";

            A.captionText.text = "None";
            A.options[0].text = "None";
            A.options[1].text = "Medium";
            A.options[2].text = "High";

            V.captionText.text = "Don't sync";
            V.options[0].text = "Don't sync";
            V.options[1].text = "Sync every V Blank";
            V.options[2].text = "Sync every second V Blank";
        }
    }
}
