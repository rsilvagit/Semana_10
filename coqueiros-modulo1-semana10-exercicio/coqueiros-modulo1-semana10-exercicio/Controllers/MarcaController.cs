using coqueiros_modulo1_semana10_exercicio.DTO;
using coqueiros_modulo1_semana10_exercicio.Models;
using Microsoft.AspNetCore.Mvc;
using coqueiros_modulo1_semana10_exercicio.DTO;


namespace coqueiros_modulo1_semana10_exercicio.Controllers
{

    public class MarcaController : Controller
    {
        private readonly LocacaoContext _dbcontext;
        public MarcaController(LocacaoContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        // GET: MarcaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MarcaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MarcaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // Post: 1
        [HttpPost("marca")]
        public ActionResult Create([FromBody] MarcaDto marcaDto)
        {

            if (marcaDto.Nome == null || marcaDto.Codigo != 0)
            {
                return BadRequest("Falha na requisição Post");
            }
            else
            {
                MarcaModel marcaModel = new MarcaModel();
                marcaModel.Nome = marcaDto.Nome;
                marcaModel.Id = 0;
                _dbcontext.Marca.Add(marcaModel);
                _dbcontext.SaveChanges();
                return Ok();
            }



        }

        [HttpPut("{codigo}")]
        public ActionResult EditarId([FromRoute] int codigo, [FromBody] MarcaDto marcaDto)
        {
            var filtro = _dbcontext.Marca.Where(o => o.Id == codigo).FirstOrDefault();
            if (filtro != null)
            {
                if (marcaDto.Codigo != 0)
                {
                    return BadRequest("Não foi possivel editar os dados.");
                }
                else
                {
                    MarcaModel marcaModel = new MarcaModel();
                    marcaModel.Nome = marcaDto.Nome;
                    marcaModel.Id = marcaDto.Codigo;
                    _dbcontext.Marca.Attach(marcaModel);
                    _dbcontext.SaveChanges();
                    return Ok();
                }
            }
            else
            {
                return BadRequest("Código não encontrado.");
            }
        }
        [HttpDelete("{codigo}")]
        public ActionResult DeletarId([FromRoute] int codigo)
        {
            var filtro = _dbcontext.Marca.Where(o => o.Id == codigo).FirstOrDefault();
            if (filtro != null)
            {
                _dbcontext.Marca.Remove(filtro);
                _dbcontext.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        } 
            /*[HttpGet]
        public ActionResult<List<MarcaDTO>> ObterTodos()
        {

            //var ListaMarcas = new MarcaDTO();
            List<MarcaDTO> ListaMarcaDTO = new List<MarcaDTO>();

            foreach (var item in _marca.Marcas)
            {
                var MarcaDTO = new MarcaDTO();
                MarcaDTO.Codigo = item.ID;
                MarcaDTO.Nome = item.Nome;
                ListaMarcaDTO.Add(MarcaDTO);
            }
            return Ok(ListaMarcaDTO);
        }*/

        // GET: MarcaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MarcaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MarcaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MarcaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
