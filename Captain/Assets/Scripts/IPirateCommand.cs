using UnityEngine;

namespace Captain.Command
{
    public interface IPirateCommand
    {
        bool Execute(GameObject pirate, Object productPrefab);
        //to generate object, Prefab is skull/gem/mushroom
    }
}
