using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubtitlesLanguage : MonoBehaviour
{
    public Text s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13;
    private bool FR = true, n = true;

    public void Start()
    {
        FR = FindObjectOfType<SettingsManager>();
        if (FR != n)
            Change();
    }

    public void Update()
    {
        FR = FindObjectOfType<SettingsManager>();
        if (FR != n)
            Change();
    }

    public void Change()
    {
        n = FR;
        if (FR)
        {
            s1.text = "Que se passe-t-il...  Où suis-je ?";
            s2.text = "Enfin tu te réveilles, Jennefer. Juste pour l'heure du déjeuner.";
            s3.text = "Qu'est-ce que c'est ? Qui êtes-vous ? Comment connaissez-vous mon nom ? Et diantre, où suis-je ? Et où êtes-vous ?";
            s4.text = "Shhh. Tu verras, dans quelques minutes tu poseras moins de questions.";
            s5.text = "Premièrement, bienvenue. Ici est mon sanctuaire.";
            s6.text = "Je vais te faire l'honneur de répondre à certaines de tes questions.";
            s7.text = "Je t'ai préparé quelques cadeaux. Le premier est une perte de mémoire que tu devrais déjà avoir remarqué.";
            s8.text = "C'est pourquoi tu ne te souviens pas de combien tu m'as fait souffrir.";
            s9.text = "Le second est cet endroit. Et il est temps pour toi de payer pour tes actions.";
            s10.text = "Tu n'as qu'une heure pour quitter cet endroit.";
            s11.text = "Tu vas devoir trouver des indices et résoudre des énigmes que j'ai moi-même créées afin de sortir de ces pièces.";
            s12.text = "Et si tu n'y arrives pas à temps... Eh bien... Tu verras. Bonne chance, et peut-être te reverrai-je dans une heure.";
            s13.text = "Jennefer, jouons à un petit jeu.";
        }

        else
        {
            s1.text = "What the hell... Where am I ?";
            s2.text = "Finally you wake up, Jennefer. Just for lunch time.";
            s3.text = "What's this ? Who are you ? How do you know my name ? And bloody hell, where am I ? And where are you ?";
            s4.text = "Shhh. You'll see, in a few minutes you will be less willing to ask questions. ";
            s5.text = "First, welcome, here is my sanctuary.";
            s6.text = "I'll give you the honnor to answer some of your question.";
            s7.text = "I prepared you some little gifts. The first one is this loss of memory you may already have noticed.";
            s8.text = "That's why you can't remember how much you made me suffer.";
            s9.text = "The second one is this room, and this is time for you to pay back for your actions.";
            s10.text = "You have only one hour to leave this place.";
            s11.text = "You will have to find some clues and resolve some enigmas of my own creation in order to progress in these rooms.";
            s12.text = "And if you can't make it in time... Well... You will see. Good luck, and maybe see you in an hour.";
            s13.text = "Jennefer, let's play a little game.";
        }
    }
}
