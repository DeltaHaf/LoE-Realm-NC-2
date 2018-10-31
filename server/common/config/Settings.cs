﻿using System.Collections.Generic;

namespace LoESoft.Core.config
{
    public partial class Settings
    {
        public enum ServerMode
        {
            Local,
            Production
        }

        public static readonly ServerMode SERVER_MODE = ServerMode.Local;
        public static readonly bool ENABLE_RESTART_SYSTEM = SERVER_MODE == ServerMode.Production;
        public static readonly int RESTART_APPENGINE_DELAY_MINUTES = 4 * 60;
        public static readonly int RESTART_DELAY_MINUTES = 60;

        public static readonly List<string> ALLOWED_LOCAL_DNS = new List<string>
        {
            "::1", "localhost", "127.0.0.1", "testing.loesoftgames.ignorelist.com"
        };

        public static class STARTUP
        {
            public static readonly int GOLD = 40;
            public static readonly int FAME = 0;
            public static readonly int TOTAL_FAME = 0;
            public static readonly int TOKENS = 0;
            public static readonly int EMPIRES_COIN = 500;
            public static readonly int MAX_CHAR_SLOTS = 2;
            public static readonly int IS_AGE_VERIFIED = 1;
            public static readonly bool VERIFIED = true;
        }

        public static readonly List<GameVersion> GAME_VERSIONS = new List<GameVersion>
        {
            new GameVersion(Version: "2.0", Allowed: true)
        };
    }
}