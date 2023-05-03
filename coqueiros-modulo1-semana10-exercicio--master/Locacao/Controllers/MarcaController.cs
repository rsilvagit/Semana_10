using Microsoft.AspNetCore.Mvc;
using Locacao.Model;
using Locacao.DTO;
using Locacao.Context;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace Locacao.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly LocacaoContext _bd;

        public MarcaController (LocacaoContext marca)
        {
            _bd = marca;
        }
//Inserir:
        [HttpPost]
        public ActionResult Inserir([FromBody] MarcaDTO marcaDTO)
        {
            if (marcaDTO.Nome == null || marcaDTO.Codigo!=0) 
            {
                return BadRequest("Não foi possivel inserir na base de dados. A propriedade NOME deve ser preenchida e CÓDIGO deve ser zero(0)");
            }
            else
            {
                MarcaModel marcaModel = new MarcaModel();
                marcaModel.Nome = marcaDTO.Nome;
                marcaModel.ID = 0;
                _bd.Marcas.Add(marcaModel);
                _bd.SaveChanges();
                return Ok();
            }
        }
//Editar por Id:
        [HttpPut("{codigo}")]
        public ActionResult EditarId([FromRoute] int codigo, [FromBody] MarcaDTO marcaDTO)
        {
            var filtro = _bd.Marcas.Where(o=>o.ID==codigo).FirstOrDefault();
            if (filtro != null)
            {
               if (marcaDTO.Codigo != 0)
                {
                    return BadRequest("Não foi possivel editar os dados.");
                }
                else
                {
                    MarcaModel marcaModel = new MarcaModel();
                    marcaModel.Nome = marcaDTO.Nome;
                    marcaModel.ID = marcaDTO.Codigo;
                    _bd.Marcas.Attach(marcaModel);
                    _bd.SaveChanges();
                    return Ok();
                }
            }
            else
            {
                return BadRequest("Código não encontrado.");
            }
        }
//Deletar por Id
        [HttpDelete("{codigo}")]
        public ActionResult DeletarId([FromRoute] int codigo)
        {
            var filtro = _bd.Marcas.Where(o => o.ID == codigo).FirstOrDefault();
            if (filtro != null)
            {
                _bd.Marcas.Remove(filtro);
                _bd.SaveChanges();
                return Ok();
            }else
            {
                return BadRequest();
            }
        }
//Obter todos:
        [HttpGet]
        public ActionResult<List<MarcaGetDTO>> ObterTodos()
        {
            List<MarcaGetDTO> ListaMarcaGetDTO = new List<MarcaGetDTO>();

            foreach(var item in _bd.Marcas)
            {
                var marcaGetDTO = new MarcaGetDTO();
                marcaGetDTO.Codigo = item.ID;
                marcaGetDTO.Nome = item.Nome;
                marcaGetDTO.ListaCarroGetDTO = new List<CarroGetDTO>();
                foreach(var buscaCarro in _bd.Carros)
                {
                    if (buscaCarro.IdMarca == marcaGetDTO.Codigo)
                    {
                        CarroGetDTO carroGetDTO = new CarroGetDTO()
                        {
                            Codigo = buscaCarro.Id,
                            DescricaoCarro = buscaCarro.Nome,
                            CodigoMarca = buscaCarro.IdMarca,
                            DataLocacao = buscaCarro.DataLocacao
                        };
                        marcaGetDTO.ListaCarroGetDTO.Add(carroGetDTO);
                    }
                }
                ListaMarcaGetDTO.Add(marcaGetDTO);
            }
            return Ok(ListaMarcaGetDTO);
        }
//Obter por Id:
        [HttpGet("codigo/{codigo}")]
        public ActionResult<List<MarcaGetDTO>> ObterId([FromRoute] int codigo)
        {
            var filtro = _bd.Marcas.Where(o => o.ID == codigo).FirstOrDefault();
            List<MarcaDTO> marcaDTOs = new List<MarcaDTO>();

            if (filtro != null)
            {
                List<MarcaGetDTO> ListaMarcaGetDTO = new List<MarcaGetDTO>();

                foreach (var item in _bd.Marcas)
                {
                    var marcaGetDTO = new MarcaGetDTO();
                    marcaGetDTO.Codigo = item.ID;
                    marcaGetDTO.Nome = item.Nome;
                    marcaGetDTO.ListaCarroGetDTO = new List<CarroGetDTO>();
                    foreach (var buscaCarro in _bd.Carros)
                    {
                        if (buscaCarro.IdMarca == marcaGetDTO.Codigo)
                        {
                            CarroGetDTO carroGetDTO = new CarroGetDTO()
                            {
                                Codigo = buscaCarro.Id,
                                DescricaoCarro = buscaCarro.Nome,
                                CodigoMarca = buscaCarro.IdMarca,
                                DataLocacao = buscaCarro.DataLocacao
                            };
                            marcaGetDTO.ListaCarroGetDTO.Add(carroGetDTO);
                        }
                    }
                    ListaMarcaGetDTO.Add(marcaGetDTO);
                }
                return Ok(ListaMarcaGetDTO);
            else
            {
                return BadRequest("Código não encontrado");
            }
            
        }
    }
}
