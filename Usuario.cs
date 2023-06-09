using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMySQLWinForm
{
    public class Usuario
    {
        private int id;
        private string nombre;
        private string contrasenia;
        private bool estado;

        public int Id { get => id; set => id = value;}
        public string Nombre { get => nombre; set => nombre = value; }
        public string Contrasenia { get => contrasenia; set => contrasenia = value; }
        public bool Estado { get => estado; set => estado = value; }

        public Usuario() 
        {

        }
        public Usuario(string nombre, string contrasenia,bool estado)
        {
            this.nombre = nombre;
            this.contrasenia = contrasenia;
            this.estado = estado;
        }

        public override string ToString() {
            return $"{id} - {nombre} - {contrasenia} - {estado}";
        }
    }
}
