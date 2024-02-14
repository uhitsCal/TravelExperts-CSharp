using PROJ_207_Project_2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace PROJ_207_Project_2
{
    /*
     * Goal: Data access Packages
     * Authors: Gabriel V Gomes / Damanjit
     * When: July 2023
     */
    public static class PackageDB
    {
        public static Package GetPackage(int pkgId)
        {
            Package pkg = null;
           
            using (SqlConnection connection = TravelExpertsContext.GetConnection())
            {
                string query = "SELECT PackageId, PkgName, PkgStartDate, PkgEndDate, PkgDesc, PkgBasePrice, PkgAgencyCommission " +
                               "FROM Packages " +
                               "WHERE PackageId = @PackageId";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PackageId", pkgId);
                   
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        if (dr.Read()) 
                        {
                            pkg = new Package();
                            pkg.PackageId = (int)dr["PackageId"];
                            pkg.PkgName = (string)dr["PkgName"];
                            pkg.PkgBasePrice = Convert.ToDecimal(dr["PkgBasePrice"]);
                       
                            int colSD = dr.GetOrdinal("PkgStartDate"); // number of columns 
                            //if (dr.IsDBNull(colSD)) // in case that reader contains DBNull in the column 
                            //{
                            //    pkg.PkgStartDate = null; // null object
                            //}
                            //else
                                pkg.PkgStartDate = (DateTime)dr["PkgStartDate"];

                            int colED = dr.GetOrdinal("PkgEndDate");
                            //if (dr.IsDBNull(colED)) 
                            //    pkg.PkgEndDate = null; 
                            //else 
                                pkg.PkgEndDate = (DateTime)dr["PkgEndDate"];

                            int colDesc = dr.GetOrdinal("PkgDesc"); 
                            if (dr.IsDBNull(colDesc))
                                pkg.PkgDesc = null; 
                            else 
                                pkg.PkgDesc = (string)dr["PkgDesc"];

                            int colAC = dr.GetOrdinal("PkgAgencyCommission"); 
                            if (dr.IsDBNull(colAC)) 
                                pkg.PkgAgencyCommission = null; 
                            else 
                                pkg.PkgAgencyCommission = Convert.ToDecimal(dr["PkgAgencyCommission"]);
                        }
                    }
                }
            }
            return pkg;
        }
       
        public static List<int> GetPackageIds()
        {
            List<int> packages = new List<int>();
            int pkg;
            
            using (SqlConnection connection = TravelExpertsContext.GetConnection())
            {
                string query = "SELECT PackageId " +
                               "FROM Packages " +
                               "ORDER BY PackageId";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read()) 
                        {
                            pkg = Convert.ToInt32(dr["PackageId"]);
                            packages.Add(pkg);
                        }
                    }
                }
            }
            return packages;
        }
        
        public static int AddPackage(Package pkg)
        {
            int pkgId = 0;
            using (SqlConnection connection = TravelExpertsContext.GetConnection())
            {
                string insertStatement =
                    "INSERT INTO Packages (PkgName, PkgStartDate, PkgEndDate, PkgDesc, PkgBasePrice, PkgAgencyCommission) " +
                    "OUTPUT INSERTED.PackageId " +
                    "VALUES(@PkgName, @PkgStartDate, @PkgEndDate, @PkgDesc, @PkgBasePrice, @PkgAgencyCommission)";
                using (SqlCommand cmd = new SqlCommand(insertStatement, connection))
                {
                    cmd.Parameters.AddWithValue("@PkgName", pkg.PkgName);
                    Console.WriteLine("Package name in databse to be inserted "+pkg.PkgName);

                    if (pkg.PkgStartDate == null)
                        cmd.Parameters.AddWithValue("@PkgStartDate", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@PkgStartDate", (DateTime)pkg.PkgStartDate);

                    if (pkg.PkgEndDate == null)
                        cmd.Parameters.AddWithValue("@PkgEndDate", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@PkgEndDate", (DateTime)pkg.PkgEndDate);

                    if (pkg.PkgDesc == null)
                        cmd.Parameters.AddWithValue("@PkgDesc", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@PkgDesc", (string)pkg.PkgDesc);

                    cmd.Parameters.AddWithValue("@PkgBasePrice", pkg.PkgBasePrice);

                    if (pkg.PkgAgencyCommission == null)
                        cmd.Parameters.AddWithValue("@PkgAgencyCommission", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@PkgAgencyCommission", (decimal)pkg.PkgAgencyCommission);

                   //starts connection
                    connection.Open();
                    pkgId = (int)cmd.ExecuteScalar();
                }
            }
            return pkgId;
        }

        public static bool UpdatePackage(Package oldPkg, Package newPkg)
        {
            bool result = false;
            using (SqlConnection connection = TravelExpertsContext.GetConnection())
            {
                string updateStatement = "UPDATE Packages SET " +
                    "PkgName = @NewPkgName, " +
                    "PkgStartDate = @NewPkgStartDate, " +
                    "PkgEndDate = @NewPkgEndDate, " +
                    "PkgDesc = @NewPkgDesc, " +
                    "PkgBasePrice = @NewPkgBasePrice, " +
                    "PkgAgencyCommission = @NewPkgAgencyCommission " +
                    "WHERE PackageId = @OldPackageId " + 
                    "AND PkgName = @OldPkgName " +
                  
                    "AND (PkgStartDate = @OldPkgStartDate " +
                    "OR PkgStartDate IS NULL " +
                    "AND @OldPkgStartDate IS NULL) " +
              
                    "AND (PkgEndDate = @OldPkgEndDate " +
                    "OR PkgEndDate IS NULL " +
                    "AND @OldPkgEndDate IS NULL) " +
                 
                    "AND (PkgDesc = @OldPkgDesc " +
                    "OR PkgDesc IS NULL " +
                    "AND @OldPkgDesc IS NULL) " +
                    "AND PkgBasePrice = @OldPkgBasePrice " +
                
                    "AND (PkgAgencyCommission = @OldPkgAgencyCommission " +
                    "OR PkgAgencyCommission IS NULL " +
                    "AND @OldPkgAgencyCommission IS NULL)";
                using (SqlCommand cmd = new SqlCommand(updateStatement, connection))
                {
                   
                    cmd.Parameters.AddWithValue("@NewPkgName", newPkg.PkgName);

                    if (newPkg.PkgStartDate == null)
                        cmd.Parameters.AddWithValue("@NewPkgStartDate", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@NewPkgStartDate", (DateTime)newPkg.PkgStartDate);

                    if (newPkg.PkgEndDate == null) 
                        cmd.Parameters.AddWithValue("@NewPkgEndDate", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@NewPkgEndDate", (DateTime)newPkg.PkgEndDate);

                   
                    cmd.Parameters.AddWithValue("@NewPkgDesc", newPkg.PkgDesc);
                    cmd.Parameters.AddWithValue("@NewPkgBasePrice", newPkg.PkgBasePrice);

                    if (newPkg.PkgAgencyCommission == null)
                        cmd.Parameters.AddWithValue("@NewPkgAgencyCommission", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@NewPkgAgencyCommission", (decimal)newPkg.PkgAgencyCommission);

                    cmd.Parameters.AddWithValue("@OldPackageId", oldPkg.PackageId);
                    cmd.Parameters.AddWithValue("@OldPkgName", oldPkg.PkgName);

                    if (oldPkg.PkgStartDate == null) 
                        cmd.Parameters.AddWithValue("@OldPkgStartDate", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@OldPkgStartDate", (DateTime)oldPkg.PkgStartDate);

                    if (oldPkg.PkgEndDate == null)
                        cmd.Parameters.AddWithValue("@OldPkgEndDate", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@OldPkgEndDate", (DateTime)oldPkg.PkgEndDate);

                    if (oldPkg.PkgDesc == null) 
                        cmd.Parameters.AddWithValue("@OldPkgDesc", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@OldPkgDesc", (string)oldPkg.PkgDesc);

                    cmd.Parameters.AddWithValue("@OldPkgBasePrice", oldPkg.PkgBasePrice);

                    if (oldPkg.PkgAgencyCommission == null) 
                        cmd.Parameters.AddWithValue("@OldPkgAgencyCommission", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@OldPkgAgencyCommission", (decimal)oldPkg.PkgAgencyCommission);
                
                    connection.Open();
                   
                    int count = cmd.ExecuteNonQuery();
                    if (count > 0) 
                        result = true;
                }
            }
            return result;
        }
    }
}
