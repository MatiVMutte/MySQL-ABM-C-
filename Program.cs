using PruebaMySQLWinForm;

//Conexion.Conectar();
//Conexion.Insertar(new Usuario("gasti", "4545",true));
//Conexion.Eliminar(23);
//Usuario user=Conexion.Traer(23);
//user.Nombre = "PEPITO MODIFICADO";
//user.Contrasenia = "090103";

//Conexion.Modificar(user);

foreach (Usuario usuario in Conexion.Traer()) {
    Console.WriteLine(usuario);
}