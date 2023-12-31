﻿using System;
using DeerJson.Deserializer;
using DeerJson.Deserializer.std;
using DeerJson.Node;
using DeerJson.Serializer;
using DeerJson.Serializer.Unity;
using Plugins.DeerJson.Deserializer.Unity;

namespace DeerJson
{
    public class JsonMapper
    {
        private readonly DeserializeContext m_deserializeContext;
        private readonly SerializeContext   m_serializeContext;
        private readonly JsonConfigure      m_configure;

        public static JsonMapper Default;

        static JsonMapper()
        {
            Default = new JsonMapper();
            Default.AddDeserializer(new BoundsDeserializer());
            Default.AddDeserializer(new Color32Deserializer());
            Default.AddDeserializer(new ColorDeserializer());
            Default.AddDeserializer(new KeyFrameDeserializer());
            Default.AddDeserializer(new QuaternionDeserializer());
            Default.AddDeserializer(new RectDeserializer());
            Default.AddDeserializer(new Vector2Deserializer());
            Default.AddDeserializer(new Vector3Deserializer());
            Default.AddDeserializer(new Vector4Deserializer());
            Default.AddSerializer(new BoundsSerializer());
            Default.AddSerializer(new Color32Serializer());
            Default.AddSerializer(new ColorSerializer());
            Default.AddSerializer(new KeyFrameSerializer());
            Default.AddSerializer(new QuaternionSerializer());
            Default.AddSerializer(new RectSerializer());
            Default.AddSerializer(new Vector2Serializer());
            Default.AddSerializer(new Vector3Serializer());
            Default.AddSerializer(new Vector4Serializer());
        }

        public JsonMapper()
        {
            m_configure = new JsonConfigure();
            m_deserializeContext = new DeserializeContext(m_configure);
            m_serializeContext = new SerializeContext(m_configure);
        }

        // Configure
        public JsonMapper Configure(JsonFeature f, bool enabled)
        {
            m_configure.Configure(f, enabled);
            return this;
        }

        public JsonMapper Enable(JsonFeature f)
        {
            m_configure.Enable(f);
            return this;
        }

        public JsonMapper Disable(JsonFeature f)
        {
            m_configure.Disable(f);
            return this;
        }

        public bool IsEnabled(JsonFeature f)
        {
            return m_configure.IsEnabled(f);
        }

        // DeSerialize
        public T ParseJson<T>(string json)
        {
            return (T)ParseJson(typeof(T), json);
        }

        private object ParseJson(Type type, string json)
        {
            var deser = m_deserializeContext.FindDeserializer(type);
            var p = new JsonParser(json);
            if (p.CurToken == TokenType.NULL)
            {
                return deser.GetNullValue(m_deserializeContext);
            }

            var res = deser.Deserialize(p, m_deserializeContext);
            if (m_configure.IsEnabled(JsonFeature.DESERIALIZE_FAIL_ON_TRAILING_TOKENS))
            {
                if (p.HasTrailingTokens())
                {
                    throw new JsonException(
                        $"Trailing token is not allowed when DESERIALIZE_FAIL_ON_TRAILING_TOKENS is enabled");
                }
            }

            return res;
        }

        // TODO: Extend feature of JsonObject
        public JsonNode ParseToTree(string json)
        {
            return ParseJson<JsonNode>(json);
        }

        // Serialize
        public string ToJson(object value)
        {
            using (var gen = new JsonGenerator())
            {
                var ser = m_serializeContext.FindSerializer(value.GetType());
                ser.Serialize(value, gen, m_serializeContext);
                return gen.GetValueAsString();
            }
        }

        // custom serializer and deserializer
        public void AddSerializer<T>(JsonSerializer<T> serializer)
        {
            m_serializeContext.AddCustomSerializer(serializer);
        }

        public void AddDeserializer<T>(JsonDeserializer<T> deserializer)
        {
            m_deserializeContext.AddCustomDeserializer(deserializer);
        }
    }
}