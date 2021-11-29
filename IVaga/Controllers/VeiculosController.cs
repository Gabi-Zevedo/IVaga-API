using IVaga.Application.Contratos;
using IVaga.Application.Services;
using IVaga.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace IVaga.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculosController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;

        public VeiculosController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Veiculo veiculoModel)
        {
            try
            {
                var veiculo = await _veiculoService.AddVeiculo(veiculoModel);
                if (veiculo == null) return BadRequest("Erro ao adicionar Evento");

                return Ok(veiculoModel);
            }
            catch (Exception e)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao adicionar veículo. Erro: {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            try
            {
                var veiculos = await _veiculoService.GetVeiculoByIdAsync(id);
                if (veiculos == null) return NotFound("Nenhum Veiculo encontrado");

                return Ok(veiculos);
            }
            catch (Exception e)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao recuperar veículos. Erro: {e.Message}");
            }

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {
                var veiculos = await _veiculoService.GetVeiculosAsync();
                if (veiculos == null) return NotFound("Nenhum Veiculo encontrado");

                return Ok(veiculos);
            }
            catch (Exception e)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao recuperar veículos. Erro: {e.Message}");
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Veiculo veiculoModel)
        {
            try
            {
                var veiculo = await _veiculoService.UpdateVeiculo(id, veiculoModel);
                if (veiculo == null) return BadRequest("Erro ao atualizar Evento");

                return Ok(veiculoModel);
            }
            catch (Exception e)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao atualizar veículo. Erro: {e.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _veiculoService.DeleteVeiculo(id) ? Ok("Deletado") : BadRequest("Veiculo não deletado");
            }
            catch (Exception e)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao deletar veículos. Erro: {e.Message}");
            }
        }

    }
}
