using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndRemuneraciones.Models.Data;
public class InstitucionesApvModel{
    public int Id {get;set;}
    public string Nombre {get;set;}


    public static List<InstitucionesApvModel> ObtenerInstitucionesApv(){
        List<InstitucionesApvModel> LstIApv = new List<InstitucionesApvModel>();
        using(remuneracionesContext db = new remuneracionesContext()){
            LstIApv = db.InstitucionesApvModels.ToList();
        }
        return LstIApv;
    } 
}