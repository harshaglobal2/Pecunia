using System;
using System.Collections.Generic;
using System.IO;
using Capgemini.Inventory.Entities;
using Newtonsoft.Json;

namespace Capgemini.Inventory.Contracts.DALContracts
{
    /// <summary>
    /// This abstract class acts as a base for SupplierDAL class
    /// </summary>
    public abstract class SupplierDALBase
    {
        //Collection of Suppliers
        protected static List<Supplier> supplierList = new List<Supplier>();
        private static string fileName = "suppliers.json";

        //Methods for CRUD operations
        public abstract bool AddSupplierDAL(Supplier newSupplier);
        public abstract List<Supplier> GetAllSuppliersDAL();
        public abstract Supplier GetSupplierBySupplierIDDAL(Guid searchSupplierID);
        public abstract List<Supplier> GetSuppliersByNameDAL(string supplierName);
        public abstract Supplier GetSupplierByEmailDAL(string email);
        public abstract Supplier GetSupplierByEmailAndPasswordDAL(string email, string password);
        public abstract bool UpdateSupplierDAL(Supplier updateSupplier);
        public abstract bool UpdateSupplierPasswordDAL(Supplier updateSupplier);
        public abstract bool DeleteSupplierDAL(Guid deleteSupplierID);

        /// <summary>
        /// Writes collection to the file in JSON format.
        /// </summary>
        public static void Serialize()
        {
            string serializedJson = JsonConvert.SerializeObject(supplierList);
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
                var systemUserListFromFile = JsonConvert.DeserializeObject<List<Supplier>>(fileContent);
                if (systemUserListFromFile != null)
                {
                    supplierList = systemUserListFromFile;
                }
            }
        }

        /// <summary>
        /// Static Constructor.
        /// </summary>
        static SupplierDALBase()
        {
            //Deserialize();
        }
    }
}


