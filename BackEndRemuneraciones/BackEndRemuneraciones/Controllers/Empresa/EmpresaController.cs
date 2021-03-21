using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using BackEndRemuneraciones.Models.Empresa;
using BackEndRemuneraciones.Models.Empresa.RequestEmpresa;
using BackEndRemuneraciones.Models;
using BackEndRemuneraciones.Services;
using BackEndRemuneraciones.Services.Request;

namespace BackEndRemuneraciones.Controllers.Empresa
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class EmpresaController : ControllerBase
    {
        [HttpPost("AgregarEmpresa")]
        public IActionResult InsertarEmpresa(FichaEmpresaRequestModel Empresa)
        {
            var Result = FichaEmpresa.InsertarEmpresa(Empresa);
            return Ok(Result);
        }

        [HttpGet("GetBancos")]
        public IActionResult ObtenerLstBancos()
        {
            var Bancos = BancoNomina.ObtenerTodosLosBancos();
            
            return Ok(Bancos);
        }

        [HttpGet("GetLstCajasCompensacion")]
        public IActionResult ObtenerLstCajas()
        {
            var Cajas = CajaCompensacion.ObtenerLstCajaCompensacion();
            return Ok(Cajas);
        }

        [HttpGet("lstEmpresas")]
        public IActionResult ListaEmpresas()
        {
            var lstEmpresas = FichaEmpresa.ObtenerListadoEmpresas();
            return Ok(lstEmpresas);
        }

        [HttpGet("lstTipoEmpresas")]
        public IActionResult ListaTipoEmpresas(){
            var lstTipoEmpresas = TipoEmpresa.GetTipoEmpresas();
            return Ok(lstTipoEmpresas);
        }

        [HttpGet("ObtenerEmpresa/{id}")]
        public IActionResult ObtenerUnaEmpresa(int id)
        {
            var EmpresaEncontrada = FichaEmpresa.ObtenerEmpresa(id);
            return Ok(EmpresaEncontrada);
        }

        [HttpGet("LstAfps")]
        public IActionResult ObtenerAfps(){

            var LstAfp = AfpModel.ObtenerAfps();

            return Ok(LstAfp);
        }
        [HttpGet("LstIsapres")]
        public IActionResult ObtenerIsapres(){

            var LstIsapres = IsapreModel.ObtenerIsapres();

            return Ok(LstIsapres);
        }
        
        [HttpGet("LstContratos")]
        public IActionResult ObtenerContratos(){
            var LstContratos = TipoContratoModel.ObtenerListaContratos();
            return Ok(LstContratos);
        }

        [HttpGet("LstRegiones")]
        public IActionResult ObtenerListadoRegion(){
            var Regiones = RegionModel.ObtenerRegiones();
            return Ok(Regiones);
        }

        [HttpGet("RegionesYComunas/{id}")]
        public IActionResult ObtenerRegionYComunaPorId(int id){
        
            var RegionYComunas = RegionModel.ObtenerRegionYComuna(id);
            return Ok(RegionYComunas);
        }
        [HttpGet("LstComunas")]
        public IActionResult ObtenerSoloComunas(){
            var Comunas = ComunaModel.ObtenerComunas();
            return Ok(Comunas);
        }
        [HttpPost("CargoAgregar")]
        public IActionResult AgregarCargo(CargosModel Cargo){

            var ResInsercionCargo = CargosModel.AgregarCargo(Cargo);

            return Ok(ResInsercionCargo);
        }

        [HttpGet("ObtenerCargos")]
        public IActionResult GetCargos(){

            var LstCargos = CargosModel.ObtenerCargos();
            return Ok(LstCargos);
        }
        [HttpGet("VerificaTipoContrato/{id}")]
        public IActionResult VerificarTipoContrato(int id){
            
            var esIndefinido = TipoContratoModel.VerificarEsIndefinido(id);
            return Ok(esIndefinido);
        }

        [HttpGet("ObtenerTramosFamiliares")]
        public IActionResult GetTramosFamiliar(){
            var LstTramos = AsigFamiliarTramo.ObtenerTramos();
            return Ok(LstTramos);
        }

        [HttpGet("ObtenerIApv")]
        public IActionResult GetLstInstitucionesApv(){
            var LstIApv = InstitucionesApvModel.ObtenerInstitucionesApv();
            return Ok(LstIApv);
        }
        [HttpPost("AgregarHaber")]
        public IActionResult InsertarHaber(RequestCreateHaber Request){
            bool InsertResult = ServiciosHyD.AgregarHaber(Request);
            return Ok(InsertResult);
        }
        [HttpPost("AgregarDescuento")]
        public IActionResult InsertarDescuento(RequestCreateDescuento Request)
        {
            bool InsertResult = ServiciosHyD.AgregarDescuento(Request);
            return Ok(InsertResult);
        }
        [HttpGet("GetHyDempresa")]
        public IActionResult ObtenerHyDempresa(){
            var LstHyD = ServiciosHyD.ObtenerHyDempresa();
            return Ok(LstHyD);
        }
        [HttpPost("AsignarHoD")]
        public IActionResult AsignarHaberesOdescuentosEmpleado(RequestAsignarHoD Request)
        {
            var ResultInsert = ServiciosHyD.AsignarHoDEmp(Request);
            return Ok(ResultInsert);
        }
        [HttpGet("GetLibroRemuneraciones")]
        public IActionResult ObtenerLibroRemu()
        {
            var LibroRemuneraciones = ServiciosReportes.ObtenerLibroRemuneraciones();
            
            return Ok(LibroRemuneraciones);
        }
    }
}