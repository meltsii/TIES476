using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Melto : PlayerControllerInterface
{
    int kaannos;
    int askel;
    bool kaannosOikeaan;
    // TÄMÄ TULEE TEHTÄVÄSSÄ TÄYDENTÄÄ
    // Käytä vain PlayerControllerInterfacessa olevia metodeja TIMissä olevan ohjeistuksen mukaan
    public override void DecideNextMove()
    {
        switch (GetForwardTileStatus())
        {                
            // Enintään 10 askelta eteenpäin, sitten käännytään oikealle
            // ja taas jos pääsee liikkumaan 8 askelta suoraan, käännytään vasemmalle.
            // Näin ei pitäisi jäädä jumiin.
            case 0:
                if (askel < 10)
                {
                    nextMove = MoveForward;
                    askel++;
                    break;
                }
                else if (kaannosOikeaan)
                {
                    nextMove = TurnRight;
                    kaannosOikeaan = false;
                    askel = 0;
                    break;
                }
                else if (!kaannosOikeaan)
                {
                    nextMove = TurnLeft;
                    kaannosOikeaan = true;
                    askel = 0;
                    break;
                }
                break;
            // Kaksi kertaa käännytään oikealle, sitten kaksi kertaa vasemmalle
            // Tämän jälkeen kaannos nollataan ja aloitetaan alusta
            case 1:
                if (kaannos < 2)
                {
                    nextMove = TurnRight;
                    kaannos++;
                    break;
                }
                else
                {
                    nextMove = TurnLeft;
                    kaannos++;
                    if (kaannos == 3) kaannos = 0;
                    break;
                }
            case 2:
                nextMove = Hit;
                break;
            default: nextMove = Pass;
                break;
        }
    }
}
