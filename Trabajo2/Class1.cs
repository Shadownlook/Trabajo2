namespace Trabajo2
{
    public class Persona
    {
        public string rut;
        public int edad;
        public string nombre;
        public string cargo;
        public int sueldo;

        public int caculoSueldo(string cargoPersona)
        {
            if (cargoPersona == "Analista")
            {
                return 1700000;
            }
            else if (cargo == "Operador")
            {
                return 800000;
            }
            else
            {
                return 0;
            }
        }
    }
}
