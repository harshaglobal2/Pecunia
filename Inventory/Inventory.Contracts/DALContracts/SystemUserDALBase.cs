using System;
using System.Collections.Generic;
using System.IO;
using Capgemini.Inventory.Entities;
using Newtonsoft.Json;

namespace Capgemini.Inventory.Contracts.DALContracts
{
    /// <summary>
    /// This abstract class acts as a base for SystemUserDAL class
    /// </summary>
    public abstract class SystemUserDALBase
    {
        //Collection of SystemUsers
        protected static List<SystemUser> systemUserList = new List<SystemUser>();
        private static string fileName = "systemUsers.json";

        //Methods for CRUD operations
        public abstract bool AddSystemUserDAL(SystemUser newSystemUser);
        public abstract List<SystemUser> GetAllSystemUsersDAL();
        public abstract SystemUser GetSystemUserBySystemUserIDDAL(Guid searchSystemUserID);
        public abstract List<SystemUser> GetSystemUsersByNameDAL(string systemUserName);
        public abstract SystemUser GetSystemUserByEmailDAL(string email);
        public abstract SystemUser GetSystemUserByEmailAndPasswordDAL(string email, string password);
        public abstract bool UpdateSystemUserDAL(SystemUser updateSystemUser);
        public abstract bool UpdateSystemUserPasswordDAL(SystemUser updateSystemUser);
        public abstract bool DeleteSystemUserDAL(Guid deleteSystemUserID);

        /// <summary>
        /// Writes collection to the file in JSON format.
        /// </summary>
        public static void Serialize()
        {
            string serializedJson = JsonConvert.SerializeObject(systemUserList);
            using (StreamWriter streamWriter = new StreamWriter(fileName))
            {
                streamWriter.Write(serializedJson);
                streamWriter.Close();
            }
        }

        /// <summary>
        /// Reads collection from the file in JSON format.
        /// </summary>
        public static void Deserialize()
        {
            string fileContent = string.Empty;
            if (!File.Exists(fileName))
                File.Create(fileName).Close();

            using (StreamReader streamReader = new StreamReader(fileName))
            {
                fileContent = streamReader.ReadToEnd();
                streamReader.Close();
                var systemUserListFromFile = JsonConvert.DeserializeObject<List<SystemUser>>(fileContent);
                if (systemUserListFromFile != null)
                {
                    systemUserList = systemUserListFromFile;
                }
            }
        }

        /// <summary>
        /// Static Constructor.
        /// </summary>
        static SystemUserDALBase()
        {
            Deserialize();
        }
    }
}


