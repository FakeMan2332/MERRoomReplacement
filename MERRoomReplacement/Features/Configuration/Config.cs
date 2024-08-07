using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Enums;
using Exiled.API.Interfaces;
using MERRoomReplacement.Api.Structures;

namespace MERRoomReplacement.Features.Configuration
{
    public class Config : IConfig
    {
        [Description("Indicates plugin enabled or not")]
        public bool IsEnabled { get; set; } = true;

        [Description("Indicates debug mode enabled or not")]
        public bool Debug { get; set; } = false;

        [Description("Options for replacement")]
        public List<RoomSchematic> ReplacementOptions { get; set; } = new()
        {
            new RoomSchematic()
            {
                IsEnabled = false,
                TargetRoomType = RoomType.HczTestRoom,
                SchematicName = "AwesomeSchematic",
                SpawnChance = 50,
                SpawnDelay = 1f,
                PositionOffset = new Vector3(0, 0, 0),
                RotationOffset = new Vector3(0, 0, 0)
            }
        };
    }
}