﻿using CBRE.Common;
using CBRE.DataStructures.Geometric;
using CBRE.DataStructures.MapObjects;
using CBRE.DataStructures.Transformations;
using CBRE.Extensions;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;

namespace CBRE.Providers.Map {
    public class MSL2Provider : MapProvider {
        protected override DataStructures.MapObjects.Map GetFromFile(string filename) {
            using (var strm = new FileStream(filename, FileMode.Open, FileAccess.Read)) {
                return GetFromStream(strm);
            }
        }

        protected override void SaveToFile(string filename, DataStructures.MapObjects.Map map) {
            using (var strm = new FileStream(filename, FileMode.Create, FileAccess.Write)) {
                SaveToStream(strm, map);
            }
        }

        protected override bool IsValidForFileName(string filename) {
            return filename.EndsWith(".msl", StringComparison.OrdinalIgnoreCase);
        }

        class NormalEq : EqualityComparer<CoordinateF> {
            public override bool Equals(CoordinateF x, CoordinateF y) {
                return x.Dot(y) >= 0.9f;
            }

            public override int GetHashCode(CoordinateF obj) {
                return obj.GetHashCode();
            }
        }

        protected void ReadMemblockMesh(BinaryReader br, DataStructures.MapObjects.Map map, List<Face> faces=null) {
            UInt32 memblockSize = br.ReadUInt32();
            long startPos = br.BaseStream.Position;
            Console.WriteLine("memblockSize: " + memblockSize);

            UInt32 dwFVF = br.ReadUInt32();
            UInt32 dwFVFSize = br.ReadUInt32();
            UInt32 dwVertMax = br.ReadUInt32();
            Console.WriteLine($"dwFVF: {dwFVF}; dwFVFSize: {dwFVFSize}; dwVertMax: {dwVertMax}");

            List<CoordinateF> vertexPositions = new List<CoordinateF>();
            List<CoordinateF> vertexNormals = new List<CoordinateF>();
            for (int i=0;i<dwVertMax;i++) {
                float x = br.ReadSingle();
                float y = br.ReadSingle();
                float z = br.ReadSingle();
                vertexPositions.Add(new CoordinateF(x, y, z));
                float nx = br.ReadSingle();
                float ny = br.ReadSingle();
                float nz = br.ReadSingle();
                vertexNormals.Add(new CoordinateF(nx, ny, nz).Normalise());
                for (int j=24;j<dwFVFSize;j+=4) {
                    Console.WriteLine("skipped vertex property " + j + ": " + br.ReadSingle());
                }
            }

            if (faces != null) {
                foreach (var normal in vertexNormals.Distinct(new NormalEq())) {
                    if (normal.LengthSquared() < 0.01f) { continue; }
                    Face newFace = new Face(map.IDGenerator.GetNextFaceID());
                    for (int i = 0; i < vertexPositions.Count; i++) {
                        if (vertexNormals[i].Dot(normal) < 0.9f) { continue; }
                        if (newFace.Vertices.Any(v => (new CoordinateF(v.Location)-vertexPositions[i]).LengthSquared()<0.001f)) { continue; }
                        newFace.Vertices.Add(new Vertex(new Coordinate(vertexPositions[i]), newFace));
                    }

                    newFace.Plane = new Plane(new Coordinate(normal), newFace.Vertices[0].Location);

                    Vertex center = newFace.Vertices[0];
                    newFace.Vertices.RemoveAt(0);

                    newFace.Vertices.Sort((v1, v2) => {
                        float dot = normal.Dot(new CoordinateF((v1.Location - center.Location).Cross(v2.Location - center.Location)));
                        if (dot < 0.0f) { return -1; }
                        else if (dot > 0.0f) { return 1; }
                        return 0;
                    });

                    newFace.Vertices.Insert(0, center);

                    newFace.UpdateBoundingBox();

                    faces.Add(newFace);
                }
            }

            br.BaseStream.Position = startPos + (long)memblockSize;
        }

        protected override DataStructures.MapObjects.Map GetFromStream(Stream stream) {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            var map = new DataStructures.MapObjects.Map();
            map.CordonBounds = new Box(Coordinate.One * -16384, Coordinate.One * 16384);
            BinaryReader br = new BinaryReader(stream);

            //header
            float unknown0 = br.ReadSingle();
            Console.WriteLine("unknown0: " + unknown0);
            int entityCount = (int)br.ReadSingle() - 2;
            Console.WriteLine("entityCount: " + entityCount);
            for (int i=0;i<entityCount;i++) {
                int meshCount = (int)br.ReadSingle();
                Console.WriteLine("**** meshCount: " + meshCount);
                List<Face> faces = new List<Face>();
                for (int j=0;j<meshCount;j++) {
                    float unknown1 = br.ReadSingle();
                    Console.WriteLine("unknown1: "+unknown1);
                    ReadMemblockMesh(br, map, faces);
                }

                if (faces.Any()) {
                    Solid newSolid = new Solid(map.IDGenerator.GetNextObjectID());
                    foreach (Face face in faces) {
                        face.Parent = newSolid;
                        newSolid.Faces.Add(face);
                    }
                    newSolid.Colour = Colour.GetRandomBrushColour();
                    newSolid.UpdateBoundingBox();

                    MapObject parent = map.WorldSpawn;

                    newSolid.SetParent(parent);

                    newSolid.Transform(new UnitScale(Coordinate.One, newSolid.BoundingBox.Center), TransformFlags.None);
                }

                bool isBrush = br.ReadSingle() != 0;
                Console.WriteLine("isBrush: " + isBrush);
                if (isBrush) {
                    ReadMemblockMesh(br, map);
                    for (int j = 0; j < 25; j++) {
                        float skip = br.ReadSingle();
                        Console.WriteLine("skip " + j + ": " + skip);
                    }
                    for (int j = 0; j < meshCount; j++) {
                        string textureName = br.ReadLine();
                        Console.WriteLine("textureName: " + textureName);
                        for (int k = 0; k < 10; k++) {
                            float skip2 = br.ReadSingle();
                            Console.WriteLine("skip2 " + k + ": " + skip2);
                        }
                    }
                } else {
                    for (int j = 0; j < 35; j++) {
                        float skip = br.ReadSingle();
                        Console.WriteLine("skip " + j + ": " + skip);
                    }
                    string entityName = br.ReadLine();
                    string entityIcon = br.ReadLine();
                    int propertyCount = (int)br.ReadSingle() + 1;
                    for (int j=0;j<propertyCount;j++) {
                        string propertyName = br.ReadLine();
                        string propertyValue = br.ReadLine();
                        Console.WriteLine(propertyName + ": " + propertyValue);
                    }
                }
            }

            return map;
        }

        protected override void SaveToStream(Stream stream, DataStructures.MapObjects.Map map) {
            throw new NotImplementedException("don't save to msl, ew");
        }

        protected override IEnumerable<MapFeature> GetFormatFeatures() {
            return new[]
            {
                MapFeature.Worldspawn,
                MapFeature.Solids,
                MapFeature.Entities
            };
        }
    }
}
