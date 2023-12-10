using System;
using DeerJson;
using DeerJson.Deserializer;
using DeerJson.Deserializer.std;
using UnityEngine;

namespace Plugins.DeerJson.Deserializer.Unity
{
    public class BoundsDeserializer : JsonDeserializer<Bounds>
    {
        public override Bounds GetNullValue(DeserializeContext ctx)
        {
            return new Bounds();
        }

        public override Bounds Deserialize(JsonParser p, DeserializeContext ctx)
        {
            float centerX = 0, centerY = 0, centerZ = 0;
            float sizeX = 0, sizeY = 0, sizeZ = 0;

            p.GetObjectStart();

            string name;

            while ((name = p.GetMemberName()) != null)
            {
                switch (name)
                {
                    case "center":
                        p.GetObjectStart();
                        while ((name = p.GetMemberName()) != null)
                        {
                            switch (name)
                            {
                                case "x":
                                    centerX = Convert.ToSingle(p.GetNumber());
                                    break;
                                case "y":
                                    centerY = Convert.ToSingle(p.GetNumber());
                                    break;
                                case "z":
                                    centerZ = Convert.ToSingle(p.GetNumber());
                                    break;
                            }
                        }

                        p.GetObjectEnd();
                        break;
                    case "size":
                        p.GetObjectStart();
                        while ((name = p.GetMemberName()) != null)
                        {
                            switch (name)
                            {
                                case "x":
                                    sizeX = Convert.ToSingle(p.GetNumber());
                                    break;
                                case "y":
                                    sizeY = Convert.ToSingle(p.GetNumber());
                                    break;
                                case "z":
                                    sizeZ = Convert.ToSingle(p.GetNumber());
                                    break;
                            }
                        }

                        p.GetObjectEnd();
                        break;
                }
            }

            p.GetObjectEnd();

            return new Bounds(new Vector3(centerX, centerY, centerZ), new Vector3(sizeX, sizeY, sizeZ));
        }
    }
}