using Raylib_cs;
using System.Numerics;

namespace Breakout;

static partial class Program
{
    const int TAILLE_TEXTE = 20;
    const int TAILLE_TITRE = 40;

    /// <summary>Dessine les briques, la raquette, la balle, le score et les vies.</summary>
    static void DessinerJeu()
    {
        DessinerBriques();
        Raylib.DrawRectangleRec(RectangleRaquette(), Color.White);
        Raylib.DrawCircleV(positionBalle, RAYON_BALLE, Color.White);

        Raylib.DrawText($"Score : {score}", 10, 20, TAILLE_TEXTE, Color.White);
        string texteVies = $"Vies : {vies}";
        int largeurTexteVies = Raylib.MeasureText(texteVies, TAILLE_TEXTE);
        Raylib.DrawText(texteVies, LARGEUR - largeurTexteVies - 10, 20, TAILLE_TEXTE, Color.White);

        if (etat == EtatJeu.Attente)
        {
            DessinerTexteCentre("Espace pour lancer la balle", HAUTEUR / 2 + 60, TAILLE_TEXTE, Color.Gray);
        }
    }

    /// <summary>Affiche le message de fin de partie.</summary>
    static void DessinerFin()
    {
        string titre = etat == EtatJeu.Gagne ? "GAGNE !" : "PERDU";
        DessinerTexteCentre(titre, HAUTEUR / 2 - 20, TAILLE_TITRE, Color.White);
        DessinerTexteCentre("Espace pour rejouer", HAUTEUR / 2 + 30, TAILLE_TEXTE, Color.Gray);
    }

    /// <summary>Dessine un texte centré horizontalement dans la fenêtre.</summary>
    static void DessinerTexteCentre(string texte, int y, int taille, Color couleur)
    {
        int largeurTexte = Raylib.MeasureText(texte, taille);
        Raylib.DrawText(texte, (LARGEUR - largeurTexte) / 2, y, taille, couleur);
    }
}
