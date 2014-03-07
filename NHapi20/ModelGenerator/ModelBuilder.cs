using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Microsoft.Test.CommandLineParsing;
using NHapi.Base.SourceGeneration;

namespace ModelGenerator
{
    public class ModelBuilder : Command
    {
        public enum MessageType
        {
            All,
            Message,
            Segment,
            DataType,
            EventMapping
        }
        public ModelBuilder()
        {
            BasePath = @"D:\projects\nhapi\SourceForge\nhapi20";
            ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            MessageTypeToBuild = MessageType.All;
        }
        
        public string BasePath
        {
            get; set;
        }

        public string Version
        {
            get; set;
        }

        public string ConnectionString
        {
            get; set;
        }

        public MessageType MessageTypeToBuild
        {
            get; set;
        }

        public override void Execute()
        {
            NHapi.Base.NormativeDatabase.Instance.OpenNewConnection(ConnectionString);



            Console.WriteLine("Using Database:{0}", NHapi.Base.NormativeDatabase.Instance.Connection.ConnectionString);
            Console.WriteLine("Base Path:{0}", BasePath);
            

            switch (MessageTypeToBuild)
            {
                case MessageType.All:
                    SourceGenerator.makeAll(BasePath, Version);
                    break;
                case MessageType.EventMapping:
                    SourceGenerator.MakeEventMapping(BasePath, Version);
                    break;
                case MessageType.Segment:
                    SegmentGenerator.makeAll(BasePath, Version);
                    break;
                case MessageType.Message:
                    MessageGenerator.makeAll(BasePath, Version);
                    break;
            }
        }
    }
}
