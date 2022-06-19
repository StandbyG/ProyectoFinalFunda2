using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class dControlHoras
    {
        Database db = new Database();

        public string Insertar_ControlHoras(eControlHoras obj)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string insert = string.Format("insert to Control_Horas (id_controlHoras, id_trabajador, Hora_ingreso, Hora_salida, Fecha_registro) values ({0},{1},'{2}','{3}','{4}')", obj.Id_ControlHoras, obj.Id_Trabajador, obj.Hora_Ingreso, obj.Hora_Salida, obj.Fecha_Registro);
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

        public string Modificar_ControlHoras(eControlHoras obj)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string update = string.Format("UPDATE Control_Horas SET id_trabajador={0}, Hora_ingreso='{1}', Hora_salida='{2}', Fecha_registro='{3}' Where id_controlHoras={4}", obj.Id_Trabajador, obj.Hora_Ingreso, obj.Hora_Salida, obj.Fecha_Registro, obj.Id_ControlHoras);
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

        public string Eliminar_ControlHoras(int id)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string delete = string.Format("delete from Control_Horas where id_cargo={0}", id);
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

        public eControlHoras BuscarControlHorasPorId(int id)
        {
            try
            {
                eControlHoras ch = null;
                SqlConnection con = db.ConectaDb();
                string select = string.Format("select id_controlHoras, id_trabajador, Hora_ingreso, Hora_salida, Fecha_ingreso from ControlHoras where id_controlHoras={0}", id);
                SqlCommand cmd = new SqlCommand(select, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    ch = new eControlHoras();
                    ch.Id_ControlHoras = (int)reader["id_controlHoras"];
                    ch.Id_Trabajador = (int)reader["id_trabajador"];
                    ch.Hora_Ingreso = (string)reader["Hora_ingreso"];
                    ch.Hora_Salida = (string)reader["Hora_salida"];
                    ch.Fecha_Registro = (string)reader["Fecha_registro"];
                }
                reader.Close();
                return ch;
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

        public List<eControlHoras> ListarTodoControlHoras()
        {
            try
            {
                List<eControlHoras> lsCh = new List<eControlHoras>();
                eControlHoras ch = null;
                SqlConnection con = db.ConectaDb();
                SqlCommand cmd = new SqlCommand("select id_controlHoras, id_trabajador, Hora_ingreso, Hora_salida, Fecha_registro from Control_Horas", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ch = new eControlHoras();
                    ch.Id_ControlHoras = (int)reader["id_controlHoras"];
                    ch.Id_Trabajador = (int)reader["id_trabajador"];
                    ch.Hora_Ingreso = (string)reader["Hora_ingreso"];
                    ch.Hora_Salida = (string)reader["Hora_salida"];
                    ch.Fecha_Registro = (string)reader["Fecha_registro"];
                    lsCh.Add(ch);
                }
                reader.Close();
                return lsCh;
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
