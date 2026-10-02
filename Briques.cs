using Raylib_cs;

namespace Breakout;

static partial class Program
{
    /// <summary>Le rectangle occupé à l'écran par la brique (ligne, colonne).</summary>
    static Rectangle RectangleBrique(int ligne, int colonne)
    {
        float x = ESPACE_BRIQUES + colonne * (LARGEUR_BRIQUE + ESPACE_BRIQUES);
        float y = MARGE_HAUT_BRIQUES + ligne * (HAUTEUR_BRIQUE + ESPACE_BRIQUES);

        return new Rectangle(x, y, LARGEUR_BRIQUE, HAUTEUR_BRIQUE);

    }

    /// <summary>Casse la brique touchée par la balle, fait rebondir la balle et ajoute les points.</summary>
    static void CasserBriques()
    {
        for (int ligne = 0; ligne < LIGNES_BRIQUES; ligne++)
        {
            for (int colonne = 0; colonne < COLONNES_BRIQUES; colonne++)
            {
                if (briques[ligne, colonne] && Raylib.CheckCollisionCircleRec(positionBalle, RAYON_BALLE, RectangleBrique(ligne, colonne)))
                {
                    vitesseBalle.Y = -vitesseBalle.Y;
                    score += POINTS_PAR_BRIQUE;
                    briques[ligne, colonne] = false;

                    return;
                }
            }
        }
    }

    /// <summary>Le nombre de briques encore présentes.</summary>
    static int CompterBriques(int presente)
    {
        return 0;
    }

    /// <summary>Dessine les briques encore présentes, une couleur par ligne.</summary>
    static void DessinerBriques()
    {
        for (int ligne = 0; ligne < LIGNES_BRIQUES; ligne++)
        {
            for (int colonne = 0; colonne < COLONNES_BRIQUES; colonne++)
            {
                if (briques[ligne, colonne])
                {
                    Raylib.DrawRectangleRec(RectangleBrique(ligne, colonne), couleursLignes[ligne]);
                }
            }
        }
    }
}
