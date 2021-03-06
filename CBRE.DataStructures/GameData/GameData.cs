﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Reflection;

namespace CBRE.DataStructures.GameData {
    public class GameData {
        public int MapSizeLow { get; set; }
        public int MapSizeHigh { get; set; }
        public List<GameDataObject> Classes { get; private set; }
        public List<string> Includes { get; private set; }
        public List<string> MaterialExclusions { get; private set; }
        public List<AutoVisgroupSection> AutoVisgroups { get; private set; }

        public GameData() {
            MapSizeHigh = 16384;
            MapSizeLow = -16384;
            Classes = new List<GameDataObject>();

            IEnumerable<string> jsonFiles = Directory.EnumerateFiles("Entities", "*.json");
            foreach(string jsonFile in jsonFiles) {
                string jsonContent = File.ReadAllText(jsonFile);
                JsonGameDataObj gDataObj = JsonConvert.DeserializeObject<JsonGameDataObj>(jsonContent);

                var gameDataObj = new GameDataObject(gDataObj.Name, gDataObj.Description, ClassType.Point, true);

                foreach(JsonGDProperty property in gDataObj.Properties) {
                    if (!Enum.TryParse(property.Type, out VariableType varType)) continue;

                    Property actualProperty = new Property(property.Name, varType) {
                        ShortDescription = property.ShortDescription,
                        DefaultValue = property.DefaultValue
                    };

                    gameDataObj.Properties.Add(actualProperty);
                }
                gameDataObj.Behaviours.Add(new Behaviour("sprite", gDataObj.Sprite));
                Classes.Add(gameDataObj);
            }

            var lightDataObj = new GameDataObject("light", "Point light source.", ClassType.Point);
            lightDataObj.Properties.Add(new Property("color", VariableType.Color255) { ShortDescription = "Color", DefaultValue = "255 255 255" });
            lightDataObj.Properties.Add(new Property("intensity", VariableType.Float) { ShortDescription = "Intensity", DefaultValue = "1.0" });
            lightDataObj.Properties.Add(new Property("range", VariableType.Float) { ShortDescription = "Range", DefaultValue = "1.0" });
            lightDataObj.Properties.Add(new Property("hassprite", VariableType.Bool) { ShortDescription = "Has sprite", DefaultValue = "Yes" });
            lightDataObj.Behaviours.Add(new Behaviour("sprite", "sprites/lightbulb.spr"));
            Classes.Add(lightDataObj);

            var spotlightDataObj = new GameDataObject("spotlight", "Self-explanatory.", ClassType.Point);
            spotlightDataObj.Properties.Add(new Property("color", VariableType.Color255) { ShortDescription = "Color", DefaultValue = "255 255 255" });
            spotlightDataObj.Properties.Add(new Property("intensity", VariableType.Float) { ShortDescription = "Intensity", DefaultValue = "1.0" });
            spotlightDataObj.Properties.Add(new Property("range", VariableType.Float) { ShortDescription = "Range", DefaultValue = "1.0" });
            spotlightDataObj.Properties.Add(new Property("hassprite", VariableType.Bool) { ShortDescription = "Has sprite", DefaultValue = "Yes" });
            spotlightDataObj.Properties.Add(new Property("innerconeangle", VariableType.Float) { ShortDescription = "Inner cone angle", DefaultValue = "45" });
            spotlightDataObj.Properties.Add(new Property("outerconeangle", VariableType.Float) { ShortDescription = "Outer cone angle", DefaultValue = "90" });
            spotlightDataObj.Properties.Add(new Property("angles", VariableType.Vector) { ShortDescription = "Rotation", DefaultValue = "0 0 0" });
            Classes.Add(spotlightDataObj);

            var waypointDataObj = new GameDataObject("waypoint", "AI waypoint.", ClassType.Point);
            waypointDataObj.Behaviours.Add(new Behaviour("sprite", "sprites/waypoint"));
            Classes.Add(waypointDataObj);

            var soundEmitterDataObj = new GameDataObject("soundemitter", "Self-explanatory.", ClassType.Point);
            soundEmitterDataObj.Properties.Add(new Property("sound", VariableType.Integer) { ShortDescription = "Ambience index", DefaultValue = "1" });
            soundEmitterDataObj.Behaviours.Add(new Behaviour("sprite", "sprites/speaker.spr"));
            Classes.Add(soundEmitterDataObj);

            var modelDataObj = new GameDataObject("model", "Self-explanatory.", ClassType.Point);
            modelDataObj.Properties.Add(new Property("file", VariableType.String) { ShortDescription = "File", DefaultValue = "" });
            modelDataObj.Properties.Add(new Property("angles", VariableType.Vector) { ShortDescription = "Rotation", DefaultValue = "0 0 0" });
            modelDataObj.Properties.Add(new Property("scale", VariableType.Vector) { ShortDescription = "Scale", DefaultValue = "1 1 1" });
            Classes.Add(modelDataObj);

            var screenDataObj = new GameDataObject("screen", "Savescreen.", ClassType.Point);
            screenDataObj.Properties.Add(new Property("imgpath", VariableType.String) { ShortDescription = "Image Path", DefaultValue = "" });
            screenDataObj.Behaviours.Add(new Behaviour("sprite", "sprites/screen"));
            Classes.Add(screenDataObj);

            var noShadowObj = new GameDataObject("noshadow", "Disables shadow casting for this brush.", ClassType.Solid);
            Classes.Add(noShadowObj);

            Property p = new Property("position", VariableType.Vector) { ShortDescription = "Position", DefaultValue = "0 0 0" };
            foreach (GameDataObject gdo in Classes) {
                if (gdo.ClassType != ClassType.Solid) {
                    gdo.Properties.Add(p);
                }
            }

            Includes = new List<string>();
            MaterialExclusions = new List<string>();
            AutoVisgroups = new List<AutoVisgroupSection>();
        }

        public void CreateDependencies() {
            var resolved = new List<string>();
            var unresolved = new List<GameDataObject>(Classes);
            while (unresolved.Any()) {
                var resolve = unresolved.Where(x => x.BaseClasses.All(resolved.Contains)).ToList();
                if (!resolve.Any()) throw new Exception("Circular dependencies: " + String.Join(", ", unresolved.Select(x => x.Name)));
                resolve.ForEach(x => x.Inherit(Classes.Where(y => x.BaseClasses.Contains(y.Name))));
                unresolved.RemoveAll(resolve.Contains);
                resolved.AddRange(resolve.Select(x => x.Name));
            }
        }

        public void RemoveDuplicates() {
            foreach (var g in Classes.Where(x => x.ClassType != ClassType.Base).GroupBy(x => x.Name.ToLowerInvariant()).Where(g => g.Count() > 1).ToList()) {
                foreach (var obj in g.Skip(1)) Classes.Remove(obj);
            }
        }
    }
}
