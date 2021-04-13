using System.Linq;
using System.Reflection;
using UnityEngine;
namespace Items
{
    public class ItemInit
    {
        public ItemInit(Controllers controllers, Data data)
        {
            var itemSpawner = new ItemSpawner(data.Bad, data.Required);

            controllers.Add(new InputController(ItemStarter.Player));
            var itemSpawnerInit = new ItemSpawnerInit(itemSpawner,data.Bad,data.Required);
            //controllers.Add(new EndGameController(enemyInitialization.GetEnemies(), playerInitialization.GetPlayer().gameObject.GetInstanceID()));
        }
    }
}