﻿using BusinessLayer.Configuration;
using NBitcoin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BusinessLayer
{
    public enum ConnectionType
    {
        Http,
        FullNode
    }

    /// <summary>
    /// This Config class stores global settings.
    /// </summary>
    public static class Config
    {
        /// Initialized with default attributes
        public static string DefaultWalletFileName = @"Wallet.json";
        public static Network Network = Network.TestNet;
        public static bool CanSpendUnconfirmed = false;
        public static ConnectionType ConnectionType = ConnectionType.Http;

        static Config()
        {
            if (!File.Exists(ConfigFileSerializer.ConfigFilePath))
            {
                Save();
                //ConfigFileSerializer.Serialize(DefaultWalletFileName, Network.ToString(), ConnectionType.ToString(), CanSpendUnconfirmed.ToString());
                //Console.WriteLine($"{ConfigFileSerializer.ConfigFilePath} was missing. It has been created created with default settings.");
            }
            Load();
        }

        /// <summary>
        /// Method
        /// </summary>
        public static void Load()
        {

        }

        /// <summary>
        /// Method
        /// </summary>
        public static void Save()
        {
            ConfigFileSerializer.Serialize(DefaultWalletFileName, Network.ToString(), ConnectionType.ToString(), CanSpendUnconfirmed.ToString());
            Load();
        }
    }
}
