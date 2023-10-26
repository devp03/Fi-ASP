// See https://aka.ms/new-console-template for more information

using Servicios.ContactosServices;

CiudadService ciudadService = new CiudadService("Server=localhost;" + "Port=5432; User Id=postgres; Password=root; Database=Parcial;");
ciudadService.insertarCiudad(new Infraestructura.Modelos.CiudadModel
{
    id_ciudad = 2,
    ciudad = "Paraguari",
    departamento = "Central",
    postal_code = 123446

});