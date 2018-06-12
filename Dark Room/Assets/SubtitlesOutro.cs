using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubtitlesOutro : MonoBehaviour
{
    public Text s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14;
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
            s1.text = "Je te félicite d’être arrivée si loin.";
            s2.text = "J’admets t’avoir sous-estimée.";
            s3.text = "Maintenant, il est temps de te raconter la vraie raison de ta présence ici.";
            s4.text = "Jennefer Lloyd, te voici, il y a 12 ans.";
            s5.text = "Attends, la prochaine photo devrait être plus appropriée.";
            s6.text = "Peut-être n’as-tu l’impression de ne rien mériter de tout ce qu'il t'arrive. Alors voici un petit quelque chose pour te rafraichir la mémoire.";
            s7.text = "Aujourd’hui nous sommes le 14 juin, tout juste 10 ans après ton crime. ";
            s8.text = "Il faut croire que je suis meilleur que toi quand il s’agit de cacher ses traces, Jennefer.";
            s9.text = "Mon nom est Zachary Harrington. Sam était mon petit frère, que tu as tué froidement.";
            s10.text = "Et je lui rends justice, aujourd’hui, les jours qui l’ont précédé, et les jours qui suivront.";
            s11.text = "Non ! S’il vous plait ! Je n’ai rien fait, je … je ne me souviens de rien.";
            s12.text = "Ce n’était pas moi ! Pitié, ne me tuez pas.";
            s13.text = "Laissez-moi partir, cela a assez duré…";
            s14.text = "Te tuer ? Ca serait trop simple?";
        }

        else
        {
            s1.text = "Congratulations for going this far.";
            s2.text = "I admit that I may have underastimated you.";
            s3.text = "Now is the time to tell you the real reason behind your presence here." ;
            s4.text = "Jennefer Lloyd, this is you, 12 years ago.";
            s5.text = "But wait !The next one should be more accurate.";
            s6.text = "You may still feel like you don't deserve anything that's happening to you. So here is a little something to refresh your mind.";
            s7.text = "Today is the 14th of June, 10 years after your crime. ";
            s8.text = "It looks like I'm better than you when it comes to hiding my traces, Jennefer. ";
            s9.text = "My name is Zacchary Harrington. Sam was my little brother, who you killed heartlessly. ";
            s10.text = "And I provide justice for him, today, the days that preceded and the days that will come.";
            s11.text = "No ! please ! I didn't do it, I... I don't remember anything about it.";
            s12.text = "It can't be me ! It wasn't me ! Please, don't kill me ! ";
            s13.text = "Let me go, it has gone on long enough... ";
            s14.text = "Kill you? It would be too easy...";
        }
    }
}
