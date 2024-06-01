using API_SAME.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using System.Data.SqlClient;

namespace API_SAME.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {

        public readonly string con;

        public EmpresaController(IConfiguration configuration)
        {
            con = configuration.GetConnectionString("conexion");
        }


        [HttpGet]

        public IEnumerable<Empresa> Post(string nombre ="")
        {

            List<Empresa> empresas = new();

            using(SqlConnection connection = new SqlConnection(con))
            {

                connection.Open();
                using(SqlCommand cmd= new("TB_EMPRESA_L_SP", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@NOMBRE", nombre);

                    string nombreParametro = string.IsNullOrEmpty(nombre)? string.Empty : nombre;
                    cmd.Parameters.AddWithValue("@NOMBRE", nombreParametro);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Empresa e = new Empresa
                            {
                                idEmpresa = reader["ID_EMPRESA"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ID_EMPRESA"]),
                                nombreEmpresa = reader["NOMBRE_EMPRESA"] == DBNull.Value ? string.Empty : reader["NOMBRE_EMPRESA"].ToString(),
                                direccionEmpresa = reader["DIRECCION_EMPRESA"] == DBNull.Value ? string.Empty : reader["DIRECCION_EMPRESA"].ToString(),
                                telefonoEmpresa = reader["TELEFONO_EMPRESA"] == DBNull.Value ? string.Empty : reader["TELEFONO_EMPRESA"].ToString()

                            };
                            empresas.Add(e);

                        }

                    }
                }
            }
            return empresas;
        }






    }
}
