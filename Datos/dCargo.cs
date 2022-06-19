using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class dCargo
    {
        Database db = new Database();

        public string Insertar_Cargo(eCargo obj)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string insert = string.Format("insert to Cargo (id_cargo, nombre_cargo) values ({0},'{1}')", obj.Id_Cargo, obj.Nombre_Cargo);
                SqlCommand cmd = new SqlCommand(insert, con);
                cmd.ExecuteNonQuery();
                return "Inserto";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                db.DesconectaDb();
            }
        }

        public string Modificar_Cargo(eCargo obj)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string update = string.Format("UPDATE Cargo SET nombre_cargo='{0}' Where id_cargo={1}", obj.Nombre_Cargo, obj.Id_Cargo);
                SqlCommand cmd = new SqlCommand(update, con);
                cmd.ExecuteNonQuery();
                return "Modifico";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.DesconectaDb();
            }
        }

        public string Eliminar_Cargo(int id)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string delete = string.Format("delete from Cargo where id_cargo={0}", id);
                SqlCommand cmd = new SqlCommand(delete, con);
                cmd.ExecuteNonQuery();
                return "Elimino";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.DesconectaDb();
            }
        }

        public eCargo BuscarCargoPorId(int id)
        {
            try
            {
                eCargo cargo = null;
                SqlConnection con = db.ConectaDb();
                string select = string.Format("select id_cargo, nombre_cargo from Cargo where id_cargo={0}", id);
                SqlCommand cmd = new SqlCommand(select, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    cargo = new eCargo();
                    cargo.Id_Cargo = (int)reader["id_cargo"];
                    cargo.Nombre_Cargo = (string)reader["nombre_cargo"];
                }
                reader.Close();
                return cargo;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                db.DesconectaDb();
            }
        }

        public List<eCargo> ListarTodoCargo()
        {
            try
            {
                List<eCargo> lsCargo = new List<eCargo>();
                eCargo cargo = null;
                SqlConnection con = db.ConectaDb();
                SqlCommand cmd = new SqlCommand("select id_cargo,nombre_cargo from Cargo", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cargo = new eCargo();
                    cargo.Id_Cargo = (int)reader["id_cargo"];
                    cargo.Nombre_Cargo = (string)reader["nombre_cargo"];
                    lsCargo.Add(cargo);
                }
                reader.Close();
                return lsCargo;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                db.DesconectaDb();
            }
        }

    }
}
