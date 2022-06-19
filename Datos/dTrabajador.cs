using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class dTrabajador
    {
        Database db = new Database();

        public string Insertar_Trabajador(eTrabajador obj)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string insert = string.Format("insert to Trabajador (id_empleado, Nombres, Apellido_paterno, Apellido_materno, DNI, Fecha_nacimiento, Salario, Telefono, Direccion, Anio_de_ingreso, id_cargo, id_sector) " +
                                                "values ({0},'{1}', '{2}', '{3}', {4}, '{5}', {6}, {7}, '{8}', '{9}', {10}, {11})", obj.Id_Trabajador, obj.Nombres, obj.Apellido_Paterno, obj.Apellido_Materno, obj.DNI, obj.Fecha_Nacimiento,
                                                obj.Salario, obj.Telefono, obj.Direccion, obj.Anio_Ingreso, obj.cargo.Id_Cargo, obj.sector.Id_Sector);
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

        public string Modificar_Trabajador(eTrabajador obj)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string update = string.Format("update Trabajador set Nombres='{0}', Apellido_paterno='{1}', Apellido_materno='{2}', DNI={3}, Fecha_nacimiento='{4}', Salario={5}, Telefono={6}, Direccion='{7}', Anio_de_ingreso='{8}', id_cargo={9}, id_sector={10} where id_empleado={11}", 
                                obj.Nombres, obj.Apellido_Paterno, obj.Apellido_Materno, obj.DNI, obj.Fecha_Nacimiento, obj.Salario, obj.Telefono, obj.Direccion, obj.Anio_Ingreso, obj.cargo.Id_Cargo, obj.sector.Id_Sector, obj.Id_Trabajador);
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

        public string Eliminar_Trabajador(int id)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string delete = string.Format("delete from Trabajador where id_empleado={0}", id);
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

        public List<eTrabajador> TrabajadoresxSector(int idSector)      //retorna la lista de trabajadores que pertenecen a un sector determinado
        {
            try
            {
                eTrabajador trabajador = null;
                eSector sector = null;
                List<eTrabajador> trabajadores_x_sector = new List<eTrabajador>();
                SqlConnection con = db.ConectaDb();

                string select = string.Format("select tra.id_empleado,tra.Nombres, tra.Apellido_paterno, tra.Apellido_materno, tra.DNI, tra.Fecha_nacimiento, tra.Salario, tra.Telefono, tra.Direccion, tra.Anio_de_ingreso, tra.id_cargo, sec.Nombre_sector ,sec.id_sector, sec.Numero_trabajadores, sec.Ubicacion_planta from Sector as sec,Trabajador as tr  where sec.id_sector=tra.id_sector and sec.id_sector={0}", idSector);
                SqlCommand cmd = new SqlCommand(select, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    trabajador = new eTrabajador();
                    sector = new eSector();
                    trabajador.Id_Trabajador = (int)reader["id_empleado"];
                    trabajador.Nombres = (string)reader["Nombres"];
                    trabajador.Apellido_Paterno= (string)reader["Apellido_paterno"];
                    trabajador.Apellido_Materno = (string)reader["Apellido_materno"];
                    trabajador.DNI = (int)reader["DNI"];
                    trabajador.Fecha_Nacimiento= (string)reader["Fecha_nacimiento"];
                    trabajador.Salario = (decimal)reader["Salario"];
                    trabajador.Telefono = (int)reader["Telefono"];
                    trabajador.Direccion= (string)reader["Direccion"];
                    trabajador.Anio_Ingreso = (string)reader["Anio_de_ingreso"];
                    trabajador.cargo.Id_Cargo = (int)reader["Cargo"];
                    sector.Nombre_Sector = (string)reader["Nombre_sector"];
                    sector.Numero_Trabajadores = (int)reader["Numero_trabajadores"];
                    sector.Ublicacion_Planta= (string)reader["Ubicacion_planta"];
                    trabajador.sector = sector;
                    trabajadores_x_sector.Add(trabajador);
                }
                reader.Close();
                return trabajadores_x_sector;
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

        public List<eTrabajador> TrabajadoresxCargo(int idCargo)    //retornar la lista de trabajadores de un cargo
        {
            try
            {
                eTrabajador trabajador = null;
                eCargo cargo = null;
                List<eTrabajador> trabajadores_x_cargo = new List<eTrabajador>();
                SqlConnection con = db.ConectaDb();

                string select = string.Format("select tra.id_empleado,tra.Nombres, tra.Apellido_paterno, tra.Apellido_materno, tra.DNI, tra.Fecha_nacimiento, tra.Salario, tra.Telefono, tra.Direccion, tra.Anio_de_ingreso, tra.id_cargo, car.nombre_cargo ,car.id_cargo from Cargo as car,Trabajador as tr  where car.id_cargo=tra.id_cargo and car.id_cargo={0}", idCargo);
                SqlCommand cmd = new SqlCommand(select, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    trabajador = new eTrabajador();
                    cargo = new eCargo();
                    trabajador.Id_Trabajador = (int)reader["id_empleado"];
                    trabajador.Nombres = (string)reader["Nombres"];
                    trabajador.Apellido_Paterno = (string)reader["Apellido_paterno"];
                    trabajador.Apellido_Materno = (string)reader["Apellido_materno"];
                    trabajador.DNI = (int)reader["DNI"];
                    trabajador.Fecha_Nacimiento = (string)reader["Fecha_nacimiento"];
                    trabajador.Salario = (decimal)reader["Salario"];
                    trabajador.Telefono = (int)reader["Telefono"];
                    trabajador.Direccion = (string)reader["Direccion"];
                    trabajador.Anio_Ingreso = (string)reader["Anio_de_ingreso"];
                    trabajador.sector.Id_Sector = (int)reader["Sector"];
                    cargo.Nombre_Cargo= (string)reader["nombre_cargo"];
                    trabajador.cargo = cargo;
                    trabajadores_x_cargo.Add(trabajador);
                }
                reader.Close();
                return trabajadores_x_cargo;
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

        public List<eControlHoras> Lista_Control_HorasxTrabajador(int idTrabajador)             //retornar la lista de control de horarios por trabajador 
        {
            try
            {
                eControlHoras ch = null;
                eTrabajador trabajador = null;
                List<eControlHoras> controlhoras_x_trabajador = new List<eControlHoras>();
                SqlConnection con = db.ConectaDb();

                string select = string.Format("select tra.Nombres, tra.Apellido_paterno, tra.Apellido_materno, tra.DNI, tra.Fecha_nacimiento, tra.Salario, tra.Telefono, tra.Direccion, tra.Anio_de_ingreso, tra.id_cargo, ch.id_controlHoras ,ch.Hora_ingreso, ch.Hora_salida, ch.Fecha_registro from Control_Horas as ch,Trabajador as tr  where tra.id_empleado=ch.id_trabajador and tra.id_empleado={0}", idTrabajador);
                SqlCommand cmd = new SqlCommand(select, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    trabajador = new eTrabajador();
                    ch = new eControlHoras();
                    trabajador.Nombres = (string)reader["Nombres"];
                    trabajador.Apellido_Paterno = (string)reader["Apellido_paterno"];
                    trabajador.Apellido_Materno = (string)reader["Apellido_materno"];
                    trabajador.DNI = (int)reader["DNI"];
                    trabajador.Fecha_Nacimiento = (string)reader["Fecha_nacimiento"];
                    trabajador.Salario = (decimal)reader["Salario"];
                    trabajador.Telefono = (int)reader["Telefono"];
                    trabajador.Direccion = (string)reader["Direccion"];
                    trabajador.Anio_Ingreso = (string)reader["Anio_de_ingreso"];
                    trabajador.cargo.Id_Cargo = (int)reader["Cargo"];
                    ch.Id_ControlHoras = (int)reader["id_controlHoras"];
                    ch.Hora_Ingreso = (string)reader["Hora_engreso"];
                    ch.Hora_Salida = (string)reader["Hora_salida"];
                    ch.Fecha_Registro = (string)reader["Fecha_registro"];
                    ch.Id_Trabajador = trabajador.Id_Trabajador;
                    controlhoras_x_trabajador.Add(ch);
                }
                reader.Close();
                return controlhoras_x_trabajador;
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
