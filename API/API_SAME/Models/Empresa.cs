namespace API_SAME.Models
{
    public class Empresa
    {
        public int idEmpresa { get; set; }
        public string nombreEmpresa { get; set; }
        public string direccionEmpresa { get; set; }
        public string telefonoEmpresa { get; set; }


        public class EmpresaRequest
        {
            public string nombreEmpresa { get; set; }
            public string direccionEmpresa { get; set; }
            public string telefonoEmpresa { get; set; }
        }


        public class EmpresaUsadateRequest
        {
            public int idEmpresa { get; set; }
            public string nombreEmpresa { get; set; }
            public string direccionEmpresa { get; set; }
            public string telefonoEmpresa { get; set; }
        }

        public class EmpresaDeleteRequest
        {
            public int idEmpresa { get; set; }
        }

    }
}
