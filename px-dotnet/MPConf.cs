﻿using MercadoPago;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace MercadoPago
{
    public class MPConf
    {
        #region Variables
        private const string DEFAULT_BASE_URL = "https://api.mercadopago.com";
        #endregion

        /// <summary>
        /// Property that represent the access token.
        /// </summary>
        public static string UserAccessToken { get; set; }

        /// <summary>
        /// Property that represent the refresh token.
        /// </summary>
        public static string RefreshToken { get; set; }

        /// <summary>  
        ///  Property that represent the client secret token.
        /// </summary>
        public static string ClientSecret
        {
            get
            {
                return _clientSecret;
            }
            set
            {
                if (!string.IsNullOrEmpty(_clientSecret))
                {
                    throw new MPConfException("clientSecret setting can not be changed");
                }
                _clientSecret = value;
            }
        }
        static string _clientSecret = null;

        /// <summary>
        /// Property that represents a client id.
        /// </summary>
        public static string ClientId
        {
            get
            {
                return _clientId;
            }
            set
            {
                if (!string.IsNullOrEmpty(_clientId))
                {
                    throw new MPConfException("clientId setting can not be changed");
                }
                _clientId = value;
            }
        }
        static string _clientId = null;

        /// <summary>
        /// MercadoPago AccessToken.
        /// </summary>
        public static string AccessToken
        {
            get
            {
                return _accessToken;
            }
            set
            {
                if (!string.IsNullOrEmpty(_accessToken))
                {
                    throw new MPConfException("accessToken setting can not be changed");
                }
                _accessToken = value;
            }
        }
        static string _accessToken = null;

        /// <summary>
        /// MercadoPAgo app id.
        /// </summary>
        public static string AppId
        {
            get
            {
                return _appId;
            }
            set
            {
                if (!string.IsNullOrEmpty(_appId))
                {
                    throw new MPConfException("appId setting can not be changed");
                }
                _appId = value;
            }
        }
        static String _appId = null;

        /// <summary>
        /// Api base URL. Currently https://api.mercadopago.com
        /// </summary>
        public static string BaseUrl
        {
            get
            {
                return _baseUrl;
            }
        }
        static string _baseUrl = DEFAULT_BASE_URL;

        /// <summary>
        /// Dictionary based configuration. Valid configuration keys:
        /// clientSecret, clientId, accessToken, appId
        /// </summary>
        /// <param name="configurationParams"></param>
        public static void SetConfiguration(IDictionary<String, String> configurationParams)
        {
            if (configurationParams == null) throw new ArgumentException("Invalid configurationParams parameter");

            configurationParams.TryGetValue("clientSecret", out _clientSecret);
            configurationParams.TryGetValue("clientId", out _clientId);
            configurationParams.TryGetValue("accessToken", out _accessToken);
            configurationParams.TryGetValue("appId", out _appId);
        }

        /// <summary>
        /// Initializes the configurations based in a confiiguration object.
        /// </summary>
        /// <param name="config"></param>
        public static void SetConfiguration(Configuration config)
        {
			if (config == null) throw new ArgumentException("config parameter cannot be null");

            _clientSecret = GetConfigValue(config, "ClientSecret");
            _clientId = GetConfigValue(config, "ClientId");
            _accessToken = GetConfigValue(config, "AccessToken");
            _appId = GetConfigValue(config, "AppId");
        }

        /// <summary>
        /// Clean all the configuration variables
        /// (FOR TESTING PURPOSES ONLY)
        /// </summary>
        public static void CleanConfiguration()
        {
            _clientSecret = null;
            _clientId = null;
            _accessToken = null;
            _appId = null;
            _baseUrl = DEFAULT_BASE_URL;
        }

        private static string GetConfigValue(Configuration config, string key)
        {
            string value = null;
            KeyValueConfigurationElement keyValue = config.AppSettings.Settings[key];
            if (keyValue != null)
            {
                value = keyValue.Value;
            }
            return value;
        }

        /// <summary>
        /// Gets access token for current ClientId and ClientSecret
        /// </summary>
        /// <returns>Access token when this is empty</returns>
        public static string GetAccessToken()
        {
            if (!string.IsNullOrEmpty(UserAccessToken))
                AccessToken = UserAccessToken;
            else if (string.IsNullOrEmpty(AccessToken))
                AccessToken = MPCredentials.GetAccessToken();

            return AccessToken;
        }

        /// <summary>
        /// Refreshes access token for current refresh token
        /// </summary>
        /// <returns>Refreshed access token</returns>
        public static string RefreshAccessToken()
        {
            AccessToken = MPCredentials.RefreshAccessToken();
            return AccessToken;
        }
    }
}
