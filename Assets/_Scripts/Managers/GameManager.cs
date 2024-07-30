using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : StaticInstance<GameManager>
{

    void Start()
    {
<<<<<<< HEAD
        GuController guController=GuManager.Instance.CreateGu();
     //   inputReader.guController = guController;
=======
        IGu parent1 = GuManager.Instance.CreateGu();
        IGu parent2 = GuManager.Instance.CreateGu();
        GuManager.Instance.BreedGu(parent1, parent2);
>>>>>>> c3e5728 (chore: commit before rebase)
    }
}