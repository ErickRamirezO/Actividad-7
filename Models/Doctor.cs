namespace WebApplication1.Models
{
    public class Doctor
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    // Otras propiedades del doctor
    public string Especialidad { get; set; } // Propiedad de especialidad

     public Doctor()
    {
        // Inicializar propiedades que no admiten valores nulos
        Nombre = string.Empty; // O cualquier otro valor por defecto que tenga sentido
        Especialidad = string.Empty; // O cualquier otro valor por defecto que tenga sentido
    }
}


}
