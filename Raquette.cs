using System.Numerics;
using Raylib_cs;

namespace Breakout;

static partial class Program
{
    /// <summary>Le rectangle occupé par la raquette à l'écran.</summary>
    static Rectangle RectangleRaquette()
    {
        return new Rectangle(positionRaquette.X, positionRaquette.Y, LARGEUR_RAQUETTE, HAUTEUR_RAQUETTE);
    }

    /// <summary>Déplace la raquette avec les flèches, sans sortir de la fenêtre.</summary>
    static void DeplacerRaquette(float dt)
    {
        if (Raylib.IsKeyDown(KeyboardKey.Left))
        {
            positionRaquette.X -= VITESSE_RAQUETTE * dt;
        }

        if (Raylib.IsKeyDown(KeyboardKey.Right))
        {
            positionRaquette.X += VITESSE_RAQUETTE * dt;
        }

        if (positionRaquette.X < 0)
        {
            positionRaquette.X = 0;
        }

        if (positionRaquette.X > LARGEUR - LARGEUR_RAQUETTE)
        {
            positionRaquette.X = LARGEUR - LARGEUR_RAQUETTE;
        }
    }

    /// <summary>Fait rebondir la balle si elle touche la raquette.</summary>
    static void RebondirSurRaquette()
    {
        //les + RAYON_BALLE serve a faire en sorte que la collision sois parfaitement alligner avec la raquette mais en prennant compte de l vitesse de la balle et sa petite taille il n'est pas necesaire car invisible et sans resente different
        //if ((positionBalle.X + RAYON_BALLE >= positionRaquette.X && positionBalle.X + RAYON_BALLE <= positionRaquette.X +LARGEUR_RAQUETTE) &&
        //    (positionBalle.Y + RAYON_BALLE >= positionRaquette.Y && positionBalle.Y + RAYON_BALLE <= positionRaquette.Y +HAUTEUR_RAQUETTE))
        //    {
        //        vitesseBalle.Y = -vitesseBalle.Y;
        //    }

        if (Raylib.CheckCollisionCircleRec(positionBalle, RAYON_BALLE, RectangleRaquette()))
        {
            vitesseBalle.Y = -vitesseBalle.Y;
        }
    }
}
