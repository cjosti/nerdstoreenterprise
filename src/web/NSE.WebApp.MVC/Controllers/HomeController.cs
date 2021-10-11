using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSE.WebApp.MVC.Models;
using System.Diagnostics;

namespace NSE.WebApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("erro/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var modelErro = new ErrorViewModel();

            if (id == 500)
            {
                modelErro.Mensagem = "Ocorreu um erro! Tente novamente mais tarde ou contate o nosso suporte.";
                modelErro.Titulo = "Ocorreu um erro!";
            }
            else if (id == 404)
            {
                modelErro.Mensagem =
                    "A página que está procurando não existe! <br /> Em caso de dúvidas entre em contato com o nosso suporte.";
                modelErro.Titulo = "Ops! Página não encontrada.";
            }
            else if (id == 403)
            {
                modelErro.Mensagem =
                    "Você não tem permissão para fazer isto.";
                modelErro.Titulo = "Acesso negado.";
            }
            else
            {
                return StatusCode(404);
            }

            modelErro.ErroCode = id;
            return View("Error", modelErro);
        }
    }
}
