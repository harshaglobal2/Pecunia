using System;
using System.Collections.Generic;
using System.IO;
using Capgemini.Inventory.Entities;
using Newtonsoft.Json;

namespace Capgemini.Inventory.Contracts.DALContracts
{
    /// <summary>
    /// This abstract class acts as a base for DistributorDAL class
    /// </summary>
    public abstract class DistributorDALBase
    {
        //Collection of Distributors
        protected static List<Distributor> distributorList = new List<Distributor>();
        private static string fileName = "distributors.json";

        //Methods for CRUD operations
        public abstract bool AddDistributorDAL(Distributor newDistributor);
        public abstract List<Distributor> GetAllDistributorsDAL();
        public abstract Distributor GetDistributorByDistributorIDDAL(Guid searchDistributorID);
        public abstract List<Distributor> GetDistributorsByNameDAL(string distributorName);
        public abstract Distributor GetDistributorByEmailDAL(string email);
        public abstract Distributor GetDistributorByEmailAndPasswordDAL(string email, string password);
        public abstract bool UpdateDistributorDAL(Distributor updateDistributor);
        public abstract bool UpdateDistributorPasswordDAL(Distributor updateDistributor);
        public abstract bool DeleteDistributorDAL(Guid deleteDistributorID);

        /// <summary>
        /// Writes collection to the file in JSON format.
        /// </summary>
        public static void Serialize()
        {
            string serializedJson = JsonConvert.SerializeObject(distributorList);
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
                var systemUserListFromFile = JsonConvert.DeserializeObject<List<Distributor>>(fileContent);
                if (systemUserListFromFile != null)
                {
                    distributorList = systemUserListFromFile;
                }
            }
        }

        /// <summary>
        /// Static Constructor.
        /// </summary>
        static DistributorDALBase()
        {
            Deserialize();
        }
    }
}


