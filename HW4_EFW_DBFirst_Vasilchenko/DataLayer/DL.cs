using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW4_EFW_DBFirst_Vasilchenko.Model;

namespace HW4_EFW_DBFirst_Vasilchenko.DataLayer
{
    internal class DL
    {
        public static string сonnectionString { get; set; } = ConfigurationManager.ConnectionStrings["CompanyDB"].ConnectionString;

        public static IEnumerable<EmployeeModel> All()
        {
            using (var db = new CompanyDBEntities())
            {
                List<EmployeeModel> empl = new List<EmployeeModel>();
                var result = db.stp_EmployeeALL().ToList();
                foreach (var item in result)
                {
                    EmployeeModel tmp = new EmployeeModel();
                    tmp.EmployeeID = item.EmployeeID;
                    tmp.LastName = item.LastName;
                    tmp.FirstName = item.FirstName;
                    tmp.BirthDate = item.BirthDate;
                    empl.Add(tmp);
                }
                return empl;
            }
        }

        public static EmployeeModel ByID(int _id)
        {
            using(var db = new CompanyDBEntities())
            {
                EmployeeModel empl = new EmployeeModel();
                var result = db.stp_EmployeeByID(_id).First();
                empl.EmployeeID = result.EmployeeID;
                empl.LastName = result.LastName;
                empl.FirstName = result.FirstName;
                empl.BirthDate = result.BirthDate;

                return empl;
            }
        }

        
        public static int Add(EmployeeModel _newEmployee)
        {
            using(var db = new CompanyDBEntities())
            {
                ObjectParameter newEmplParameter = new ObjectParameter("EmployeeID", 0);
                db.stp_EmployeeAdd(
                    firstName: _newEmployee.FirstName,
                    lastName: _newEmployee.LastName,
                    birthDate: _newEmployee.BirthDate,
                    positionID: _newEmployee.PositionID,
                    employeeID: newEmplParameter
                    );
                return (int)newEmplParameter.Value;

            }
            
        }

        public static void Delete(int _emplDeleteId)
        {
            
            using (SqlConnection conn = new SqlConnection(сonnectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("stp_EmployeeDelete", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("EmployeeID", _emplDeleteId);
                cmd.Parameters.AddWithValue("Result", 0);
                cmd.ExecuteNonQuery();
                Console.WriteLine($"Employee {_emplDeleteId} deleted successfully");
            }
        }


        public static void Update_Empl(EmployeeModel empl_update)
        {
            using (var DB = new CompanyDBEntities())
            {
                ObjectParameter res = new ObjectParameter("Result", 1);
                DB.stp_EmployeeUpdate
                    (employeeID: empl_update.EmployeeID,
                    firstName: empl_update.FirstName,
                    lastName: empl_update.LastName,
                    birthDate: empl_update.BirthDate,
                    positionID: empl_update.PositionID,
                    result: res);
            }
        }











    }
}
