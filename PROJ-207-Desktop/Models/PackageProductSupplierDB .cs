using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROJ_207_Project_2.Models;
using Microsoft.Data.SqlClient;

namespace PROJ_207_Project_2
{
    /*
     * Purpose: Data access class for Packages_Products_Suppliers
     * Authors: Group 6
     */
    public static class PackageProductSupplierDB
    {
        /// <summary>
        ///  Retrieves list of products-suppliers with given packageid
        /// </summary>
        /// <param name="pkgId">id of package to get</param>
        /// <returns>products-suppliers of a package</returns>
        public static List<PackagesProductsSupplier> GetProductsSuppliersByPackageId(int pkgId)
        {
            List<PackagesProductsSupplier> ppsList = new List<PackagesProductsSupplier>(); // empty
            PackagesProductsSupplier pps;
            // connection
            using (SqlConnection connection = TravelExpertsContext.GetConnection())
            {
                string query = "SELECT pps.ProductSupplierID, " +
                               "ProdName + ', ' + SupName AS ProductSupplierName " +
                               "FROM Packages_Products_Suppliers AS pps " +
                               "JOIN Products_Suppliers AS ps " +
                               "ON pps.ProductSupplierId = ps.ProductSupplierId " +
                               "JOIN Products AS p " +
                               "ON ps.ProductId = p.ProductId " +
                               "JOIN Suppliers AS s " +
                               "ON ps.SupplierId = s.SupplierId " +
                               "WHERE PackageId = @PackageId " +
                               "ORDER BY ProductSupplierId";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PackageId", pkgId);
                    // run command and process data
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read()) // while there is data
                        {
                            pps = new PackagesProductsSupplier();
                            pps.ProductSupplierId = (int)dr["ProductSupplierId"];
                            //pps.ProductSupplier.Supplier.SupName = (string)dr["ProductSupplierName"];
                            ppsList.Add(pps);
                        }
                    }
                }
            }
            return ppsList;
        }

        /// <summary>
        ///Adds a new product supplier to selected package
        /// </summary>
        /// <param name="pps">new pkg prod sup info</param>
        /// <returns>if successful add</returns>
        public static bool AddPackageProductSupplier(int pkgId, int prodSupId)
        {
            bool success;

            using (SqlConnection connection = TravelExpertsContext.GetConnection())
            {
                string insertStatement = "INSERT INTO Packages_Products_Suppliers (PackageId, ProductSupplierId) " +
                                         "VALUES(@PackageId, @ProductSupplierId)";
                using (SqlCommand cmd = new SqlCommand(insertStatement, connection))
                {
                    cmd.Parameters.AddWithValue("@PackageId", pkgId);
                    cmd.Parameters.AddWithValue("@ProductSupplierId", prodSupId);

                    // open connection
                    connection.Open();

                    if (cmd.ExecuteNonQuery() == 1)
                        success = true;
                    else
                        success = false;
                }
            }
            return success;
        }

        /// <summary>
        //Returns a list of new product suppliers that are not yet within the selected package
        /// </summary>
        /// <param name="pkgId"></param>
        /// <returns>list of new prod sups</returns>
        public static List<PackagesProductsSupplier> GetNewProductsSuppliers(int pkgId)
        {
            List<PackagesProductsSupplier> prodsSups = new List<PackagesProductsSupplier>(); // empty
            PackagesProductsSupplier prodSup;
            // connection
            using (SqlConnection connection = TravelExpertsContext.GetConnection())
            {
                string query = "SELECT DISTINCT ps.ProductSupplierId, ps.ProductId, ps.SupplierId, ProdName, SupName " +
                               "FROM Packages_Products_Suppliers AS pps " +
                               "RIGHT JOIN Products_Suppliers AS ps " +
                               "ON pps.ProductSupplierId = ps.ProductSupplierId " +
                               "JOIN Products ON ps.ProductId = Products.ProductId " +
                               "JOIN Suppliers ON ps.SupplierId = Suppliers.SupplierId " +
                               "WHERE ps.ProductSupplierId NOT IN " +
                               "(SELECT ps.ProductSupplierId " +
                               "FROM Products_Suppliers AS ps " +
                               "JOIN Packages_Products_Suppliers AS pps " +
                               "ON ps.ProductSupplierId = pps.ProductSupplierId " +
                               "AND PackageId = @PackageId) " +
                               "ORDER BY ps.ProductSupplierId";


                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PackageId", pkgId);
                    // run command and process data
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read()) // while there is data
                        {
                            prodSup = new PackagesProductsSupplier();
                            prodSup.ProductSupplierId = (int)dr["ProductSupplierId"];
                            prodSup.ProductSupplier.ProductId = (int)dr["ProductId"];
                            prodSup.ProductSupplier.Product.ProdName = (string)dr["ProdName"];
                            prodSup.ProductSupplier.SupplierId = (int)dr["SupplierId"];
                            prodSup.ProductSupplier.Supplier.SupName = (string)dr["SupName"];
                            prodsSups.Add(prodSup);
                        }
                    }
                }
            }
            return prodsSups;
        }

        /// <summary>
        /// Returns a list of new product supplier ids that are not yet a part of the selected package
        /// </summary>
        /// <param name="pkgId"></param>
        /// <returns>list of prod sup ids</returns>
        public static List<int> GetNewProductSupplierIds(int pkgId)
        {
            List<int> prodSupIds = new List<int>(); // empty prod sup ids
            int prodSupId;

            using (SqlConnection connection = TravelExpertsContext.GetConnection())
            {
                string query = "SELECT DISTINCT ps.ProductSupplierId " +
                               "FROM Packages_Products_Suppliers AS pps " +
                               "RIGHT JOIN Products_Suppliers AS ps " +
                               "ON pps.ProductSupplierId = ps.ProductSupplierId " +
                               "WHERE ps.ProductSupplierId NOT IN " +
                               "(SELECT ps.ProductSupplierId " +
                               "FROM Products_Suppliers AS ps " +
                               "JOIN Packages_Products_Suppliers AS pps " +
                               "ON ps.ProductSupplierId = pps.ProductSupplierId " +
                               "AND PackageId = @PackageId) " +
                               "ORDER BY ps.ProductSupplierId";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PackageId", (int)pkgId);

                    // run command and process data
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read()) // while there is data
                        {
                            prodSupId = Convert.ToInt32(dr["ProductSupplierId"]);
                            prodSupIds.Add(prodSupId);
                        }
                    }
                }
            }
            return prodSupIds;
        }
    }
}
