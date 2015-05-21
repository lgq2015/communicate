﻿using System;

namespace ConnComm
{
    /// <summary>
    /// The class responsible for containing the backend information the server that dictates how the server will publish itself on the network
    /// </summary>
    public class ProtocolInfo
    {
        public const string ProtocolDomainLocal = "local";

        private string _protocolName;
        private TransportProtcolType _type;
        private string _domain;

        #region Properties

        /// <summary>
        /// The name of the type section of the service that the server will publish. It should start with an underscore and contain no spaces or full stops; e.g."_Test"
        /// </summary>
        public string ProtocolName
        {
            get { return _protocolName; }
        }

        /// <summary>
        /// The type of transport protocol that the server will publish using. It is currently limited to TCP only
        /// </summary>
        public TransportProtcolType Type
        {
            get { return _type;  }
        }

        /// <summary>
        /// The domain of the type section of the service that the server will publish. It should usuaally be left null and contain no spaces or full stops
        /// </summary>
        public string Domain
        {
            get { return _domain; }
        }

        #endregion

        /// <summary>
        /// The default constructor for the ProtocolInfo object. Example use: ProtocolInfo("_Test", TransportProtocolType.TCP, null) would publish a service under the full Bonjour type of "_Test._tcp.local."
        /// </summary>
        /// <param name="protocolName">The name of the type section of the service that the server will publish. It should start with an underscore, have no spaces and have no full stops; e.g."_Test"</param>
        /// <param name="type">The type of transport protocol that the server will publish using. It is currently limited to TCP only</param>
        /// <param name="domain">The domain of the type section of the service that the server will publish. It should usuaally be left null and contain no spaces or full stops</param>
        public ProtocolInfo(string protocolName, TransportProtcolType type, string domain)
        {
            _protocolName = protocolName;
            _type = type;
            if (domain == null)
            {
                domain = ProtocolDomainLocal;
            }
            _domain = domain;
        }

        /// <summary>
        /// Use of the empty constructor is prevented
        /// </summary>
        private ProtocolInfo()
        {

        }

        /// <summary>
        /// This overrides the ToString method of this object to give more information for debugging use
        /// </summary>
        /// <returns>The information about the server in a readable format</returns>
        public override string ToString()
        {
            return _protocolName + "._" + StringFromTransportProtocolType(_type) + "." + _domain + ".";
        }


        /// <summary>
        /// This is used to give a readable string format of the ProtocolInfo object for use as the "type" variable of a Bonjour NetService
        /// </summary>
        /// <returns>The string information of the protocol the server is published using. E.g. ProtocolInfo("_Test", TransportProtocolType.TCP, null) would publish a service under the full Bonjour type of "_Test._tcp.local."</returns>
        public string Serialize()
        {
            return _protocolName + "._" + StringFromTransportProtocolType(_type) + ".";
        }

        /// <summary>
        /// A helper method that deduces the string value of the transport protocol type of the type section of a published Bonjour NetService
        /// </summary>
        /// <param name="type">The type of TransportProtocolType that will be serialized into a string form</param>
        /// <returns>The string string value of the transport protocol type of the type section of a published Bonjour NetService</returns>
        private string StringFromTransportProtocolType(TransportProtcolType type)
        {
            string toReturn = "tcp";
            return toReturn;
        }
    }
}