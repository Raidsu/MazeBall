using System.Linq;
using System.Reflection;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Items
{
    public class ItemInit
    {
        public ItemInit(Controllers controllers, Data data)
        {
            var itemSpawner = new ItemSpawner(data.Bad, data.Required);
            controllers.Add(new InputController());
            var itemSpawnerInit = new ItemSpawnerInit(itemSpawner,data.Bad,data.Required);
            controllers.Add(new CameraShake());
            controllers.Add(new MazeRotation());
            controllers.Add(new MiniMap(Object.FindObjectOfType<MiniMapCamMarker>().transform));
            

            //controllers.Add(new EndGameController(enemyInitialization.GetEnemies(), playerInitialization.GetPlayer().gameObject.GetInstanceID()));
        }
    }
}