using Locacao.Context;
using Locacao.DTO;
using Locacao.Model;
using Microsoft.AspNetCore.Mvc;

namespace Locacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        private readonly LocacaoContext _bd;
        public CarroController(LocacaoContext bd)
        {
            _bd = bd;
        }
        [HttpPost]
        public ActionResult Inserir([FromBody] CarroDTO carroDTO)
        {
            if (carroDTO == null)
            {
                return BadRequest("Precisa inserir dados.");
            }
            else
            {
                if (carroDTO.Codigo != 0)
                {
                    return BadRequest("Código deve ser igual a zero(0).");
                }
                else
                {
                    foreach(var item in _bd.Marcas)
                    {
                        if (item.ID == carroDTO.CodigoMarca)
                        {
                            CarroModel carroModel = new CarroModel()
                            {
                                Id = carroDTO.Codigo,
                                Nome = carroDTO.DescricaoCarro,
                                DataLocacao = carroDTO.DataLocacao,
                                Marca = item
                            };
                            _bd.Carros.Add(carroModel);
                            _bd.SaveChanges();
                            return Ok("Salvo com sucesso.");
                        }
                        else { return BadRequest("Código de marca não encontrado."); }
                    }
                }
               

            }
            return Ok();
        }


        [HttpGet]
        public ActionResult<List<CarroMarcaGetDTO>> ObterTodos()
        {
            {
                List<CarroMarcaGetDTO> listaCarroGetDTO = new List<CarroMarcaGetDTO>();

                foreach (var item in _bd.Carros)
                {
                    var carroGetDTO = new CarroMarcaGetDTO();
                    carroGetDTO.Codigo = item.Id;
                    carroGetDTO.DescricaoCarro = item.Nome;
                    carroGetDTO.CodigoMarca = item.IdMarca;
                    carroGetDTO.DataLocacao = item.DataLocacao;
                    carroGetDTO.ListaMarcaDTO = new List<MarcaDTO>();
                    foreach (var buscaMarca in _bd.Marcas)
                    {
                        if (buscaMarca.ID == carroGetDTO.Codigo)
                        {
                            MarcaDTO marcaDTO = new MarcaDTO()
                            {
                                Codigo = buscaMarca.ID,
                                Nome = buscaMarca.Nome
                            };
                            carroGetDTO.ListaMarcaDTO.Add(marcaDTO);
                        }
                    }
                    listaCarroGetDTO.Add(carroGetDTO);
                }
                return Ok(listaCarroGetDTO);
            }
        }
        [HttpGet("codigo/{codigo}")]
        public ActionResult<CarroMarcaGetDTO> ObterCodigo([FromRoute] int codigo)
        {
            var filtro = _bd.Carros.Where(o => o.Id == codigo).FirstOrDefault();
            var carroGetDTO = new CarroMarcaGetDTO();

            foreach (var item in _bd.Carros)
            {
                if (item.Id == codigo)
                {
                    carroGetDTO.Codigo = item.Id;
                    carroGetDTO.DescricaoCarro = item.Nome;
                    carroGetDTO.CodigoMarca = item.IdMarca;
                    carroGetDTO.DataLocacao = item.DataLocacao;
                    carroGetDTO.ListaMarcaDTO = new List<MarcaDTO>();
                    foreach (var buscaMarca in _bd.Marcas)
                    {
                        if (buscaMarca.ID == carroGetDTO.Codigo)
                        {
                            MarcaDTO marcaDTO = new MarcaDTO()
                            {
                                Codigo = buscaMarca.ID,
                                Nome = buscaMarca.Nome
                            };
                            carroGetDTO.ListaMarcaDTO.Add(marcaDTO);
                        }
                    }
                }
            }
            return Ok(carroGetDTO);
        }





    }
}
