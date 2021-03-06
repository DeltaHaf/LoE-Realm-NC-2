﻿#region

using log4net;
using System.Security.Cryptography;
using System.Text;

#endregion

namespace LoESoft.AppEngine.security
{
    /// <summary>
    /// Security Protocols
    /// Made by Devwarlt
    /// </summary>
    internal class securityProtocols : RequestHandler
    {
        internal static ILog log = LogManager.GetLogger(nameof(securityProtocols));

        protected const string LOESOFT_HASH = "loesoft_";
        protected const string protocolToken = "FDE649D19A6C182F23F3776F8C975AD3";
        protected const string protocolID = "7750407";
        protected const string playerData = "Player";
        protected const string rateoffireData = "RateOfFire";
        protected const string rateoffireValueData = "1";
        protected const string mpcostData = "MpCost";
        protected const string numprojectilesValueData = "1";
        protected const string arcgapValueData = "11.25";
        protected const string cooldownData = "Cooldown";
        protected const string cooldownValueData = "1000";

        protected override void HandleRequest()
        {
            string encryptedLOESOFT_HASH_ = Query["LOESOFT_HASH"];
            string encryptedprotocolToken_ = Query["protocolToken"];
            string encryptedprotocolID_ = Query["protocolID"];
            string encryptedplayerData_ = Query["playerData"];
            string encryptedrateoffireData_ = Query["rateoffireData"];
            string encryptedrateoffireValueData_ = Query["rateoffireValueData"];
            string encryptedmpcostData_ = Query["mpcostData"];
            string encryptednumprojectilesValueData_ = Query["numprojectilesValueData"];
            string encryptedarcgapValueData_ = Query["arcgapValueData"];
            string encryptedcooldownData_ = Query["cooldownData"];
            string encryptedcooldownValueData_ = Query["cooldownValueData"];
            string crudeLOESOFT_HASH_ = Query["crudeLOESOFT_HASH"];
            string crudeprotocolToken_ = Query["crudeprotocolToken"];
            string crudeprotocolID_ = Query["crudeprotocolID"];
            string crudeplayerData_ = Query["crudeplayerData"];
            string cruderateoffireData_ = Query["cruderateoffireData"];
            string cruderateoffireValueData_ = Query["cruderateoffireValueData"];
            string crudempcostData_ = Query["crudempcostData"];
            string crudenumprojectilesValueData_ = Query["crudenumprojectilesValueData"];
            string crudearcgapValueData_ = Query["crudearcgapValueData"];
            string crudecooldownData_ = Query["crudecooldownData"];
            string crudecooldownValueData_ = Query["crudecooldownValueData"];

            byte[] buffer;
            if (Query["LOESOFT_HASH"] != null)
                if (!EncryptionMatch(encryptedLOESOFT_HASH_, LOESOFT_HASH, true)
                    || !EncryptionMatch(encryptedprotocolToken_, protocolToken)
                    || !EncryptionMatch(encryptedprotocolID_, protocolID)
                    || !EncryptionMatch(encryptedplayerData_, playerData)
                    || !EncryptionMatch(encryptedrateoffireData_, rateoffireData)
                    || !EncryptionMatch(encryptedrateoffireValueData_, rateoffireValueData)
                    || !EncryptionMatch(encryptedmpcostData_, mpcostData)
                    || !EncryptionMatch(encryptednumprojectilesValueData_, numprojectilesValueData)
                    || !EncryptionMatch(encryptedarcgapValueData_, arcgapValueData)
                    || !EncryptionMatch(encryptedcooldownData_, cooldownData)
                    || !EncryptionMatch(encryptedcooldownValueData_, cooldownValueData))
                {
                    buffer = Encoding.ASCII.GetBytes("<Error/>");
                    int i = 0;
                    string invalidProtocols = null;
                    if (encryptedLOESOFT_HASH_ != Sha256encrypt(EmbedHash(LOESOFT_HASH, true)))
                    {
                        invalidProtocols = invalidProtocols + $"\n* [wrong hash | decrypted: ({crudeLOESOFT_HASH_}/{LOESOFT_HASH}) | encrypted: ({encryptedLOESOFT_HASH_}/{Sha256encrypt(EmbedHash(LOESOFT_HASH, true))})]";
                        i++;
                    }
                    if (encryptedprotocolToken_ != Sha256encrypt(EmbedHash(protocolToken)))
                    {
                        invalidProtocols = invalidProtocols + $"\n* [wrong token | decrypted: ({crudeprotocolToken_}/{LOESOFT_HASH + protocolToken}) | encrypted: ({encryptedprotocolToken_}/{Sha256encrypt(EmbedHash(protocolToken))})]";
                        i++;
                    }
                    if (encryptedprotocolID_ != Sha256encrypt(EmbedHash(protocolID)))
                    {
                        invalidProtocols = invalidProtocols + $"\n* [wrong id | decrypted: ({crudeprotocolID_}/{LOESOFT_HASH + protocolID}) | encrypted: ({encryptedprotocolID_}/{Sha256encrypt(EmbedHash(protocolID))})]";
                        i++;
                    }
                    if (encryptedplayerData_ != Sha256encrypt(EmbedHash(playerData)))
                    {
                        invalidProtocols = invalidProtocols + $"\n* [wrong player data | decrypted: ({crudeplayerData_}/{LOESOFT_HASH + playerData}) | encrypted: ({encryptedplayerData_}/{Sha256encrypt(EmbedHash(playerData))})]";
                        i++;
                    }
                    if (encryptedrateoffireData_ != Sha256encrypt(EmbedHash(rateoffireData)))
                    {
                        invalidProtocols = invalidProtocols + $"\n* [wrong rate of fire data | decrypted: ({cruderateoffireData_}/{LOESOFT_HASH + rateoffireData}) | encrypted: ({encryptedrateoffireData_}/{Sha256encrypt(EmbedHash(rateoffireData))})]";
                        i++;
                    }
                    if (encryptedrateoffireValueData_ != Sha256encrypt(EmbedHash(rateoffireValueData)))
                    {
                        invalidProtocols = invalidProtocols + $"\n* [wrong rate of fire value data | decrypted: ({cruderateoffireValueData_}/{LOESOFT_HASH + rateoffireValueData}) | encrypted: ({encryptedrateoffireValueData_}/{Sha256encrypt(EmbedHash(rateoffireValueData))})]";
                        i++;
                    }
                    if (encryptedmpcostData_ != Sha256encrypt(EmbedHash(mpcostData)))
                    {
                        invalidProtocols = invalidProtocols + $"\n* [wrong mp cost data | decrypted: ({crudempcostData_}/{LOESOFT_HASH + mpcostData}) | encrypted: ({encryptedmpcostData_}/{Sha256encrypt(EmbedHash(mpcostData))})]";
                        i++;
                    }
                    if (encryptednumprojectilesValueData_ != Sha256encrypt(EmbedHash(numprojectilesValueData)))
                    {
                        invalidProtocols = invalidProtocols + $"\n* [wrong num projectiles value data | decrypted: ({crudenumprojectilesValueData_}/{LOESOFT_HASH + numprojectilesValueData}) | encrypted: ({encryptednumprojectilesValueData_}/{Sha256encrypt(EmbedHash(numprojectilesValueData))})]";
                        i++;
                    }
                    if (encryptedarcgapValueData_ != Sha256encrypt(EmbedHash(arcgapValueData)))
                    {
                        invalidProtocols = invalidProtocols + $"\n* [wrong arc gap value data | decrypted: ({crudearcgapValueData_}/{LOESOFT_HASH + arcgapValueData}) | encrypted: ({encryptedarcgapValueData_}/{Sha256encrypt(EmbedHash(arcgapValueData))})]";
                        i++;
                    }
                    if (encryptedcooldownData_ != Sha256encrypt(EmbedHash(cooldownData)))
                    {
                        invalidProtocols = invalidProtocols + $"\n* [wrong cooldown data | decrypted: ({crudecooldownData_}/{LOESOFT_HASH + cooldownData}) | encrypted: ({encryptedcooldownData_}/{Sha256encrypt(EmbedHash(cooldownData))})]";
                        i++;
                    }
                    if (encryptedcooldownValueData_ != Sha256encrypt(EmbedHash(cooldownValueData)))
                    {
                        invalidProtocols = invalidProtocols + $"\n* [wrong cooldown value data | decrypted: ({crudecooldownValueData_}/{LOESOFT_HASH + cooldownValueData}) | encrypted: ({encryptedcooldownValueData_}/{Sha256encrypt(EmbedHash(cooldownValueData))})]";
                        i++;
                    }
                    log.Error($"CONNECTION DENIED: User '{Context.Request.RemoteEndPoint.Address}' is trying to access with invalid client security protocols.\n\n[!] Number of erros: {i}\n[!] Error Log: {invalidProtocols}.");
                }
                else
                    buffer = Encoding.ASCII.GetBytes("<Success/>");
            else
            {
                buffer = Encoding.ASCII.GetBytes("<Error/>");
                log.Error($"User '{Context.Request.RemoteEndPoint.Address}' is using an outdated/hacked client, deny access too."); //TODO: allocate DNS of player to dictionary and deny access to login via HelloHandler.cs
            }
            Context.Response.OutputStream.Write(buffer, 0, buffer.Length);
        }

        internal static string EmbedHash(string value, bool isHash = false) => LOESOFT_HASH + (isHash ? "" : value);

        internal static bool EncryptionMatch(string outcomingData, string referenceData, bool isHash = false)
        {
            if (outcomingData == Sha256encrypt(EmbedHash(referenceData, isHash)))
                return true;
            else
                return false;
        }

        internal static string Sha256encrypt(string phrase)
        {
            SHA256Managed crypt = new SHA256Managed();
            string hash = string.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(phrase), 0, Encoding.ASCII.GetByteCount(phrase));
            foreach (byte theByte in crypto)
                hash += theByte.ToString("x2");
            return hash;
        }
    }
}