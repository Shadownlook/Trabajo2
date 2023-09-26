namespace Principios
{
    // Declaración de una clase abstracta llamada "ClsAbsCliente."
    public abstract class ClsAbsCliente
    {
        // Propiedades abstractas para representar los datos de un cliente.
        public abstract int Id { get; set; }
        public abstract string Nombre { get; set; }
        public abstract string Clave { get; set; }
        public abstract string Rfc { get; set; }
        public abstract int Tiporegimen { get; set; }
        public abstract string Contacto { get; set; }
    }

    // Declaración de una clase "ClsCliente" que hereda de "ClsAbsCliente."
    public class ClsCliente : ClsAbsCliente
    {
        // Implementación de las propiedades abstractas heredadas.
        public override int Id { get; set; }
        public override string Nombre { get; set; }
        public override string Clave { get; set; }
        public override string Rfc { get; set; }
        public override int Tiporegimen { get; set; }
        public override string Contacto { get; set; }

        // Constructores de la clase "ClsCliente."
        public ClsCliente()
        {
            // Inicializa las propiedades con valores predeterminados.
            Id = 0;
            Nombre = string.Empty;
            Clave = string.Empty;
            Rfc = string.Empty;
            Tiporegimen = 0;
            Contacto = string.Empty;
        }

        public ClsCliente(int pId, string pNombre, string pClave, string pRfc, int pTiporegimen, string pContacto)
        {
            // Inicializa las propiedades con valores proporcionados.
            Id = pId;
            Nombre = pNombre;
            Clave = pClave;
            Rfc = pRfc;
            Tiporegimen = pTiporegimen;
            Contacto = pContacto;
        }
    }
}