namespace SistemaCuidado.Models
{
    public class ValidacionesModel
    {
        static public int Edad(DateTime FechaNacimiento)
        {
            DateTime FechaActual = DateTime.Now;
            int edad = FechaActual.Year - FechaNacimiento.Year;
            if ((FechaActual.Month < FechaNacimiento.Month) || ((FechaActual.Month == FechaNacimiento.Month) && FechaActual.Day < FechaNacimiento.Day))
            {
                edad = edad - 1;
            }
            return edad;
        }
    }
}
