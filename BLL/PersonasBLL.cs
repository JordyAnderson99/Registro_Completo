using System;
using System.Linq;
using System.Linq.Expressions;
using Registro_Completo.Dal;
using Registro_Completo.Entidades;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Registro_Completo.BLL{

    public class PersonasBLL{

        public static bool Guardar(Persona persona){
            if(!Existe(persona.ID))
                return Insertar(persona);
            else
                return Modificar(persona);    
        }

        private static bool Insertar(Persona persona){
            bool paso = false;
            Contexto contexto= new Contexto();

            try{
                //Agregar a la entidad que se desea ingresar al contexto
                contexto.Persona.Add(persona);
                paso =contexto.SaveChanges()>0;
            }
            catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            } 
            return paso;

        }

        private static bool Modificar(Persona persona){

             bool paso = false;
            Contexto contexto = new Contexto();

            try{
                //Marcar la entidad como modificada para que 
                //el contexto sepa como proceder

                contexto.Entry(persona).State= EntityState.Modified;
                paso = contexto.SaveChanges() >0;
            }
            catch(Exception){
                throw;
           }
           finally{
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id){
            bool paso = false;
            Contexto contexto = new Contexto();
            try{
                //Buscar La entidad que se desea eliminar
                var persona =contexto.Persona.Find(id);

                if(persona != null){
                    
                    contexto.Persona.Remove(persona);//remover la entidad
                    paso =contexto.SaveChanges() >0;
                }
            }
            catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }

            return paso;
        }
        public static Persona Buscar(int id){

            Contexto contexto = new Contexto();
            Persona persona = new Persona();

            try{

                persona= contexto.Persona.Find(id);
            }
            catch(Exception){
                throw;

            }
            finally{

                contexto.Dispose();
            }

            return persona;
        }
        public static bool Existe(int id){
        
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try{
                encontrado = contexto.Persona.Any(e => e.ID == id);
            }
            catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }

            return encontrado;
        }

    }
    
}