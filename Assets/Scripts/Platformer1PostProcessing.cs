using System.Linq;
using Edgar.Unity;

public class Platformer1PostProcessing : DungeonGeneratorPostProcessingGrid2D
{
    public override void Run(DungeonGeneratorLevelGrid2D level)
    {
        RemoveWallsFromDoors(level);
    }

    private void RemoveWallsFromDoors(DungeonGeneratorLevelGrid2D level)
    {
        // Get the tilemap that we want to delete tiles from
        var walls = level.GetSharedTilemaps().Single(x => x.name == "Walls");
        walls.tag = "Ground";

        var platforms = level.GetSharedTilemaps().Single(x => x.name == "Platforms");
        
        // Go through individual rooms
        foreach (var roomInstance in level.RoomInstances)
        {
            // Go through individual doors
            foreach (var doorInstance in roomInstance.Doors)
            {
                // Remove all the wall tiles from door positions
                foreach (var point in doorInstance.DoorLine.GetPoints())
                {
                    walls.SetTile(point + roomInstance.Position, null);
                }
            }
        }
    }
}