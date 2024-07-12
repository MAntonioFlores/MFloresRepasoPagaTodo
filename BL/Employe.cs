using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace BL
{
    public class Employe
    {
		public static (bool, string, Exception) AddEmploye(ML.Employe employe)
		{
			try
			{
				using (DL.MfloresPagaTodoContext context = new DL.MfloresPagaTodoContext())
				{
					var rowsAffected = context.Database.ExecuteSqlRaw($"AddEmploye '{employe.FirstName}','{employe.LastName}','{employe.Salary}'");

					if (rowsAffected > 0)
					{
						return (true, "Se agrego exitosamente", null);
					}
					else
					{
						return (false, "No se agrego", null);
					}
				}
			}
			catch (Exception ex)
			{
				return(false,"Ocurrio un error: " + ex.Message, ex);
			}
		}
		public static (bool, string, Exception) UpdateEmploye(ML.Employe employe)
		{
			try
			{
				using (DL.MfloresPagaTodoContext context = new DL.MfloresPagaTodoContext())
				{
					var rowsAffected = context.Database.ExecuteSqlRaw($"UpdateEmploye '{employe.FirstName}', '{employe.LastName}', '{employe.Salary}', '{employe.EmployeeId}'");

					if(rowsAffected > 0)
					{
						return (true, "Se actualizo correctamente", null);
					}
					else
					{
						return(false,"No se actualizo",  null);

					}
				}
			}
			catch (Exception ex)
			{
				return (false, "Ocurrio un error: " + ex, null);
			}
		}
		public static(bool, string, Exception) DeleteEmploye(int EmployeeId)
		{
			try
			{
				using (DL.MfloresPagaTodoContext context = new DL.MfloresPagaTodoContext())
				{
					var rowsAffected = context.Database.ExecuteSqlRaw($"DeleteEmploye '{EmployeeId}'");

					if (rowsAffected > 0)
					{
						return (true, "Se elimino exitosamente", null);
					}
					else
					{
                        return (false, "No se elimino", null);
                    }
				}
			}
			catch (Exception ex)
			{
                return (false, "Ocurrio un error: " + ex, ex);
            }
		}
        public static (bool, string?, ML.Employe?, Exception?) AllEmploye()
        {
            ML.Employe employe = new ML.Employe();
            try
            {
                using (DL.MfloresPagaTodoContext context = new DL.MfloresPagaTodoContext())
                {
                    var query = context.Employees.FromSqlRaw("EXECUTE AllEmployes").ToList();

                    if (query.Count > 0)
                    {
                        employe.Employes = new List<ML.Employe>();
                        foreach (var registro in query)
                        {
                            ML.Employe employeObj = new ML.Employe();

                            employeObj.EmployeeId = registro.EmployeeId;
                            employeObj.FirstName = registro.FirstName;
                            employeObj.LastName = registro.LastName;
                            employeObj.Salary = registro.Salary;

                            employe.Employes.Add(employeObj);
                        }

                        return (true, "Lista de empleados obtenida correctamente.", employe, null);
                    }
                    else
                    {
                        return (false, "No se encontraron empleados.", employe, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, "Ocurrió un error al obtener la lista de empleados.", null, ex);
            }
        }
        public static (bool,string,ML.Employe, Exception) ById(int EmployeeId)
		{
			try
			{
				using (DL.MfloresPagaTodoContext context = new DL.MfloresPagaTodoContext())
				{
					var query = (from employ in context.Employees
								 where employ.EmployeeId == EmployeeId
								 select new
								 {
									 EmployeeId = employ.EmployeeId,
									 FirstName = employ.FirstName,
									 LastName = employ.LastName,
									 Salary = employ.Salary
								 }).FirstOrDefault();//context.Employees.FromSql($"EXECUTE dbo.ByIdEmploye {EmployeeId}").FirstOrDefault();

					if (query != null)
					{
						ML.Employe employe = new ML.Employe
						{

							EmployeeId = query.EmployeeId,
							FirstName = query.FirstName,
							LastName = query.LastName,
							Salary = query.Salary.Value
						};

						return (true, null, employe, null);
					}
					else
					{
						return (false,null,null,null);
					}
                }
			}
			catch (Exception ex)
			{
				return(false,"Ocurrio un error: " + ex.Message, null, ex);
			}
		}
    }
}
