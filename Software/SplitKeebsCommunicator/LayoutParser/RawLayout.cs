﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var rawLayout = RawLayout.FromJson(jsonString);

using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LayoutParser
{
    public class RawLayoutClass
    {
        [JsonProperty("x", NullValueHandling = NullValueHandling.Ignore)]
        public double? X { get; set; }

        [JsonProperty("y", NullValueHandling = NullValueHandling.Ignore)]
        public double? Y { get; set; }

        [JsonProperty("w", NullValueHandling = NullValueHandling.Ignore)]
        public double? W { get; set; }

        [JsonProperty("h", NullValueHandling = NullValueHandling.Ignore)]
        public long? H { get; set; }

        [JsonProperty("a", NullValueHandling = NullValueHandling.Ignore)]
        public long? A { get; set; }
    }

    public struct RawLayoutElement
    {
        public RawLayoutClass RawLayoutClass;
        public string         String;

        public static implicit operator RawLayoutElement(RawLayoutClass RawLayoutClass)
        {
            return new RawLayoutElement {RawLayoutClass = RawLayoutClass};
        }

        public static implicit operator RawLayoutElement(string String)
        {
            return new RawLayoutElement {String = String};
        }
    }

    public class RawLayout
    {
        public static List<List<RawLayoutElement>> FromJson(string json)
        {
            return JsonConvert.DeserializeObject<List<List<RawLayoutElement>>>(json, Converter.Settings);
        }
    }

    public static class Serialize
    {
        public static string ToJson(this List<List<RawLayoutElement>> self)
        {
            return JsonConvert.SerializeObject(self, Converter.Settings);
        }
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling        = DateParseHandling.None,
            Converters =
            {
                RawLayoutElementConverter.Singleton,
                new IsoDateTimeConverter {DateTimeStyles = DateTimeStyles.AssumeUniversal}
            }
        };
    }

    internal class RawLayoutElementConverter : JsonConverter
    {
        public static readonly RawLayoutElementConverter Singleton = new RawLayoutElementConverter();

        public override bool CanConvert(Type t)
        {
            return t == typeof(RawLayoutElement) || t == typeof(RawLayoutElement?);
        }

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new RawLayoutElement {String = stringValue};
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<RawLayoutClass>(reader);
                    return new RawLayoutElement {RawLayoutClass = objectValue};
            }

            throw new Exception("Cannot unmarshal type RawLayoutElement");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (RawLayoutElement) untypedValue;
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }

            if (value.RawLayoutClass != null)
            {
                serializer.Serialize(writer, value.RawLayoutClass);
                return;
            }

            throw new Exception("Cannot marshal type RawLayoutElement");
        }
    }
}